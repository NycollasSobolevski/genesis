using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


public class XMLManipulator
{
    private string filePath { get; set; }

    public XMLManipulator(){}
    public XMLManipulator(string path)
        => this.filePath = path;

    public async Task<IEnumerable<Tag>> ReadAsync()
    {
        if(!File.Exists(this.filePath))
            throw new FileNotFoundException();

        List<Tag> content = [];

        string[] lines = await File.ReadAllLinesAsync(this.filePath);
        

        var sla = getTagContent(new(lines));

        string xmlPatern = @"<[^>]+>[^<]*<\/[^>]+>";

        string[] contents = sla.Content.ToString().Split("<");

        foreach (Match match in Regex.Matches(sla.Content, xmlPatern))
        {
            System.Console.WriteLine(match);
        }

        return content;
    }

    private string getTagName(string line)
    {
        string tag = line.Split(">")[0];
        tag = tag.TrimStart().Replace("<", "");
        return tag;
    }

    private Tag getTagContent(List<string> lines)
    {
        int i = 0;
        string tagString = lines[i];
        string name = getTagName(tagString);
        StringBuilder content = new();

        int linesInContent = 0;
        for (int j = i; j < lines.Count; j++)
        {
            if(Regex.IsMatch(lines[j], $@"</{name}"))
            {
                if(linesInContent == 0)
                    content.Append(tagString.Split(">")[1].Split(@"</")[0]);
                break;
            }
            content.Append(lines[j]);
        }

        return new(name, content.ToString());
    }

    private int getEndOfTag(int start, string[] content)
    {
        return 0;
    }
}