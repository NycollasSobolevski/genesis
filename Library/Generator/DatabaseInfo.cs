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
        this.Catalog = values[2][1];
        this.StringConnection = stringConnection;
    }
}