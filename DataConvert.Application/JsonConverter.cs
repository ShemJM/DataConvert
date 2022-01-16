using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace DataConvert.Application
{
    public class JsonConverter
    {
        public static string ConvertToXML(string json)
        {
            var xdoc = JsonConvert.DeserializeXmlNode("{\"Row\":" + json + "}", "root");

            return XDocument.Parse(xdoc.OuterXml).ToString();
        }
    }
}
