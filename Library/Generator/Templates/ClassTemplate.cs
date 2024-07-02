using System;
using System.Collections.ObjectModel;
using System.Data.Common;
using System.IO;
using System.Reflection;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;

namespace Genesis.Generator.Templates;

public partial class GenesisTemplate 
{
    public static string GetClassTemplate(string tableName, ReadOnlyCollection<DbColumn> tableData )
    {
        string @namespace = GenesisTemplate.getNamesPace("Model");

        string result = $$"""
        {{@namespace}}
        public partial class {{tableName}}
        {
            
        
        """;



        result += "}";
        return result;
    }

    private static string getNamesPace (string endNamespace) 
    {
        string @namespace;
        string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
        string projectDirectory = Path.GetFullPath(Path.Combine(baseDirectory, @"..\..\..\"));
        string[] csprojFiles = Directory.GetFiles(projectDirectory, "*.csproj", SearchOption.AllDirectories);
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