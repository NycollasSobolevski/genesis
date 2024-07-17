using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Genesis.Generator;

public class NugetPackageVersions
{
    [JsonPropertyName("versions")]
    public IEnumerable<string> Versions {get;set;}
}