using System.Text;


public class Tag
{
    public string Name { get; set; }
    public string[]? Params { get; set; } 
    public object? Content { get; set; }
    public bool IsEndTree { get; set; }

    public Tag (string name, string content)
    {
        this.Name = name;
        this.Content = content;
        this.IsEndTree = true;
    }

    public Tag (string name, string[] _params)
    {
        this.Name = name;
        this.Params = _params;
        this.IsEndTree = true;
    }

    public Tag (string name, IEnumerable<Tag> content)
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