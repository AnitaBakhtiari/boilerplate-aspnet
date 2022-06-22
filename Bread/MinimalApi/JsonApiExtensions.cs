using System.Text.Json.Nodes;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace Bread.MinimalApi;

public static class JsonApiExtensions
{
    private static JsonAPIsConfig _Config;

    public static WebApplication UseJsonRoutes(this WebApplication app, Action<JsonApIsConfigBuilder> options = null!)
    {
        var builder = new JsonApIsConfigBuilder();
        _Config = new JsonAPIsConfig();
        if (options != null)
        {
            options(builder);
            _Config = builder.Build();
        }

        var writableDoc = JsonNode.Parse(File.ReadAllText(_Config.JsonFilename));

        // print API
        foreach (var elem in writableDoc?.Root.AsObject().AsEnumerable()!)
        {
            var thisEntity = _Config.Tables.FirstOrDefault(t =>
                t.Name.Equals(elem.Key, StringComparison.InvariantCultureIgnoreCase));
            if (thisEntity == null) continue;

            if ((thisEntity.ApiMethodsToGenerate & ApiMethodsToGenerate.Get) == ApiMethodsToGenerate.Get)
                Console.WriteLine($"GET /{elem.Key.ToLower()}");

            if ((thisEntity.ApiMethodsToGenerate & ApiMethodsToGenerate.GetById) == ApiMethodsToGenerate.GetById)
                Console.WriteLine($"GET /{elem.Key.ToLower()}" + "/id");

            if ((thisEntity.ApiMethodsToGenerate & ApiMethodsToGenerate.Insert) == ApiMethodsToGenerate.Insert)
                Console.WriteLine($"POST /{elem.Key.ToLower()}");

            if ((thisEntity.ApiMethodsToGenerate & ApiMethodsToGenerate.Delete) == ApiMethodsToGenerate.Delete)
                Console.WriteLine($"DELETE /{elem.Key.ToLower()}" + "/id");

            Console.WriteLine(" ");
        }

        // setup routes
        foreach (var elem in writableDoc?.Root.AsObject().AsEnumerable()!)
        {
            var thisEntity = _Config.Tables.FirstOrDefault(t =>
                t.Name.Equals(elem.Key, StringComparison.InvariantCultureIgnoreCase));
            if (thisEntity == null) continue;

            var arr = elem.Value!.AsArray();

            if ((thisEntity.ApiMethodsToGenerate & ApiMethodsToGenerate.Get) == ApiMethodsToGenerate.Get)
                app.MapGet($"/{elem.Key}", () => elem.Value.ToString());

            if ((thisEntity.ApiMethodsToGenerate & ApiMethodsToGenerate.GetById) == ApiMethodsToGenerate.GetById)
                app.MapGet($"/{elem.Key}" + "/{id}", (int id) =>
                {
                    var matchedItem = arr.SingleOrDefault(row => row != null && row
                        .AsObject()
                        .Any(o => o.Value != null && o.Key.ToLower() == "id" && int.Parse(o.Value.ToString()) == id)
                    );
                    return matchedItem;
                });

            if ((thisEntity.ApiMethodsToGenerate & ApiMethodsToGenerate.Insert) == ApiMethodsToGenerate.Insert)
                app.MapPost($"/{elem.Key}", async (HttpRequest request) =>
                {
                    var content = string.Empty;
                    using (var reader = new StreamReader(request.Body))
                    {
                        content = await reader.ReadToEndAsync();
                    }

                    var newNode = JsonNode.Parse(content);
                    var array = elem.Value.AsArray();
                    newNode?.AsObject().Add("Id", array.Count() + 1);
                    array.Add(newNode);

                    await File.WriteAllTextAsync(_Config.JsonFilename, writableDoc.ToString());
                    return content;
                });

            if ((thisEntity.ApiMethodsToGenerate & ApiMethodsToGenerate.Update) == ApiMethodsToGenerate.Update)
                app.MapPut($"/{elem.Key}", () => "TODO");

            if ((thisEntity.ApiMethodsToGenerate & ApiMethodsToGenerate.Delete) == ApiMethodsToGenerate.Delete)
                app.MapDelete($"/{elem.Key}" + "/{id}", (int id) =>
                {
                    var matchedItem = arr
                        .Select((value, index) => new {value, index})
                        .SingleOrDefault(row => row.value
                            .AsObject()
                            .Any(o => o.Value != null && o.Key.ToLower() == "id" && int.Parse(o.Value.ToString()) == id)
                        );
                    if (matchedItem != null)
                    {
                        arr.RemoveAt(matchedItem.index);
                        File.WriteAllText(_Config.JsonFilename, writableDoc.ToString());
                    }

                    return "OK";
                });
        }

        ;

        return app;
    }
}