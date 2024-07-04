using System.Collections.Generic;
using System.Linq;

namespace Genesis.Generator.Database;

public class DatabaseInfo
{
    public string DataSource { get; set; }
    public string Catalog { get; set; }
    public string StringConnection { get; private set; }

    public DatabaseInfo( string stringConnection)
    {
        List<string[]> values = stringConnection.Split(";")
            .Select( item => item.Split("="))
            .ToList();

        this.DataSource = values[0][1];
        this.Catalog = values[1][1];

        System.Console.WriteLine($"Source={DataSource}");
        System.Console.WriteLine($"Catalog={Catalog}");
        System.Console.WriteLine($"Connection={StringConnection}");

        this.StringConnection = stringConnection;
    }
}