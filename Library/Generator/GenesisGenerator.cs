using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Common;
using Genesis.Generator.Templates;
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
        var tabledata = GetTableData(entities[1]);
        string sla = GenesisTemplate.GetClassTemplate(entities[1], tabledata);
        System.Console.WriteLine(sla);
    }

}