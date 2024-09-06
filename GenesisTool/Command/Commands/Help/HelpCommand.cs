using System;
using Genesis.Generator;

namespace GenesisTool.Commands;

public class HelpCommand : BaseCommand<HelpCommand>
{

    protected override void execute()
    {
//         System.Console.WriteLine("""
//             Structure of commands: 
//             [command] [action] [arguments]
//
//             Commands:
//                 help

//                     
//                 
//         """);
        Verbose.Success("    Structure of commands: \n    [command] [action] [arguments]\n\n");
        
        Verbose.Success("  Commands:");
        
        Verbose.Info   ("       database");
        Verbose.Success("           database help\n"); 
        
        Verbose.Info   ("       configurations");
        Verbose.Success("           config help\n"); 
        
        
    }

    public override void Build(CommandStructure structure)
        => throw new System.NotImplementedException();
    protected override bool validateAction()
        => throw new System.NotImplementedException();
}