using System;
using System.Linq;
using System.Text.RegularExpressions;
using Genesis.Configurator;
namespace Genesis.Exceptions.Configurator.Proxy;

public class ProxyConfigurator : GenesisConfigurator
{
    public static bool CheckProxy()
    {
        string host = GetItem(ProxyConfigurationsEnum.ProxyHost.ToString());
        string user = GetItem(ProxyConfigurationsEnum.ProxyUsername.ToString());
        string pass = GetItem(ProxyConfigurationsEnum.ProxyPassword.ToString());

        bool hasNull = new[] { host, user, pass }.Any(x => x == null);
        if(hasNull)
            return false;

        return true;

    }
    
    public static void SetProxyByUrl(string url)
    {
        try
        {
            string pattern = @"^http:\/\/[a-zA-Z0-9._%+-]+:[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+:[0-9]+$";

            if (!Regex.IsMatch(url, pattern)) throw new Exception();
            Console.WriteLine("setproxyurl");

            string[] proxy = url.Split("@");
            string[] credentials = proxy[0]
                .Replace("http://", "")
                .Split(":");

            string domain = proxy[0].Split("/")[0] + "//" + proxy[1];

            GenesisConfigurator.SetItem(
                ProxyConfigurationsEnum.ProxyUsername,
                credentials[0]
            );
            GenesisConfigurator.SetItem(
                ProxyConfigurationsEnum.ProxyPassword,
                credentials[1]
            );
            GenesisConfigurator.SetItem(
                ProxyConfigurationsEnum.ProxyHost,
                domain
            );

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new Exception();
        }
        catch 
        {
            throw new InvalidProxyFormatException();
        }
    }

    public static void SetProxyDomain(string value)
        => GenesisConfigurator.SetItem(ProxyConfigurationsEnum.ProxyHost, value);

    public static void SetProxyUser(string value)
        => GenesisConfigurator.SetItem(ProxyConfigurationsEnum.ProxyUsername, value);

    public static void SetProxyPassword(string value)
        => GenesisConfigurator.SetItem(ProxyConfigurationsEnum.ProxyPassword, value);

    public static void ClearProxy()
    {
        GenesisConfigurator.RemoveItem(ProxyConfigurationsEnum.ProxyHost);
        GenesisConfigurator.RemoveItem(ProxyConfigurationsEnum.ProxyPassword);
        GenesisConfigurator.RemoveItem(ProxyConfigurationsEnum.ProxyUsername);
    }
}