using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Homework12
{
    public class ReadData
    {
        public static List<T> ReadFrom<T>(string fileName)
        {
            var assembly = Assembly.GetExecutingAssembly();
            return ReadFrom<List<T>>(assembly.GetManifestResourceStream($"Homework12.Files.{fileName}"));
        }

        private static T ReadFrom<T>(Stream stream)
        {
            using (stream)
            using (var reader = new StreamReader(stream ?? throw new InvalidOperationException()))
            {
                var text = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<T>(
                    text,
                    new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });
            }
        }
    }
}
