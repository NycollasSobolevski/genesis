using GenesisTool.Commands;

namespace GenesisTool;

public class App
{
    public static void InitializeGenesis(string[] args)
    {
        CommandStructure structure = new(args);
        IBaseCommand command;
        switch (structure.Command)
        {
            case CommandsEnum.Help:
                HelpCommand.StaticExecute();
                break;

            case CommandsEnum.Database:
                command = new DatabaseCommand();
                command.Build(structure);
                command.Execute();
                break;

            case CommandsEnum.Config:
                command = new ConfigurationCommand();
                command.Build(structure);
                command.Execute();
                break;
            
            default:
                break;
        }
    }

}