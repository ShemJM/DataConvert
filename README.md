A c# console application for converting various data files to other types. For example CSV to JSON. 

Currently it just takes a CSV file and prints out a JSON string. 

I have tried to use this project as a way to practice Test Driven Development. So have been writing the Unit Tests and then writing the methods to pass those tests. 

As there is no set Types for the conversion, I have decided to first convert everything to JSON and then to the desired output type. So if the input is CSV and the user wants XML,
the app will first convert the CSV to JSON and then to XML. I figured that would make it easier to add new input and output types later on. 

I have used System.Text.Json for converting to JSON and NewtonSoft for the JSON to XML conversion.
