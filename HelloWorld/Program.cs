using System.Runtime.InteropServices;

Console.WriteLine("Hello, World!");
Console.WriteLine($"Current time (UTC): {DateTime.UtcNow.ToLongTimeString()}");
Console.WriteLine($"Current architecture: {RuntimeInformation.OSArchitecture}");

string filename = "data.txt";
if (File.Exists(filename))
{
    var content = File.ReadAllText(filename);
    Console.WriteLine($"Found file with content: {content}");
} 
else
{
    Console.WriteLine("File not found, let's create it");
    File.WriteAllText(filename, $"This file was created with {RuntimeInformation.OSArchitecture} architecture");
}