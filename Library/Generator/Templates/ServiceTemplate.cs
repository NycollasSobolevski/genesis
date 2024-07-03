using System.Text;
using Genesis.Text;

namespace Genesis.Generator.Templates;

public partial class GenesisTemplate
{
    public string GetIServiceTemplate()
    {
        StringBuilder stringBuilder = new();
        string tableName = TextManipulator.ToPascalCase(this.TableName);

        stringBuilder.AppendLine("using Genesis.Domain.Services;");
        stringBuilder.AppendLine($"using {this.Namespace}.Domain.Models;");
        stringBuilder.AppendLine();
        stringBuilder.AppendLine($"namespace {this.Namespace}.Domain.Services;");
        stringBuilder.AppendLine();
        stringBuilder.Append("public interface I");
        stringBuilder.Append(tableName);
        stringBuilder.Append($$"""Service : IService<{{tableName}}>""");
        stringBuilder.AppendLine("\n{\n\n}");

        return stringBuilder.ToString();
    }
    public string GetServiceTemplate()
    {
        StringBuilder stringBuilder = new();
        string tableName = TextManipulator.ToPascalCase(this.TableName);

        stringBuilder.AppendLine("using Genesis.Core.Services;");
        stringBuilder.AppendLine("using Genesis.Core.Repositories;");
        stringBuilder.AppendLine($"using {this.Namespace}.Domain.Models;");
        stringBuilder.AppendLine($"using {this.Namespace}.Domain.Services;");
        stringBuilder.AppendLine();
        stringBuilder.AppendLine($"namespace {this.Namespace}.Core.Services;");
        stringBuilder.AppendLine();
        stringBuilder.Append("public class ");
        stringBuilder.Append(tableName);
        stringBuilder.AppendLine($$"""Service(BaseRepository<{{tableName}}> repository)""");
        stringBuilder.AppendLine($$"""    : BaseService<{{tableName}}> (repository), I{{tableName}}Service""");
        stringBuilder.AppendLine("{");
        stringBuilder.AppendLine("\n}");

        return stringBuilder.ToString();
    }
}