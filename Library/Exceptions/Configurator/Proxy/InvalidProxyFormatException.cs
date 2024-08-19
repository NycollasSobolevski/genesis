namespace Genesis.Exceptions.Configurator.Proxy;

[System.Serializable]
public class InvalidProxyFormatException : System.Exception
{
    private const string defaultMessage = """
                                          Proxy url format is incorrect.
                                          Please insert proxy by 'http://username:password@host:port' format.
                                          """;
    
    public InvalidProxyFormatException() : base(defaultMessage) { }
    public InvalidProxyFormatException(string message) : base(defaultMessage + message) { }
    public InvalidProxyFormatException(string message, System.Exception inner) : base(message, inner) { }
}