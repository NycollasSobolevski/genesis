using System.IO;

namespace Genesis.Generator;

public class TreeGenerator
{
    public static void GenerateTreeByEntity(string entity)
    {
        string baseDirectory = Directory.GetCurrentDirectory();
        string[] directories = [
            @$"{baseDirectory}\Domain\{entity}\Models",
            @$"{baseDirectory}\Domain\{entity}\Repositories",
            @$"{baseDirectory}\Domain\{entity}\Services",
            @$"{baseDirectory}\Core\{entity}\Mapping\",
            @$"{baseDirectory}\Core\{entity}\Repository",
            @$"{baseDirectory}\Core\{entity}\Service",
        ];
        foreach (var path in directories)
        {
            if(Directory.Exists(path))
                continue;

            Directory.CreateDirectory(path);
        }
    }
}