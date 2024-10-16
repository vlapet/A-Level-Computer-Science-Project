using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using CardProjectClient.game;

namespace CardProjectClient.lib
{
    public abstract class JsonParseMethods
    {
        public static async Task<T> ParseToObjectFromWebResponse<T>(HttpResponseMessage Response, System.Text.Json.JsonSerializerOptions JOptions = null)
        {
            return await JsonSerializer.DeserializeAsync<T>(await Response.Content.ReadAsStreamAsync(), JOptions);
        }

        public static async Task<T> ParseToObjectFromJson<T>(string Json, System.Text.Json.JsonSerializerOptions JOptions = null)
        {
            MemoryStream MStream = new MemoryStream();
            StreamWriter Writer = new StreamWriter(MStream);
            Writer.Write(Json);
            return await JsonSerializer.DeserializeAsync<T>(MStream, JOptions);
        }

        public static T ParseToObjectFromJsonSynchronous<T>(string Json, System.Text.Json.JsonSerializerOptions JOptions = null)
        {
            return System.Text.Json.JsonSerializer.Deserialize<T>(Json, JOptions);
        }

        public static string ParseToJsonFromObject<T>(T ObjectToParse, System.Text.Json.JsonSerializerOptions JOptions = null)
        {
            return JsonSerializer.Serialize(ObjectToParse, JOptions);
        }

        public static async Task<string> ParseToJsonFromObjectAsync<T>(T ObjectToParse, System.Text.Json.JsonSerializerOptions JOptions = null)
        {
            MemoryStream MStream = new MemoryStream();
            JsonSerializer.SerializeAsync(MStream, ObjectToParse,JOptions);

            StreamReader Reader = new StreamReader(MStream);
            return await Reader.ReadToEndAsync();
        }
    }
}
