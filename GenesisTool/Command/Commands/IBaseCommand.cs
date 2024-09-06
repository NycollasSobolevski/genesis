using System.Collections.Immutable;
using GenesisTool;

public interface IBaseCommand
{
    public void Build( CommandStructure structure );
    public void Execute();
}