using IdentityModel.Client;
// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello, World!");


// discover endpoints from metadata
var client = new HttpClient();
var disco = await client.GetDiscoveryDocumentAsync("https://localhost:5001");
if (disco.IsError)
{
    Console.WriteLine(disco.Error);
}
else
{
    Console.WriteLine(disco.ToString());
}


Console.WriteLine("End");
Console.ReadLine();