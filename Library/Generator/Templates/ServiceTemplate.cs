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
        stringBuilder.Append($$"""Service : IService<{{tableName}}> {}""");

        return stringBuilder.ToString();
    }
}