using Genesis.Generator;
var gns = await GenesisGenerator.GetLatestVersion();
System.Console.WriteLine("gns");
System.Console.WriteLine(gns);


// using System.Net;

// string url = @"https://api.nuget.org/v3-flatcontainer/aspnetcore.genesis/index.json";
// // string url = @"https://api.nuget.org/v3/registration5-semver1/aspnetcore.genesis/index.json";
// var proxy = new WebProxy
// {
//     Address = new Uri("http://10.224.200.26:8080"),
//     BypassProxyOnLocal = false,
//     UseDefaultCredentials = false,
//     Credentials = new NetworkCredential(
//         userName: "disrct",
//         password: "etsps2024401"
//     )
// };

// var httpClientHandler = new HttpClientHandler
// {
//     Proxy = proxy,
//     PreAuthenticate = true,
//     UseDefaultCredentials = false
// };
// using HttpClient client = new(httpClientHandler);

// HttpResponseMessage response;   
// response = await client.GetAsync(url);
// System.Console.WriteLine(response.StatusCode);

// var hea = response.RequestMessage;
// System.Console.WriteLine(await response.Content.ReadAsStringAsync());