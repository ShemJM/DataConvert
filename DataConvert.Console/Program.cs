// See https://aka.ms/new-console-template for more information
using DataConvert.Application;
using System.Linq;

InputTypes selectedInput;
OutputTypes selectedOutput;
string filePath;

Console.WriteLine("Please select an Input type");
foreach (var inputType in Enum.GetValues(typeof(InputTypes)))
{
    Console.WriteLine($"{(int)inputType}) {inputType.ToString()}");
}

switch (Console.ReadLine())
{
    case "0":
        selectedInput = InputTypes.CSV;
        Console.WriteLine("Please enter path of the csv file:");
        filePath = Console.ReadLine();
        break;
    default:
        throw new NotImplementedException();
}

Console.WriteLine("Please select an Output type");

foreach (var outputType in Enum.GetValues(typeof(OutputTypes)))
{
    Console.WriteLine($"{(int)outputType}) {outputType.ToString()}");
}

switch (Console.ReadLine())
{
    case "0":
        selectedOutput = OutputTypes.JSON;
        break;
    case "1":
        selectedOutput = OutputTypes.XML;
        break;
    default:
        throw new NotImplementedException();
}

if (File.Exists(filePath))
    Console.WriteLine(DataConverter.ProcessInput(filePath, selectedInput, selectedOutput));