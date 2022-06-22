using System.Text.Json.Nodes;

namespace Bread.MinimalApi;

internal class JsonAPIsConfig
{
    internal string JsonFilename = "mock.json";
    internal HashSet<WebApplicationExtensions.TypeTable> Tables { get; } = new();
}

public class JsonApIsConfigBuilder
{
    private readonly JsonAPIsConfig _config = new();
    private readonly List<string> _excludedTables = new();
    private readonly HashSet<TableApiMapping> _includedTables = new();
    private string _fileName = null!;

    public JsonApIsConfigBuilder SetFilename(string fileName)
    {
        _fileName = fileName;
        return this;
    }

    internal JsonAPIsConfig Build()
    {
        if (string.IsNullOrEmpty(_fileName)) throw new ArgumentNullException("Missing Json Filename for configuration");
        if (!File.Exists(_fileName))
            throw new ArgumentException($"Unable to locate the JSON file for APIs at {_fileName}");
        _config.JsonFilename = _fileName;

        BuildTables();

        return _config;
    }

    #region Table Inclusion/Exclusion

    /// <summary>
    ///     Specify individual entities to include in the API generation with the methods requested
    /// </summary>
    /// <param name="entityName">Name of the JSON entity collection to include</param>
    /// <param name="methodsToGenerate">A flags enumerable indicating the methods to generate.  By default ALL are generated</param>
    /// <returns>Configuration builder with this configuration applied</returns>
    public JsonApIsConfigBuilder IncludeEntity(string entityName,
        ApiMethodsToGenerate methodsToGenerate = ApiMethodsToGenerate.All)
    {
        var tableApiMapping = new TableApiMapping(entityName, methodsToGenerate);
        _includedTables.Add(tableApiMapping);

        if (_excludedTables.Contains(entityName)) _excludedTables.Remove(tableApiMapping.TableName);

        return this;
    }

    /// <summary>
    ///     Exclude individual entities from the API generation.  Exclusion takes priority over inclusion
    /// </summary>
    /// <param name="entitySelector">Name of the JSON entity collection to exclude</param>
    /// <returns>Configuration builder with this configuraiton applied</returns>
    public JsonApIsConfigBuilder ExcludeTable(string entityName)
    {
        if (_includedTables.Select(t => t.TableName).Contains(entityName))
            _includedTables.Remove(_includedTables.First(t => t.TableName == entityName));
        _excludedTables.Add(entityName);

        return this;
    }

    private HashSet<string> IdentifyEntities()
    {
        var writableDoc = JsonNode.Parse(File.ReadAllText(_fileName));

        // print API
        return writableDoc?.Root.AsObject()
            .AsEnumerable().Select(x => x.Key)
            .ToHashSet()!;
    }

    private void BuildTables()
    {
        var tables = IdentifyEntities();

        if (!_includedTables.Any() && !_excludedTables.Any())
        {
            _config.Tables.UnionWith(tables.Select(t => new WebApplicationExtensions.TypeTable
            {
                Name = t,
                ApiMethodsToGenerate = ApiMethodsToGenerate.All
            }));
            return;
        }

        // Add the Included tables
        var outTables = _includedTables
            .Select(t => new WebApplicationExtensions.TypeTable
            {
                Name = t.TableName,
                ApiMethodsToGenerate = t.MethodsToGenerate
            }).ToArray();

        // If no tables were added, added them all
        if (outTables.Length == 0)
            outTables = tables.Select(t => new WebApplicationExtensions.TypeTable
            {
                Name = t,
                ApiMethodsToGenerate = ApiMethodsToGenerate.All
            }).ToArray();

        // Remove the Excluded tables
        outTables = outTables.Where(t =>
            !_excludedTables.Any(e => t.Name.Equals(e, StringComparison.InvariantCultureIgnoreCase))).ToArray();

        if (outTables == null || !outTables.Any())
            throw new ArgumentException("All tables were excluded from this configuration");

        _config.Tables.UnionWith(outTables);
    }

    #endregion
}