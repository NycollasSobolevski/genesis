using System;
using System.Collections.ObjectModel;
using System.Data.Common;
using System.IO;

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

}