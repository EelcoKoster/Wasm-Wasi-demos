using System.Runtime.InteropServices;

Console.WriteLine("Content-Type: text/html\n");
Console.WriteLine("<h1>Wasm container using Spin in K8S!</h1>");
Console.WriteLine($"<p>Current time (UTC): {DateTime.UtcNow.ToLongTimeString()}</p>");
Console.WriteLine($"<p>Current architecture: {RuntimeInformation.OSArchitecture}</p>");
