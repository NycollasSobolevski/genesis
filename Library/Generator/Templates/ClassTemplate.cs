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
        stringBuilder.AppendLine($$"""
                                using Genesis.Domain.Models;

                                namespace {{@namespace}}
                                
                                public partial class {{tableName}} : IEntity, IConverter<{{tableName}}>
                                {
                                """);

        foreach (var item in this.TableData)
        {
            string columnName = TextManipulator.ToPascalCase(item.ColumnName);
            if(columnName == "Id")
                continue;
            string typeInNet = DataTypeConverter.GetNetType(item.DataTypeName).TypeInNet;
            stringBuilder.AppendLine($$"""    public {{typeInNet}}{{( item.AllowDBNull & typeInNet != "string" ?? false ? "?" : "")}} {{columnName}} { get; set; }""");
        }

        stringBuilder.AppendLine($$"""
                                       public {{tableName}} Convert()
                                           => this;
                                   """);

        stringBuilder.AppendLine("}");
        return stringBuilder.ToString();
    }


    public string GetClassMap()
    {
        StringBuilder stringBuilder = new();
        string tableName = TextManipulator.ToPascalCase(this.TableName);

        stringBuilder.AppendLine($$"""
                                  using Microsoft.EntityFrameworkCore;
                                  using Microsoft.EntityFrameworkCore.Metadata.Builders;
                                  using {{this.Namespace}}.Domain.Models;

                                  namespace {{this.Namespace}}.Core.Mapping;
                                  
                                  public class {{tableName}}ClassMap : IEntityTypeConfiguration<{{tableName}}>
                                  {
                                      public void Configure(EntityTypeBuilder<{{tableName}}> builder)
                                      {
                                          builder.HasKey(e => e.Id).HasName("PK____{{tableName}}");
                                          builder.ToTable("{{this.TableName}}");
                                  """);


        foreach (var column in TableData)
        {
            stringBuilder.AppendLine($"        builder.Property(e => e.{TextManipulator.ToPascalCase(column.ColumnName)})");

            if(column.DataTypeName is "varchar" or "nvarchar" && column.ColumnSize != 2147483647)
                stringBuilder.AppendLine($"            .HasMaxLength({column.ColumnSize})");

            stringBuilder.AppendLine($"            .HasColumnName(\"{column.ColumnName}\");\n");
        }

        stringBuilder.AppendLine( """
                                      }
                                  }
                                  """);

        return stringBuilder.ToString();
    }
}