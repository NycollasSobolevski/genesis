using System.Text;
using Genesis.Text;

namespace Genesis.Generator.Templates;

public partial class GenesisTemplate
{
    public string GetIRepositoryTemplate()
    {
        StringBuilder stringBuilder = new();
        string tableName = TextManipulator.ToPascalCase(this.TableName);

        stringBuilder.AppendLine("using Genesis.Domain.Repositories;");
        stringBuilder.AppendLine($"using {this.Namespace}.Domain.Models;");
        stringBuilder.AppendLine();
        stringBuilder.AppendLine($"namespace {this.Namespace}.Domain.Repositories;");
        stringBuilder.AppendLine();
        stringBuilder.Append("public interface I");
        stringBuilder.Append(tableName);
        stringBuilder.Append($$"""Repository : IRepository<{{tableName}}> {}""");

        return stringBuilder.ToString();
    }
}