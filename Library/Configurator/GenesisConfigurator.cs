using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using Genesis.Exceptions.Configurator;
using Genesis.Generator;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Genesis.Configurator;

public class GenesisConfigurator
{
    private string defaultConfigurationPath { get; set; }

    private const string delimiter = "=";
    
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
        path += @"\Genesis\gns.conf";
        this.defaultConfigurationPath = path;
    }

    public bool FileExists()
    {
        if (!File.Exists(this.defaultConfigurationPath))
        {
            string directoryPath = Path.GetDirectoryName(defaultConfigurationPath);
            Console.WriteLine(directoryPath);
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
                Verbose.Info($"Directory created '{directoryPath}'");
            }

            var f = File.Create(this.defaultConfigurationPath);
            Verbose.Info($"File successfully created on:\n {this.defaultConfigurationPath}");
            f.Close();
        }
        
        return File.Exists(this.defaultConfigurationPath);
    }


    protected Dictionary<string, string> getItem(string key)
    {
        if (!FileExists())
            throw new FileNotFoundException();
        
        var lines = File.ReadLines(this.defaultConfigurationPath);
        
        foreach (var line in lines) 
        {
            if (line.StartsWith("//"))
                continue;

            var content = line.Split(delimiter);
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

    protected void setItem(string key, string value)
    {
        if (!FileExists())
            throw new FileNotFoundException();
        
        var lines = File.ReadLines(this.defaultConfigurationPath).ToList();

        bool finded = false;
        if(lines.Count > 0)
            for(int i = 0; i < lines.Count; i++)
            {
                if (lines[i].Contains(delimiter))
                {
                    string lineKey = lines[i].Split(delimiter)[0];
                    if (lineKey == key)
                    {
                        lines[i] = $"{key}{delimiter}{value}";
                        finded = true;
                        break;
                    }
                }
            }
        
        if(!finded)
            lines.Add($"{key}{delimiter}{value}");
        
        using StreamWriter writer = new(this.defaultConfigurationPath);
        foreach (var line in lines)
            writer.WriteLine(line);

        writer.Close();
    }

    protected void removeItem(string key)
    {
        if (!FileExists())
            throw new FileNotFoundException();
        
        var lines = File.ReadLines(this.defaultConfigurationPath).ToList();

        if(lines.Count > 0)
            for(int i = 0; i < lines.Count; i++)
            {
                if (lines[i].Contains(delimiter))
                {
                    string lineKey = lines[i].Split(delimiter)[0];
                    if (lineKey == key)
                    {
                        lines.RemoveAt(i);
                        break;
                    }
                }
            }
        using StreamWriter writer = new(this.defaultConfigurationPath);
        foreach (var line in lines)
            writer.WriteLine(line);

        writer.Close();
    }
    
    public static void SetItem(Enum key, string value)
    {
        GenesisConfigurator config = new();
        config.setItem(key.ToString(), value);
    }

    public static void RemoveItem(Enum key)
    {
        GenesisConfigurator config = new();
        config.removeItem(key.ToString());
    }
    
    public static Dictionary<string, string> GetItem(string key)
    {
        GenesisConfigurator configurator = new();
        return configurator.getItem(key);
    }
}