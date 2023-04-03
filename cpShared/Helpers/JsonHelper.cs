using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace cpShared.Helpers
{
    public class JsonHelper
    {
        public static void WriteToJsonStream<T>(MemoryStream s, List<T> lstEntities)
        {
            using (var streamWriter = new StreamWriter(s, encoding: Encoding.UTF8, bufferSize: 4096, true))
            {
                var settings = new JsonSerializerSettings
                {
                    PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                    Formatting = Formatting.Indented
                };
                using (var jsonWriter = new JsonTextWriter(streamWriter))
                {
                    var serializer = JsonSerializer.Create(settings);
                    serializer.Serialize(jsonWriter, lstEntities);
                }
            }
        }
        public static void WriteToJsonFile(string FileName, object lstEntities)
        {
            using (StreamWriter file = File.CreateText(FileName))
            {
                var settings = new JsonSerializerSettings
                {
                    PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                    Formatting = Formatting.Indented
                };
                JsonSerializer serializer = JsonSerializer.Create(settings);
                //serialize object directly into file stream
                serializer.Serialize(file, lstEntities);
            }
        }

    }
}
