using System.IO;

namespace Genesis.Generator;

public class EntitiesGenerator
{
    public string EntityName {get;set;}
    public string Template {get;set;}
    public EntitiesGenerator(string name, string template)
    {
        this.EntityName = name;
        this.Template = template;
    }

    public void GenerateEntity()
    {
        string baseDirectory = Directory.GetCurrentDirectory();
        string directory = @$"\Domain\{EntityName}\Models\{EntityName}.cs";    
        directory = baseDirectory + directory;

        File.WriteAllText(directory, this.Template);

        Verbose.Info($"Creating {EntityName} file");
        Verbose.Info(directory);
    }
}