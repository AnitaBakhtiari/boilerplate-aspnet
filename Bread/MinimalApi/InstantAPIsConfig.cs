using Microsoft.EntityFrameworkCore;

namespace Bread.MinimalApi;

internal class InstantApIsConfig
{
    internal HashSet<WebApplicationExtensions.TypeTable> Tables { get; } = new();
}

public class InstantApIsConfigBuilder<TD> where TD : DbContext
{
    private const string DefaultUri = "/api/";
    private readonly InstantApIsConfig _config = new();
    private readonly Type _contextType = typeof(TD);
    private readonly List<string> _excludedTables = new();
    private readonly HashSet<TableApiMapping> _includedTables = new();
    private readonly TD _theContext;

    public InstantApIsConfigBuilder(TD theContext)
    {
        _theContext = theContext;
    }

    internal InstantApIsConfig Build()
    {
        BuildTables();

        return _config;
    }

    #region Table Inclusion/Exclusion

    /// <summary>
    ///     Specify individual tables to include in the API generation with the methods requested
    /// </summary>
    /// <param name="taleName"></param>
    /// <param name="methodsToGenerate">A flags enumerable indicating the methods to generate.  By default ALL are generated</param>
    /// <param name="roles"></param>
    /// <param name="baseUrl"></param>
    /// <returns>Configuration builder with this configuration applied</returns>
    public InstantApIsConfigBuilder<TD> IncludeTable(string taleName,
        ApiMethodsToGenerate methodsToGenerate = ApiMethodsToGenerate.All, Roles roles = Roles.administrators1,
        string baseUrl = "")
    {
        //var theSetType = entitySelector(_TheContext).GetType().BaseType;
        //var property = _ContextType.GetProperties().First(p => p.PropertyType == theSetType);

        if (!string.IsNullOrEmpty(baseUrl))
            try
            {
                var testUri = new Uri(baseUrl, UriKind.RelativeOrAbsolute);
                baseUrl = testUri.IsAbsoluteUri ? testUri.LocalPath : baseUrl;
            }
            catch
            {
                throw new ArgumentException(nameof(baseUrl), "Not a valid Uri");
            }
        else
            baseUrl = string.Concat(DefaultUri, taleName);

        var tableApiMapping = new TableApiMapping(taleName, methodsToGenerate, roles, baseUrl);
        _includedTables.Add(tableApiMapping);

        if (_excludedTables.Contains(tableApiMapping.TableName)) _excludedTables.Remove(tableApiMapping.TableName);
        _includedTables.Add(tableApiMapping);

        return this;
    }


    //public InstantAPIsConfigBuilder<D> IncludeTable<T>(Func<D, DbSet<T>> entitySelector, ApiMethodsToGenerate methodsToGenerate = ApiMethodsToGenerate.All, string baseUrl = "") where T : class
    //{

    //	var theSetType = entitySelector(_TheContext).GetType().BaseType;
    //	var property = _ContextType.GetProperties().First(p => p.PropertyType == theSetType);

    //	if (!string.IsNullOrEmpty(baseUrl))
    //	{
    //		try
    //		{
    //			var testUri = new Uri(baseUrl, UriKind.RelativeOrAbsolute);
    //			baseUrl = testUri.IsAbsoluteUri ? testUri.LocalPath : baseUrl;
    //		}
    //		catch
    //		{
    //			throw new ArgumentException(nameof(baseUrl), "Not a valid Uri");
    //		}
    //	}
    //	else
    //	{
    //		baseUrl = String.Concat(DEFAULT_URI, property.Name);
    //	}

    //	var tableApiMapping = new TableApiMapping(property.Name, methodsToGenerate, baseUrl);
    //	_IncludedTables.Add(tableApiMapping);

    //	if (_ExcludedTables.Contains(tableApiMapping.TableName)) _ExcludedTables.Remove(tableApiMapping.TableName);
    //	_IncludedTables.Add(tableApiMapping);

    //	return this;

    //}

    /// <summary>
    ///     Exclude individual tables from the API generation.  Exclusion takes priority over inclusion
    /// </summary>
    /// <param name="entitySelector">Select the entity to exclude from generation</param>
    /// <returns>Configuration builder with this configuraiton applied</returns>
    public InstantApIsConfigBuilder<TD> ExcludeTable<T>(Func<TD, DbSet<T>> entitySelector) where T : class
    {
        var theSetType = entitySelector(_theContext).GetType().BaseType;
        var property = _contextType.GetProperties().First(p => p.PropertyType == theSetType);

        if (_includedTables.Select(t => t.TableName).Contains(property.Name))
            _includedTables.Remove(_includedTables.First(t => t.TableName == property.Name));
        _excludedTables.Add(property.Name);

        return this;
    }

    private void BuildTables()
    {
        var tables = WebApplicationExtensions.GetDbTablesForContext<TD>().ToArray();
        WebApplicationExtensions.TypeTable[]? outTables;

        // Add the Included tables
        if (_includedTables.Any())
            outTables = tables.Where(t =>
                    _includedTables.Any(i => i.TableName.Equals(t.Name, StringComparison.InvariantCultureIgnoreCase)))
                .Select(t => new WebApplicationExtensions.TypeTable
                {
                    Name = t.Name,
                    InstanceType = t.InstanceType,
                    ApiMethodsToGenerate = _includedTables
                        .First(i => i.TableName.Equals(t.Name, StringComparison.InvariantCultureIgnoreCase))
                        .MethodsToGenerate,
                    Roles = _includedTables
                        .First(i => i.TableName.Equals(t.Name, StringComparison.InvariantCultureIgnoreCase)).Roles,
                    BaseUrl = new Uri(
                        _includedTables.First(i =>
                            i.TableName.Equals(t.Name, StringComparison.InvariantCultureIgnoreCase)).BaseUrl,
                        UriKind.Relative)
                }).ToArray();
        else
            outTables = tables.Select(t => new WebApplicationExtensions.TypeTable
            {
                Name = t.Name,
                InstanceType = t.InstanceType,
                BaseUrl = new Uri(DefaultUri + t.Name, UriKind.Relative)
            }).ToArray();

        // Exit now if no tables were excluded
        if (!_excludedTables.Any())
        {
            _config.Tables.UnionWith(outTables);
            return;
        }

        // Remove the Excluded tables
        outTables = outTables.Where(t =>
            !_excludedTables.Any(e => t.Name.Equals(e, StringComparison.InvariantCultureIgnoreCase))).ToArray();

        if (outTables == null || !outTables.Any())
            throw new ArgumentException("All tables were excluded from this configuration");

        _config.Tables.UnionWith(outTables);
    }

    #endregion
}