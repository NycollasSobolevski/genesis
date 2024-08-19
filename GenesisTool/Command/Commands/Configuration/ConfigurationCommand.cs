using System.Collections.Generic;
using Genesis.Configurator;
using Genesis.Generator;
using GenesisTool;
using GenesisTool.Commands;
using GenesisTool.Exceptions;

namespace GenesisTool.Commands;

public class ConfigurationCommand : BaseCommand<ConfigurationCommand>
{
    protected override List<string> ActionsList { get; set; } =
    [
        "help",
        "proxy-url",
        "proxy-domain",
        "proxy-credential-username",
        "proxy-credential-password",
        "proxy-remove"
    ];

    protected override void execute()
    {
        validateAction();
        switch (structure.Action)
        {
            case "help": 
                help();
                break;
            case "proxy-url":
                setProxyByUrl();
                break;
            case "proxy-domain":
                setProxyDomain();
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
        }
    }

    public override void Build(CommandStructure structure)
        => this.structure = structure;

    private void help()
    {
        Verbose.Info("gns config options");
        
        Verbose.Content("   config proxy-url [http://username:password@domain:port]");
        Verbose.Info("       config automatic proxy by url");
        Verbose.Content("   config proxy-domain [http://domain.com:port]");
        Verbose.Info("       config only domain of proxy");
        Verbose.Content("   config proxy-credential-username [username]");
        Verbose.Info("       set user username of proxy ");
        Verbose.Content("   config proxy-credential-password [password]");
        Verbose.Info("       set user password of proxy ");
        Verbose.Content("   config proxy-remove");
        Verbose.Info("       remove all settings of proxy");
    }
    
    private void setProxyByUrl()
    {
        checkStructure("ProxyUrl", 1);
        ProxyConfigurator.SetProxyByUrl(structure.Arguments[0]);
    }

    private void setProxyDomain()
    {
        checkStructure("proxy-domain", 1);
        ProxyConfigurator.SetProxyDomain(structure.Arguments[0]);
    }
    
    private void setProxyUser()
    {
        checkStructure("proxy-user", 1);
        ProxyConfigurator.SetProxyUser(structure.Arguments[0]);
    }

    private void setProxyPassword()
    {
        checkStructure("proxy-password", 1);
        ProxyConfigurator.SetProxyPassword(structure.Arguments[0]);
    }

    private void clearProxy()
    {
        checkStructure("clear-proxy", 0);
        ProxyConfigurator.ClearProxy();
    }

    
    private void checkStructure(string action, int maxArgs)
    {
        if (structure.Arguments.Length > maxArgs)
            throw new InvalidArgumentsException($"""
                 Invalid argument '{structure.Arguments[1]}'
                 '{ action }' action require { maxArgs } argument
                 """);

    }
}