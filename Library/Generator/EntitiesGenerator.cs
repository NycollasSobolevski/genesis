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
    public EntitiesGenerator(string name, ReadOnlyCollection<DbColumn> entityData, string catalog)
    {
        this.EntityName = name;
        this.EntityData = entityData;
        this.template   = new(this.EntityName, this.EntityData, catalog);
    }

    public void GenerateEntity()
    {
        try
        {

            string filename = $"{EntityName}.cs";
            string baseDirectory = Directory.GetCurrentDirectory();
            string directory = @$"\Domain\{EntityName}\Models\{filename}";    
            directory = baseDirectory + directory;

            string classTemplate = template.GetClassTemplate();

            Verbose.Info($"Creating {filename} file");
            File.WriteAllText(directory, classTemplate);
            Verbose.Success("File created successfuly");

        } catch (Exception e) 
        {
            Verbose.Danger($"Error on create file {this.EntityName}.cs\n {e}");
        }
    }
    public void GenerateRepositoryInterface()
    {
        string filename = $"I{EntityName}Repository.cs";
        string baseDirectory = Directory.GetCurrentDirectory();
        string directory = @$"\Domain\{EntityName}\Repositories\{filename}";    
        try
        {
            directory = baseDirectory + directory;

            string template = this.template.GetIRepositoryTemplate();

            Verbose.Info($"Creating {filename} file");
            File.WriteAllText(directory, template);

            Verbose.Success("File created successfuly");
        } catch (Exception e) {
            Verbose.Danger($"Error on create file \"{directory}\"\n {e}");
        }
    }
    public void GenerateRepository()
    {
        string filename = $"{EntityName}Repository.cs";
        string baseDirectory = Directory.GetCurrentDirectory();
        string directory = @$"\Core\{EntityName}\Repository\{filename}";
        try
        {
            directory = baseDirectory + directory;
            string template = this.template.GetRepositoryTemplate();

            Verbose.Info($"Creating {filename} file");
            File.WriteAllText(directory, template);

            Verbose.Success("File created successfuly");
        } catch (Exception e) {
            Verbose.Danger($"Error on create file \"{directory}\"\n {e}");
        }
    }
    public void GenerateServiceInterface()
    {
        string filename = $"I{EntityName}Service.cs";
        string baseDirectory = Directory.GetCurrentDirectory();
        string directory = @$"\Domain\{EntityName}\Services\{filename}";    
        try
        {
            directory = baseDirectory + directory;
            string template = this.template.GetIServiceTemplate();

            Verbose.Info($"Creating {filename} file");
            File.WriteAllText(directory, template);

            Verbose.Success("File created successfuly");
        } catch (Exception e) {
            Verbose.Danger($"Error on create file \"{directory}\"\n {e}");
        }
    }
    public void GenerateService()
    {
        string baseDirectory = Directory.GetCurrentDirectory();
        string filename = $"{EntityName}Service.cs";
        string directory = @$"\Core\{EntityName}\Service\{filename}";    
        try
        {
            directory = baseDirectory + directory;
            string template = this.template.GetServiceTemplate();

            Verbose.Info($"Creating {filename} file");
            File.WriteAllText(directory, template);

            Verbose.Success("File created successfuly");
        } catch (Exception e) {
            Verbose.Danger($"Error on create file \"{directory}\"\n {e}");
        }
    }
    public void GenerateClassMap()
    {
        string baseDirectory = Directory.GetCurrentDirectory();
        string directory = @$"\Core\{EntityName}\Mapping\{EntityName}ClassMap.cs";    
        try
        {
            directory = baseDirectory + directory;
            string template = this.template.GetClassMap();

            Verbose.Info($"Creating {this.EntityName} file");
            File.WriteAllText(directory, template);

            Verbose.Success("File created successfuly");
        } catch (Exception e) {
            Verbose.Danger($"Error on create file \"{directory}\"\n {e}");
        }
    }
    
}