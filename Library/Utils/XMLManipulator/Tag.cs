using System.Text;

namespace Genesis.Text.XML;

public class Tag
{
    public string Name { get; set; }
    public object Content { get; set; }
    public bool IsEndTree { get; set; }

    public Tag (string name, string content)
    {
        this.Name = name;
        this.Content = content;
        this.IsEndTree = true;
    }

    public Tag (string name, Tag content)
    {
        this.Name = name;
        this.Content = content;
        this.IsEndTree = false;
    }

    public override string ToString()
    {
        StringBuilder stBuilder = new();
        stBuilder.AppendLine($"<{this.Name}>");
        stBuilder.AppendLine($"""  {this.Content}""");
        stBuilder.AppendLine($@"<\{this.Name}>");
        return stBuilder.ToString();
    }
}