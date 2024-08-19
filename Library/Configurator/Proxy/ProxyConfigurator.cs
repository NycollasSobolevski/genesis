using System;
using System.Text.RegularExpressions;
using Genesis.Exceptions.Configurator.Proxy;

namespace Genesis.Configurator;

public static class ProxyConfigurator
{
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
    
    public static void SetProxyDomain(string value){}
    
    public static void SetProxyUser(string value){}
    
    public static void SetProxyPassword(string value){}
    
    public static void ClearProxy(){}
}