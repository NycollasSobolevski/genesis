using System.Collections.Generic;

namespace Genesis.Generator;

public interface NugetPackageVersions
{
    public IEnumerable<string> Versions {get;set;}
}