using System;
using System.Collections.ObjectModel;
using System.Data.Common;
using System.IO;
using Genesis.Text;

namespace Genesis.Generator.Templates;

public partial class GenesisTemplate 
{
    public static string GetClassTemplate(string tableName, ReadOnlyCollection<DbColumn> tableData )
    {
        string @namespace = GenesisTemplate.getNamesPace("Models");

        tableName = TextManipulator.ToPascalCase(tableName);

        string result = $$"""
        using Genesis.Domain.Models;

        {{@namespace}}

        public partial class {{tableName}} : IEntity
        {

        """;
        foreach (var item in tableData)
        {
            string columnName = TextManipulator.ToPascalCase(item.ColumnName);
            result += $$"""
                public {{item.DataType}}{{(item.AllowDBNull ?? false ? "?" : "")}} {{columnName}} { get; set; }
            """ ;           
            result += "\n";
        }

        result += "}";
        return result;
    }

    private static string getNamesPace (string endNamespace) 
    {
        string @namespace;
        string baseDirectory = Directory.GetCurrentDirectory();
        System.Console.WriteLine(baseDirectory);
        // string projectDirectory = Path.GetFullPath(Path.Combine(baseDirectory, @"..\..\..\"));
        string[] csprojFiles = Directory.GetFiles(baseDirectory, "*.csproj", SearchOption.AllDirectories);
        if (csprojFiles.Length > 0)
        {
            @namespace = Path.GetFileName(csprojFiles[0]).ToString().Split(".")[0];
        }
        else
        {
            Verbose.Danger("No .csproj file on this project");
            throw new Exception("");
        }
        @namespace = $"namespace {@namespace}.Domain.{endNamespace};" ;

        return @namespace;

    }

    private static string tableTypeConverter ()
    {
        return "";
    }
}