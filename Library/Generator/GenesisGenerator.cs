using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Common;
using System.IO;
using Genesis.Generator.Templates;
using Genesis.Text;
using Microsoft.Data.SqlClient;

namespace Genesis.Generator;

public class GenesisGenerator
{
    public string ConnectionString {get;set;}

    public GenesisGenerator(string connectionString)
    {
        this.ConnectionString = connectionString;
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
                tables.Add(reader[0].ToString());
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

            string selectTables = $"select top 1 * from {table}";

            using SqlCommand command = new(selectTables, connection);
            using SqlDataReader reader = command.ExecuteReader();
            var schema = reader.GetColumnSchema();
            
            return schema;
        }
        catch( Exception e )
        {

            Verbose.Danger("error on Connection");
            Verbose.Danger(e);
            throw new Exception();
        }
    }

    private void GenerateClass(DbColumn data)
    {

    }

    public void GenerateCode()
    {
        var entities = GetEntities();
        
        string tableName = TextManipulator.ToPascalCase(entities[1]);
        var tabledata = GetTableData(tableName);
        string sla = GenesisTemplate.GetClassTemplate(tableName, tabledata);
        GenerateTreeByEntity(tableName);
        EntitiesGenerator ent = new(tableName, sla);
        ent.GenerateEntity();

    }


    public void GenerateTreeByEntity(string entity)
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

    public void GenerateBaseFiles()
    {
        string baseDirectory = Directory.GetCurrentDirectory();
        string[] paths = [@"\Core", @"\Domain"];

        foreach (var path in paths)
            Directory.CreateDirectory(baseDirectory + path);

        
    }
}