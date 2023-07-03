using System.Runtime.InteropServices;

Console.WriteLine("Content-Type: text/html\n");

Console.WriteLine("<h1>Hello, Wasm!</h1>");
Console.WriteLine($"<p>Current time (UTC): {DateTime.UtcNow.ToLongTimeString()}</p>");
Console.WriteLine($"<p>Current architecture: {RuntimeInformation.OSArchitecture}</p>");

if (File.Exists("test.txt"))
{
    var content = File.ReadAllText("test.txt");
    Console.WriteLine(content);
} 
else
{
    Console.WriteLine("Not found");
}

File.WriteAllText("test.txt", $"Created (UTC): {DateTime.UtcNow.ToLongTimeString()}");