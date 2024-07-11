using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Diagnostics.SymbolStore;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;


public class XMLManipulator
{
    private string filePath { get; set; }

    private string[]? content { get; set; }

    public XMLManipulator(string path)
        => this.filePath = path;

    public async Task<string[]> ReadAsync()
    {
        if(!File.Exists(this.filePath))
            throw new FileNotFoundException();

        string[] lines = await File.ReadAllLinesAsync(this.filePath);
        this.content = lines;
        return lines;
    }

    public string toString()
    {
        StringBuilder builder = new();

        foreach (var item in this.content! )
            builder.AppendLine(item);
        
        return builder.ToString();
    }

    public List<Tag> GetPackages()
    {
        XElement root = XElement.Parse(toString());

        var itemGroups = root.Elements("ItemGroup");
        
        List<Tag> content = [];

        if(itemGroups != null)
        {
            var packages = itemGroups.Elements("PackageReference");

            foreach(var pack in packages)
            {
                string include = pack.Attribute("Include")?.Value!;
                string version = pack.Attribute("Version")?.Value!;
                
                content.Add(new(
                    "PackageReference", 
                    "", 
                    new(){
                        {"Include", include},
                        {"Version", version}
                }));
            }
        }

        return content;
    }

    public void AddTags(IEnumerable<Tag> content)
    {
        if(!File.Exists(this.filePath))
            throw new FileNotFoundException();

        XmlDocument xmlDoc = new();
        xmlDoc.Load(this.filePath);

        XmlNode main = xmlDoc.DocumentElement!;

        List<XmlElement> elements = [];

        foreach (var element in content)
        {
            XmlElement tag = xmlDoc.CreateElement(element.Name);
            foreach (var @params in element.Params)
                tag.SetAttribute(@params.Key, @params.Value);

            if(element.Content is string and not null) 
                tag.InnerText = element.Content.ToString()!;
            else if(element.Content is IEnumerable<Tag> and not null)
                foreach (var item in (IEnumerable<Tag>)element.Content)
                {
                    XmlElement child =  xmlDoc.CreateElement(item.Name);
                }
                
            main.AppendChild(tag);
        } 
        xmlDoc.Save(this.filePath);
    }


    public XmlElement TagToXml(XmlNode node, Tag tag)
    {
        
    }
}