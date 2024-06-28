using System;
using GenesisTool.Commands;
using GenesisTool.Exceptions;

namespace GenesisTool;

public class CommandStructure
{
    public CommandsEnum Command {get;set;}
    public string Action {get;set;}
    public string[] Arguments {get;set;}


    public CommandStructure (string[] args)
    {
        if(args.Length == 0)
            throw new NoCommandProvidedException();

        isValidCommand(args[0]);
        this.Command = (CommandsEnum)Enum.Parse(typeof(CommandsEnum), args[0], true);

        if(args.Length > 1)
        {
            this.Action = args[1];
            this.Arguments = args[2..];
        }
    }

    private bool isValidCommand(string value)
    {
        bool isValid = Enum.TryParse(value, true, out CommandsEnum command) && Enum.IsDefined(typeof(CommandsEnum), command);

        if(!isValid)
            throw new NotFoundCommandException();

        return isValid;
    }
}