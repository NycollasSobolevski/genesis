using System.Text;


public class Tag
{
    public string Name { get; set; }
    public Dictionary<string, string> Params { get; set; } = [];
    public object Content { get; set; } = "";
    public bool IsEndTree { get; set; }

    public Tag(string name)
        => this.Name = name;

    public Tag (string name, string? content, Dictionary<string, string>? @params)
    {
        this.Name = name;
        
        if( content is not null )
            this.Content = content;
        if( @params is not null )
            this.Params = @params;
        
        this.IsEndTree = true;
    }

    public Tag (string name, IEnumerable<Tag>? content, Dictionary<string, string>? @params)
    {
        this.Name = name;
        
        if( content is not null )
            this.Content = content;
        if( @params is not null )
            this.Params = @params;
        
        this.IsEndTree = false;
    }


    public override string ToString()
    {
        StringBuilder stBuilder = new();
        stBuilder.Append($"<{this.Name}");
        foreach (var item in this.Params)
            stBuilder.Append($""" {item.Key}="{item.Value}" """);
        if(this.Content.ToString() != "")
        {
            System.Console.WriteLine($"Content: {this.Content}");
            stBuilder.AppendLine($""">""");

            if(Content is IEnumerable<Tag>)
                foreach (var item in (IEnumerable<Tag>)this.Content )
                    stBuilder.AppendLine(item.ToString());
            else
                stBuilder.AppendLine($"""  {this.Content.ToString()}""");
            stBuilder.AppendLine($@"</{this.Name}>");
        }
        else
            stBuilder.Append(@"/>");
        
        return stBuilder.ToString();
    }

}