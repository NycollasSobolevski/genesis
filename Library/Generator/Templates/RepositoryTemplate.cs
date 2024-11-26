using System.Text;
using Genesis.Text;

namespace Genesis.Generator.Templates;

public partial class GenesisTemplate
{
    public string GetIRepositoryTemplate()
    {
        StringBuilder stringBuilder = new();
        string tableName = TextManipulator.ToPascalCase(this.TableName);

        stringBuilder.AppendLine($$"""
                                 using Genesis.Domain.Repositories;
                                 using {{this.Namespace}}.Domain.Models;

                                 namespace {{this.Namespace}}.Domain.Repositories;

                                 public interface I{{tableName}}Repository : IRepository<{{tableName}}> { }

                                 """);

        return stringBuilder.ToString();
    }

    public string GetRepositoryTemplate()
    {
        StringBuilder stringBuilder = new();
        string tableName = TextManipulator.ToPascalCase(this.TableName);

        stringBuilder.AppendLine($$"""
                                   using Genesis.Core.Repositories;
                                   using {{this.Namespace}}.Domain.Repositories;
                                   using {{this.Namespace}}.Domain.Models;

                                   namespace {{this.Namespace}}.Core.Repositories;
                                   public class {{tableName}}Repository({{ this.GetContextName() }} context) 
                                       : BaseRepository<{{tableName}}> (context), I{{tableName}}Repository
                                   {}
                                   """);

        return stringBuilder.ToString();
    }
}