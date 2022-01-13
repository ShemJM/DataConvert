using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace DataConvert.Application
{
    public class CSVConverter
    {
        public static string ConvertToJson(Stream csv)
        {
            using (var sr = new StreamReader(csv))
            {
                string csvString = sr.ReadToEnd();
                return ConvertCSVStringToJson(csvString);
            };
        }

        public static string ConvertToJson(string csvString) => ConvertCSVStringToJson(csvString);

        private static string ConvertCSVStringToJson(string csvString)
        {
            var jsonArray = ConvertCSVStringToJsonArray(csvString);
            return ConvertJsonArrayToString(jsonArray);
        }

        private static string ConvertJsonArrayToString(JsonArray jsonArray)
        {
            JsonSerializerOptions options = new() { WriteIndented = true };

            return JsonSerializer.Serialize(jsonArray, options);
        }

        private static JsonArray ConvertCSVStringToJsonArray(string csvString)
        {
            JsonArray jsonArray = new();

            var lines = csvString.Split("\r\n").Where(l => !string.IsNullOrEmpty(l)).ToList();
            var headers = lines[0].Split(",");

            foreach (var line in lines.Skip(1))
            {
                var fields = line.Split(",");
                var element = new JsonObject();

                for (int i = 0; i < fields.Length; i++)
                {
                    element[headers[i]] = GetFieldValue(fields[i]);
                }

                jsonArray.Add(element);
            }

            return jsonArray;
        }

        private static dynamic? GetFieldValue(string field)
        {
            dynamic? result = field;

            if (decimal.TryParse(field, out var value))
                result = value;

            if (field == "true" || field == "false")
                result = field == "true";
            if (string.IsNullOrEmpty(field) || field == "null")
                result = null;

            return result is not null ? JsonValue.Create(result) : null;
        }
    }
}