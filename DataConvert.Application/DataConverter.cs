using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConvert.Application
{
    public class DataConverter
    {
        public static string ProcessInput(string filePath, InputTypes inputType, OutputTypes outputType)
        {
            string result = string.Empty;
            switch (inputType)
            {
                case InputTypes.CSV:
                    using (var testCsvStream = File.Open(filePath, FileMode.Open))
                    {
                        using (var sr = new StreamReader(testCsvStream))
                        {
                            string csvText = sr.ReadToEnd();
                            result = CSVConverter.ConvertToJsonString(csvText);
                            
                        };
                    }
                    break;
            }

            return result;
        }
    }
}