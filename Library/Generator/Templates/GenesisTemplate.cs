using System;
using System.Collections.ObjectModel;
using System.Data.Common;
using System.IO;
using System.Linq;
using Genesis.Text;
using Genesis.Text.XML;

namespace Genesis.Generator.Templates;

public partial class GenesisTemplate 
{

    public string DatabaseName { get; set; }
    public string TableName { get; set; }
    protected string Namespace { get; set; }
    public ReadOnlyCollection<DbColumn> TableData { get; set; }


    public GenesisTemplate (string tableName, ReadOnlyCollection<DbColumn> data, string databasename)
    {
        this.TableData = data;
        this.TableName = tableName;
        this.DatabaseName = databasename;

        string baseDirectory = Directory.GetCurrentDirectory();
        string[] csprojFiles = Directory.GetFiles(baseDirectory, "*.csproj", SearchOption.AllDirectories);
        if (csprojFiles.Length > 0)
        {
            this.Namespace = Path.GetFileName(csprojFiles[0]).ToString().Split(".")[0];
        }
        else
        {
            Verbose.Danger("No .csproj file on this project");
            throw new Exception("");
        }
    }

    private string getDomainNamespace (string endNamespace) 
        => $"{this.Namespace}.Domain.{endNamespace};" ;

    private string getBaseNamespace()
    {
        string baseDirectory = Directory.GetCurrentDirectory();
        string[] csprojFiles = Directory.GetFiles(baseDirectory, "*.csproj", SearchOption.AllDirectories);

        foreach (var item in csprojFiles)  
            Console.WriteLine(item);
        
        XMLManipulator manipulator = new(csprojFiles[0]);
        var namespaceTagIfExists = manipulator.GetTagsByName("RootNamespace");

        if (namespaceTagIfExists.Count() > 0)
            return namespaceTagIfExists.First().Content.ToString();
        
        
        string projectName = Path.GetFileName(csprojFiles[0]).Split(".")[0];
        
        return TextManipulator.ToPascalCase(projectName);
    }
    
}