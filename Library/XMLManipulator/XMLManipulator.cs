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


namespace Genesis.Text.XML;

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

        foreach (var element in content)
            main.AppendChild( TagToXml(xmlDoc, element));

        xmlDoc.Save(this.filePath);
    }

    public static XmlElement TagToXml(XmlDocument doc, Tag tag)
    {
        XmlElement element = doc.CreateElement(tag.Name);

        foreach (var param in tag.Params)
            element.SetAttribute(param.Key, param.Value);

        if (tag.Content is string and not "")
            element.InnerText = (string)tag.Content;
        else if (tag.Content is IEnumerable<Tag> tags)
            foreach (var childTag in tags)
                element.AppendChild(TagToXml(doc, childTag));
        return element;
    }

    public bool VerifyPackageReference(string include, string version)
    {
        var packages = this.GetPackages();

        foreach (var item in packages)
            if(item.Params["Include"] == include)
                if(item.Params["Version"] == version)
                    return true;

        return false;
    }

}