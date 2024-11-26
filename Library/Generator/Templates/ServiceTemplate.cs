using System.Text;
using Genesis.Text;

namespace Genesis.Generator.Templates;

public partial class GenesisTemplate
{
    public string GetIServiceTemplate()
    {
        StringBuilder stringBuilder = new();
        string tableName = TextManipulator.ToPascalCase(this.TableName);

        stringBuilder.AppendLine($$"""
                                   using Genesis.Domain.Services;
                                   using {{this.Namespace}}.Domain.Models;

                                   namespace {{this.Namespace}}.Domain.Services;
                                   
                                   public interface I{{tableName}}Service : IService<{{tableName}}> { }
                                   """);

        return stringBuilder.ToString();
    }
    public string GetServiceTemplate()
    {
        StringBuilder stringBuilder = new();
        string tableName = TextManipulator.ToPascalCase(this.TableName);

        stringBuilder.AppendLine($$"""
                                   using Genesis.Core.Services;
                                   using Genesis.Core.Repositories;
                                   using {{this.Namespace}}.Domain.Models;
                                   using {{this.Namespace}}.Domain.Services;
                                   
                                   namespace {{this.Namespace}}.Core.Services;
                                   
                                   public class {{tableName}}Service(BaseRepository<{{tableName}}> repository)
                                       : BaseService<{{tableName}}> (repository), I{{tableName}}Service
                                   { }
                                   """);

        return stringBuilder.ToString();
    }
}