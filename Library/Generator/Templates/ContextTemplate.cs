using System.Collections.Generic;
using System.Text;
using Genesis.Text;

namespace Genesis.Generator.Templates;

public partial class GenesisTemplate 
{
    public string GetContext(List<string> tables, string stringConnection)
    {
        StringBuilder stringBuilder = new();
        string contextName = $"{this.DatabaseName}Context";

        stringBuilder.AppendLine($$"""
                                using Microsoft.EntityFrameworkCore; 
                                using Genesis.Domain.Models;
                                using {{this.Namespace}}.Core.Mapping;
                                using {{ this.Namespace}}.Domain.Models;

                                namespace {{this.Namespace}}.Core;

                                public partial class {{contextName}} : DbContext
                                {
                                    public {{contextName}}() {}
                                    
                                    public {{contextName}}(DbContextOptions<{{contextName}}> options)
                                        : base(options)
                                    {}

                                """);

        foreach (var entity in tables)
        {
            System.Console.WriteLine(entity);
            stringBuilder.AppendLine($$"""    public virtual DbSet<{{TextManipulator.ToPascalCase(entity)}}> {{TextManipulator.ToPascalCase(entity)}}List { get; set; }""");
        }

        stringBuilder.AppendLine($$"""    

                                       protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder)
                                           => optionsBuilder.UseSqlServer(@"{{stringConnection}}");

                                       protected override void OnModelCreating(ModelBuilder modelBuilder)
                                       {

                                   """);

        foreach (var entity in tables)
            stringBuilder.AppendLine($"        modelBuilder.ApplyConfiguration(new {TextManipulator.ToPascalCase(entity)}ClassMap());");

        stringBuilder.AppendLine("""

                                           OnModelCreatingPartial(modelBuilder);
                                       }
                                       partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

                                       public override int SaveChanges()
                                       {
                                           foreach(var entry in ChangeTracker.Entries())
                                           {
                                               if(entry.State == EntityState.Deleted && entry.Entity is ISoftDeleted deleted)
                                               {
                                                   entry.State = EntityState.Modified;
                                                   deleted.DeletedAt = DateTime.Now;
                                               }
                                           }
                                           return base.SaveChanges();
                                       }
                                   }
                                   """);
        
        return stringBuilder.ToString();
    }

    public string GetContextName ()
        => $"{this.DatabaseName}Context";
}
