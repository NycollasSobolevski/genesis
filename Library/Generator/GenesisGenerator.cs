using System;
using System.Collections.Generic;
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
            if(Verbose.Level > 0)
                System.Console.WriteLine("Getting Tables...");

            connection.Open();

            if(Verbose.Level > 0)
                System.Console.WriteLine("Conection successfully!");

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
            System.Console.WriteLine(e);
            throw new Exception();
        }
    }

    public void GetTables()
    {

    }

    public void GenerateCode()
    {
        var entities = GetEntities();

        foreach (var item in entities)
        {
            System.Console.WriteLine(item);    
        }
    }

}