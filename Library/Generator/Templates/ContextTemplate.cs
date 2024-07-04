using System.Collections.Generic;
using System.Text;
using Genesis.Text;
using Microsoft.Identity.Client;

namespace Genesis.Generator.Templates;

public partial class GenesisTemplate 
{
    public string GetContext(List<string> tables, string stringConnection)
    {
        StringBuilder stringBuilder = new();
        string contextName = $"{this.DatabaseName}Context";

        stringBuilder.AppendLine($"using Microsoft.EntityFrameworkCore;\n");
        stringBuilder.AppendLine($"using {this.Namespace}.Core.Mapping;\n");
        stringBuilder.AppendLine($"using {this.Namespace}.Domain.Models;\n");
        stringBuilder.AppendLine($"namespace {this.Namespace}.Core;\n");
        stringBuilder.AppendLine($"public partial class {contextName} : DbContext");
        stringBuilder.AppendLine( "{");
        stringBuilder.AppendLine($$"""    public {{contextName}}() {}""");
        stringBuilder.AppendLine();
        stringBuilder.AppendLine($"    public {contextName}(DbContextOptions<{contextName}> options)");
        stringBuilder.AppendLine("         : base(options)");
        stringBuilder.AppendLine( "    {}");

        foreach (var entity in tables)
        {
            System.Console.WriteLine(entity);
            stringBuilder.AppendLine($$"""    public virtual DbSet<{{TextManipulator.ToPascalCase(entity)}}> {{TextManipulator.ToPascalCase(entity)}}List { get; set; }""");
        }
        
        stringBuilder.AppendLine( "    protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder)");
        stringBuilder.AppendLine( $"        => optionsBuilder.UseSqlServer(@\"{stringConnection}\");");

        stringBuilder.AppendLine( "    protected override void OnModelCreating(ModelBuilder modelBuilder)");
        stringBuilder.AppendLine( "    {");

        foreach (var entity in tables)
            stringBuilder.AppendLine($"        modelBuilder.ApplyConfiguration(new {TextManipulator.ToPascalCase(entity)}ClassMap());");

        stringBuilder.AppendLine( "        OnModelCreatingPartial(modelBuilder);");

        stringBuilder.AppendLine( "    }");

        stringBuilder.AppendLine( "    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);");

        stringBuilder.AppendLine( "}");
        
        return stringBuilder.ToString();
    }

    public string GetContextName ()
        => $"{this.DatabaseName}Context";
}
