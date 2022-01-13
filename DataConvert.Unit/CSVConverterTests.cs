using DataConvert.Application;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace DataConvert.Unit
{
    public class CSVConverterTests
    {
        [Fact]
        public void TestCSVString_ShouldBeConvertedToJson()
        {
            using (var testCsvStream = File.Open("TestData.csv", FileMode.Open))
            {
                string jsonFilePath = @"data.json";

                string json = File.ReadAllText(jsonFilePath);
                using (var sr = new StreamReader(testCsvStream))
                {
                    string csvText = sr.ReadToEnd();
                    var result = CSVConverter.ConvertToJson(csvText);
                    Assert.Equal(json, result);
                };
            }
        }
        [Fact]
        public void TestCSVStream_ShouldBeConvertedToJson()
        {
            using (var testCsvStream = File.Open("TestData.csv", FileMode.Open))
            {
                string jsonFilePath = @"data.json";

                string json = File.ReadAllText(jsonFilePath);

                var result = CSVConverter.ConvertToJson(testCsvStream);

                Assert.Equal(json, result);
            }
        }
    }
}
