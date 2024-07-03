using System;
using System.Collections.ObjectModel;
using System.Data.Common;
using System.IO;
using Genesis.Generator.Templates;

namespace Genesis.Generator;

public class EntitiesGenerator
{
    public string EntityName { get; set; }
    public ReadOnlyCollection<DbColumn> EntityData { get; set; }
    private GenesisTemplate template { get; set; }
    public EntitiesGenerator(string name, ReadOnlyCollection<DbColumn> template)
    {
        this.EntityName = name;
        this.EntityData = template;
        this.template   = new(this.EntityName, this.EntityData);

    }

    public void GenerateEntity()
    {
        string baseDirectory = Directory.GetCurrentDirectory();
        string directory = @$"\Domain\{EntityName}\Models\{EntityName}.cs";    
        directory = baseDirectory + directory;

        string classTemplate = template.GetClassTemplate();

        File.WriteAllText(directory, classTemplate);

        Verbose.Info($"Creating {EntityName} file");
        Verbose.Info(directory);
    }


    public void GenerateRepositoryInterface()
    {
        // try
        // {
        //     string baseDirectory = Directory.GetCurrentDirectory();
        //     string directory = @$"\Domain\{EntityName}\Repositories\I{EntityName}Repository.cs";    
        //     directory = baseDirectory + directory;
        //     Verbose.Info($"Creating {this.EntityName} file");

        //     File.WriteAllText(directory, this.Template);

        //     Verbose.Info(this.EntityName);
        // } catch (Exception e) {
        //     Verbose.Danger($"Error on create file {this.EntityName}.cs");
        // }
    }
}