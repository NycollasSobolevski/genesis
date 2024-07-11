using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Genesis.Text.XML;

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
        
        for (int i = 0; i < lines.Length; i++)
        {
            string tagName = getTagName(lines[i]);
            // 
            for (int j = i; j < lines.Length; j++)
            {
                
            }
        }

        return content;
    }

    private string getTagName(string line)
    {


        return " tagSplited[0];";
    }
}