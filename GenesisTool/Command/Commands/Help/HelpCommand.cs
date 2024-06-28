namespace GenesisTool.Commands;

public class HelpCommand : BaseCommand<HelpCommand>
{

    protected override void execute()
    {
        System.Console.WriteLine("""
            Structure of commands: 
            [command] [action] [arguments]

            Commands:
                help
                
                database 
                    database add [connection-string]

        """);
    }

    public override void Build(CommandStructure structure)
        => throw new System.NotImplementedException();
    protected override bool validateAction()
        => throw new System.NotImplementedException();
}