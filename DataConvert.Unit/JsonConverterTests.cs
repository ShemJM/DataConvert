using DataConvert.Application;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Xunit;

namespace DataConvert.Unit
{
    public class JsonConverterTests
    {
        [Fact]
        public void JsonString_ShouldConvertToXML()
        {
            string jsonFilePath = @"data.json";

            string json = File.ReadAllText(jsonFilePath);

            string xmlFilePath = "data.xml";

            string xml = File.ReadAllText(xmlFilePath);

            Assert.Equal(XDocument.Parse(xml).ToString(), JsonConverter.ConvertToXML(json));
        }
    }
}
