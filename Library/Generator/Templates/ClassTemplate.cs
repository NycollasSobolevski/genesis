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
        string @namespace = getDomainNamespace("Models");

        string tableName = TextManipulator.ToPascalCase(this.TableName);

        StringBuilder stringBuilder = new();
        stringBuilder.AppendLine("using Genesis.Domain.Models;");
        stringBuilder.AppendLine();
        stringBuilder.AppendLine($"namespace {@namespace}");
        stringBuilder.AppendLine();
        stringBuilder.AppendLine($$"""public partial class {{tableName}} : IEntity""");
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


    public string GetClassMap()
    {
        StringBuilder stringBuilder = new();
        string tableName = TextManipulator.ToPascalCase(this.TableName);

        stringBuilder.AppendLine($"using Microsoft.EntityFrameworkCore;\nusing Microsoft.EntityFrameworkCore.Metadata.Builders;\nusing TestArea.Domain.Models;\n");
        stringBuilder.AppendLine($"namespace {this.Namespace}.Core.Mapping;");
        stringBuilder.AppendLine();
        stringBuilder.AppendLine($"public class {tableName}ClassMap : IEntityTypeConfiguration<{tableName}>");
        stringBuilder.AppendLine("{");
        stringBuilder.AppendLine($"    public void Configure(EntityTypeBuilder<{tableName}> builder)");
        stringBuilder.AppendLine( "    {");
        stringBuilder.AppendLine($"        builder.HasKey(e => e.Id).HasName(\"PK____{tableName}\");\n");
        stringBuilder.AppendLine($"        builder.ToTable(\"{this.TableName}\");\n");



        foreach (var column in TableData)
        {
            stringBuilder.AppendLine($"        builder.Property(e => e.{TextManipulator.ToPascalCase(column.ColumnName)})");

            if(column.DataTypeName is "varchar" or "nvarchar" && column.ColumnSize != 2147483647)
                stringBuilder.AppendLine($"            .HasMaxLength({column.ColumnSize})");

            stringBuilder.AppendLine($"            .HasColumnName(\"{column.ColumnName}\");");
            stringBuilder.AppendLine();

            System.Console.WriteLine("----------------------------------------------");
            System.Console.WriteLine(column.AllowDBNull);
            System.Console.WriteLine(column.BaseCatalogName);
            System.Console.WriteLine(column.BaseColumnName);
            System.Console.WriteLine(column.BaseSchemaName);
            System.Console.WriteLine(column.BaseServerName);
            System.Console.WriteLine(column.BaseTableName);
            System.Console.WriteLine(column.ColumnName);
            System.Console.WriteLine(column.ColumnOrdinal);
            System.Console.WriteLine(column.ColumnSize);
            System.Console.WriteLine(column.DataType);
            System.Console.WriteLine(column.DataTypeName);
            System.Console.WriteLine(column.GetType());
            System.Console.WriteLine("----------------------------------------------");
        }

        stringBuilder.AppendLine( "    }");
        stringBuilder.AppendLine("}");
        stringBuilder.AppendLine();
        stringBuilder.AppendLine();


        return stringBuilder.ToString();
    }
}