using Microsoft.EntityFrameworkCore.Query.Internal;

namespace Genesis.Converter;

public class DataTypeStructure
{
    public string TypeInNet { get; set; }
    public string TypeInSql { get; set; }
    public bool UseImport { get; set; } = false;
    public string Import { get; set; }

    public DataTypeStructure(string sql, string net)
    {
        this.TypeInNet = net;
        this.TypeInSql = sql;
    }

    public DataTypeStructure(string sql, string net, string import)
    {
        this.TypeInNet = net;
        this.TypeInSql = sql;
        this.UseImport = true;
        this.Import = import;
    }
}