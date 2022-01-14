using DataConvert.Application;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using Xunit;

namespace DataConvert.Unit
{
    public class CSVConverterTests
    {
        [Fact]
        public void TestCSVString_ShouldBeConvertedToJsonString()
        {
            string jsonFilePath = @"data.json";

            string json = File.ReadAllText(jsonFilePath);

            using (var testCsvStream = File.Open("TestData.csv", FileMode.Open))
            {
                using (var sr = new StreamReader(testCsvStream))
                {
                    string csvText = sr.ReadToEnd();
                    var result = CSVConverter.ConvertToJsonString(csvText);
                    Assert.Equal(json, result);
                };
            }
        }

        [Fact]
        public void TestCSVStream_ShouldBeConvertedToJsonString()
        {
            string jsonFilePath = @"data.json";

            string json = File.ReadAllText(jsonFilePath);

            using (var testCsvStream = File.Open("TestData.csv", FileMode.Open))
            {
                var result = CSVConverter.ConvertToJsonString(testCsvStream);

                Assert.Equal(json, result);
            };
        }
    }
}
