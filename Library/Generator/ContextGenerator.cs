using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Common;
using System.IO;
using System.Runtime.CompilerServices;
using Genesis.Generator.Database;
using Genesis.Generator.Templates;

namespace Genesis.Generator;

public class ContextGenerator
{
    private DatabaseInfo databaseInfo { get; set; }
    private GenesisTemplate template { get; set; }

    public ContextGenerator( DatabaseInfo dbInfo )
    {
        this.databaseInfo = dbInfo;
        this.template = new ("Genesis", null, this.databaseInfo.Catalog);
    }

    public void GenerateContext (List<string> entities)
    {
        try{
            string filename = $"{databaseInfo.Catalog}Context.cs";
            string baseDirectory = Directory.GetCurrentDirectory();
            string directory = @$"\Core\{filename}";    
            directory = baseDirectory + directory;

            string contextContent = this.template.GetContext(entities, this.databaseInfo.StringConnection);

            Verbose.Info("Creating context....");
            File.WriteAllText(directory, contextContent);
            Verbose.Success("Context created successfuly");


        }catch (Exception e) {
            Verbose.Danger($"Error on generate context\n {e}");
        }
    }
}