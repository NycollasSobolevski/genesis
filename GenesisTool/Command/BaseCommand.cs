using System.Collections.Generic;
using System.Runtime.CompilerServices;
using GenesisTool.Exceptions;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.Extensions.Options;

namespace GenesisTool.Commands;

public abstract class BaseCommand<T>
    where T : BaseCommand<T>, new()
{
    protected CommandStructure structure {get;set;}
    protected virtual List<string> ActionsList {get;set;} = [];
    protected abstract void execute();
    protected virtual bool validateAction()
    {
        System.Console.WriteLine(structure.Action);
        if(structure.Action is null)
            throw new NoActionProvidedException();

        bool isValid = this.ActionsList.Contains(structure.Action);

        if(!isValid)
            throw new InvalidActionException();

        return true;
    }
    public abstract void Build(CommandStructure structure);

    public void Execute()
        => this.execute();
    
    public static void StaticExecute()
    {
        var obj = new T();
        obj.execute();
    }

}