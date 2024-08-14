using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using Genesis.Exceptions.Configurator;

namespace Genesis.Configurator;

public class GenesisConfigurator
{
    private string defaultConfigurationPath { get; set; }

    public GenesisConfigurator()
    {
        SetDefaultPath();
    }

    public GenesisConfigurator(string path)
    {
        SetDefaultPath(path);
    }
    
    public void SetDefaultPath(string path = null)
    {
        if (path != null)
        {
            this.defaultConfigurationPath = path;
            return;
        }
        path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        path += @"\Genesis\config";
        this.defaultConfigurationPath = path;
    }

    public bool FileExists()
        => File.Exists(this.defaultConfigurationPath);


    private Dictionary<string, string> getItem(string key)
    {
        var lines = File.ReadLines(this.defaultConfigurationPath);
        string select;
        foreach (var line in lines) 
        {
            if (line.StartsWith("//"))
                continue;

            var content = line.Split(':');
            content[0] = content[0].Replace(" ", "");
            if (content[0] == key)
            {
                Dictionary<string, string> res = new()
                {
                    { content[0], content[1] }
                };
                
                return res;
            }
        }

        throw new ConfigurationKeyNotFound();
    }

    private void setItem(string key, string value)
    {
        var lines = File.ReadLines(this.defaultConfigurationPath).ToList();
        lines.Add($"{key}: {value}");
        
        using StreamWriter writer = new(this.defaultConfigurationPath);
        foreach (var line in lines)
            writer.WriteLine(line);
        
        //! parei aqui
    }
}