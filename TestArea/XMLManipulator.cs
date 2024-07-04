using System.Collections;
using System.Collections.Generic;
using System.IO;
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
        
        var tags = getTagContent(new (lines));

        foreach (var item in tags)
        {
            
        }

        return content;
    }

    private string getTagName(string line)
    {
        string tag = line.Split(">")[0];
        tag = tag.TrimStart().Replace("<", "");
        return tag;
    }


    private List<Tag> getTagContent(List<string> lines)
    {
        // for (int i = 0; i < lines.Length; i++)
        // {
            int i = 2;
            string tagAttribute = getTagName(lines[i]);
            string tagName = tagAttribute.Split(" ")[0];
            int linesInnerTag = 0;
            List<List<Tag>> content = [];
            System.Console.WriteLine(tagName);
            for (int j = i; j < lines.Count; j++)
            {
                if(Regex.IsMatch(lines[j], $@"<\/{tagName}"))
                {
                    if(linesInnerTag == 0)
                    {
                        return [new(tagName, lines[j])];
                    }
                    else 
                    {
                        content.Add(getTagContent(lines.GetRange(i, linesInnerTag)));
                        return getTagContent(lines.GetRange(i, linesInnerTag));
                    }
                }
                linesInnerTag++;
            }
            throw new Exception("Invalid XML file ");
        // }
    }
}