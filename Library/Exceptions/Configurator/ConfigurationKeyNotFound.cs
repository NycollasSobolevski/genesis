using System.Runtime.CompilerServices;

namespace Genesis.Exceptions.Configurator;


[System.Serializable]
public class ConfigurationKeyNotFound : System.Exception
{
    private const string defaultMessage = """
        Key not found 
        """;
    
    public ConfigurationKeyNotFound() : base(defaultMessage) { }
    public ConfigurationKeyNotFound(string message) : base(message) { }
    public ConfigurationKeyNotFound(string message, System.Exception inner) : base(message, inner) { }
}