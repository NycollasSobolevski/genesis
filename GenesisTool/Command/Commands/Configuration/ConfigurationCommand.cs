using GenesisTool;
using GenesisTool.Commands;
using GenesisTool.Exceptions;

namespace GenesisTool.Commands;

public class ConfigurationCommand : BaseCommand<ConfigurationCommand>
{
    protected override void execute()
    {
        validateAction();
        switch (structure.Action)
        {
            case "proxy-adress":
                setProxyAdress();
                break;
            case "proxy-credential-username":
                setProxyUser();
                break;
            case "proxy-credential-password":
                setProxyPassword();
                break;
            case "proxy-remove":
                clearProxy();
                break;
            default:
                throw new NotFoundCommandException();
                break;
        }
    }

    public override void Build(CommandStructure structure)
        => this.structure = structure;
    
    private void setProxyByUrl(){}
    
    private void setProxyAdress(){}
    
    private void clearProxy(){}
    
    private void setProxyUser(){}
    
    private void setProxyPassword(){}
}