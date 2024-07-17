using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Genesis.Generator.Database;
using Genesis.Generator.Templates;
using Genesis.Text;
using Genesis.Text.XML;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;

namespace Genesis.Generator;

public partial class GenesisGenerator
{
    public string ConnectionString {get;set;}

    public GenesisGenerator(string connectionString)
    {
        this.ConnectionString = connectionString;
    }

    public void GenerateCode()
    {
        try{
            DatabaseInfo dbInfo = new(this.ConnectionString);
            var entities = GetEntities();
            TreeGenerator.GenerateBaseTree();
            ContextGenerator ctxGenerator = new(dbInfo);
            ctxGenerator.GenerateContext(entities);

            foreach (var tableName in entities)
            {
                TreeGenerator.GenerateTreeByEntity(tableName);
                
                var tabledata = GetTableData(tableName);

                EntitiesGenerator generator = new(tableName, tabledata, dbInfo.Catalog);
                generator.GenerateEntity();
                generator.GenerateClassMap();
                generator.GenerateRepositoryInterface();
                generator.GenerateServiceInterface();
                generator.GenerateRepository();
                generator.GenerateService();
            }

            AddGenesisToProject().Wait();

        } catch(Exception e) {
            Verbose.Danger($"Error on generate context\n {e}");
        }
    }

    public List<string> GetEntities()
    {
        using SqlConnection connection = new (this.ConnectionString);
        List<string> tables = [];
        try
        {
            Verbose.Info("Getting Tables...");

            connection.Open();

            Verbose.Success("Conection successfully!");

            string selectTables = "select * from sys.tables";

            using SqlCommand command = new(selectTables, connection);
            using SqlDataReader reader = command.ExecuteReader();
            while(reader.Read())
            {
                string table = reader[0].ToString();
                if(table is "__EFMigrationsHistory" or "sysdiagrams")
                    continue;

                tables.Add(table);
            }

            return tables;
        }
        catch( Exception e )
        {
            Verbose.Danger(e);
            throw new Exception();
        }
    }

    public ReadOnlyCollection<DbColumn> GetTableData(string table)
    {

        using SqlConnection connection = new (this.ConnectionString);
        try
        {
            Verbose.Info($"Connecting on table [{table}]...");

            connection.Open();

            Verbose.Success("Conection successfully!");

            string selectTables = $"select top 1 * from [{table}]";

            using SqlCommand command = new(selectTables, connection);
            using SqlDataReader reader = command.ExecuteReader();
            var schema = reader.GetColumnSchema();

            return schema;
        }
        catch( Exception e )
        {
            Verbose.Danger("error on Connection");
            Verbose.Danger(e);
            Environment.Exit(0);
            throw new Exception();
        }
    }  

    public async static Task AddGenesisToProject()
    {
        string path = GetProjectPath();
        XMLManipulator manipulator = new(path);
        await manipulator.ReadAsync();

        string latestVersion = await GetLatestVersion();

        bool hasPakcage = manipulator.VerifyPackageReference("AspNetCore.Genesis", latestVersion);
        System.Console.WriteLine($"Pagckage reference exists: {hasPakcage}");

        if(hasPakcage)
            return;

        List<Tag> newPackages = [
            new(
                "PackageReference",
                "",
                new(){
                    {"Include","AspNetCore.Genesis"},
                    {"Version", latestVersion}
                }
            )
        ];

        Tag itemgroup = new("ItemGroup", newPackages, null);
        manipulator.AddTags([itemgroup]);
    }

    public static string GetProjectPath ()
    {
        string baseDirectory = Directory.GetCurrentDirectory();
        string pattern = @"\.csproj$";
        var files = Directory.GetFiles(baseDirectory);
        string projFile = files.First(f => Regex.IsMatch(f, pattern)).Replace("./","");
        projFile = Path.Combine(baseDirectory, projFile);
        
        System.Console.WriteLine($"Project: {projFile}");

        return projFile;
    }

    public static async Task<string> GetLatestVersion()
    {
        string url = @"https://api.nuget.org/v3-flatcontainer/aspnetcore.genesis/index.json";
        var proxy = new WebProxy
        {
            Address = new Uri("http://10.224.200.26:8080"),
            BypassProxyOnLocal = false,
            UseDefaultCredentials = false,
            Credentials = new NetworkCredential(
                userName: "disrct",
                password: "etsps2024401"
            )
        };

        var httpClientHandler = new HttpClientHandler
        {
            Proxy = proxy,
            PreAuthenticate = true,
            UseDefaultCredentials = false
        };
        using HttpClient client = new(httpClientHandler);

        HttpResponseMessage response;   
        response = await client.GetAsync(url);

        var responseContent = await response.Content.ReadAsStringAsync();

        var content = JsonSerializer.Deserialize<NugetPackageVersions>(responseContent);

        return content.Versions.Last();
    }

}