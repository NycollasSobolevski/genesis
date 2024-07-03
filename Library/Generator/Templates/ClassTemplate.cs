using System;
using System.Collections.ObjectModel;
using System.Data.Common;
using System.IO;
using System.Text;
using Genesis.Converter;
using Genesis.Text;

namespace Genesis.Generator.Templates;

public partial class GenesisTemplate 
{
    public string GetClassTemplate( )
    {
        string @namespace = getNamespace("Models");

        string tableName = TextManipulator.ToPascalCase(this.TableName);

        StringBuilder stringBuilder = new();
        stringBuilder.AppendLine("using Genesis.Domain.Models;");
        stringBuilder.AppendLine();
        stringBuilder.AppendLine(@namespace);
        stringBuilder.AppendLine();
        stringBuilder.AppendLine($$"""public partial class {{tableName}} : TEntity""");
        stringBuilder.AppendLine("{");

        foreach (var item in this.TableData)
        {
            string columnName = TextManipulator.ToPascalCase(item.ColumnName);
            if(columnName == "Id")
                continue;
            string typeInNet = DataTypeConverter.GetNetType(item.DataTypeName).TypeInNet;
            stringBuilder.AppendLine($$"""  public {{typeInNet}}{{(item.AllowDBNull ?? false ? "?" : "")}} {{columnName}} { get; set; }""");
        }

        stringBuilder.AppendLine("}");
        return stringBuilder.ToString();
    }
}