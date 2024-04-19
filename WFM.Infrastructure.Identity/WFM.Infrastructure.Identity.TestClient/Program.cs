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


Console.WriteLine("End disco");

var tokenResponse = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
{
    Address = disco.TokenEndpoint,
    ClientId = "wfmTestApiClient",
    ClientSecret = "secret",
    Scope = "apiWFM"
});

if (tokenResponse.IsError)
{
    Console.WriteLine(tokenResponse.Error);
    Console.WriteLine(tokenResponse.ErrorDescription);
    return;
}
else
{
    Console.WriteLine("token ok");
}

Console.WriteLine(tokenResponse.AccessToken);

Console.WriteLine("End");
Console.ReadLine();