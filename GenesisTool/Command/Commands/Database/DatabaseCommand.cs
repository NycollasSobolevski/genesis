using System;
using System.Collections.Generic;
using Genesis.Generator;
using GenesisTool.Exceptions;

namespace GenesisTool.Commands;

public class DatabaseCommand : BaseCommand<DatabaseCommand>
{
    private string stringConnection { get; set; }
    protected override List<string> ActionsList { get;set; } = [
        "add",
        "help"
        ];
    public override void Build(CommandStructure structure)
        => this.structure = structure;

    protected override void execute()
    {
        validateAction();
        switch (structure.Action)
        {
            case "add":
                add();
                break;
            case "help":
                help();
                break;
            default:
                break;
        }
    }

    private void help()
    {
        Verbose.Info("gns database options");
        Verbose.Content("   database add [connection-string]");
        Verbose.Info   ("       Create dependences of project based on the database");
//                 database 
//                     database add [connection-string]
    }
    private void add ()
    {
        if(structure.Arguments.Length > 1)
            throw new InvalidArgumentsException($"""
            Invalid argument '{structure.Arguments[1]}'
            'add' action require 1 argument
            """);

        this.stringConnection = structure.Arguments[0];

        GenesisGenerator generator = new(this.stringConnection);
        generator.GenerateCode();
    }
}