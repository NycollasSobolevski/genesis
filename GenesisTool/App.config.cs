using GenesisTool.Commands;

namespace GenesisTool;

public class App
{
    public static void InitializeGenesis(string[] args)
    {
        CommandStructure structure = new(args);
        switch (structure.Command)
        {
            case CommandsEnum.help:
                HelpCommand.StaticExecute();
                break;

            case CommandsEnum.database:
                DatabaseCommand command = new();
                command.Build(structure);
                command.Execute();
                break;

            default:
                break;
        }
    }

}