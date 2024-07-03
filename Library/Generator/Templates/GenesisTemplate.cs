using System;
using System.Collections.ObjectModel;
using System.Data.Common;
using System.IO;

namespace Genesis.Generator.Templates;

public partial class GenesisTemplate 
{

    public string TableName { get; set; }
    protected string Namespace { get; set; }
    public ReadOnlyCollection<DbColumn> TableData { get; set; }


    public GenesisTemplate (string tableName, ReadOnlyCollection<DbColumn> data)
    {
        this.TableData = data;
        this.TableName = tableName;

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