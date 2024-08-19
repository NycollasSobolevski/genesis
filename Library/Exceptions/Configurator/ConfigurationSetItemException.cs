namespace Genesis.Exceptions.Configurator;


[System.Serializable]
public class ConfigurationSetItemException : System.Exception
{
    private const string defaultMessage = """
                                          Error on set configuration item
                                          """;
    
    public ConfigurationSetItemException() : base() { }
    public ConfigurationSetItemException(string message) : base(message) { }
    public ConfigurationSetItemException(string message, System.Exception inner) : base(message, inner) { }
}