using System.Collections.Generic;

namespace Genesis.Converter;

public class DataTypeConverter
{
    private static Dictionary<string, string> types = new (){
        { "bigint", "Int64" },
        { "binary", "Byte[]" },
        { "bit", "Boolean" },
        { "char", "String" },
        { "date", "DateTime" },
        { "datetime", "DateTime" },
        { "datetime2", "DateTime" },
        { "datetimeoffset", "DateTimeOffset" },
        { "decimal", "Decimal" },
        { "FILESTREAM attribute (varbinary(max))", "Byte[]" },
        { "float", "Double" },
        { "image", "Byte[]" },
        { "int", "Int32" },
        { "money", "Decimal" },
        { "nchar", "String" },
        { "ntext", "String" },
        { "numeric", "Decimal" },
        { "nvarchar", "String" },
        { "real", "Single" },
        { "rowversion", "Byte[]" },
        { "smalldatetime", "DateTime" },
        { "smallint", "Int16" },
        { "smallmoney", "Decimal" },
        { "sql_variant", "Object" },
        { "text", "String" },
        { "time", "TimeSpan" },
        { "timestamp", "Byte[]" },
        { "tinyint", "Byte" },
        { "uniqueidentifier", "Guid" },
        { "varbinary", "Byte[]" },
        { "varchar", "String" },
        { "xml", "Xml" }
    };

    public static string GetNetType (string type) 
        => types[type];
    
}