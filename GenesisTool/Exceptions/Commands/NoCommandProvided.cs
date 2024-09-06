namespace GenesisTool.Exceptions;

[System.Serializable]
public class NoCommandProvidedException : System.Exception
{
    private const string defaultMessage = """
        No comands provided.
        try 'help' to see all options
        """;
    public NoCommandProvidedException() : base(defaultMessage) {  }
    public NoCommandProvidedException(string message) : base(message) { }
    public NoCommandProvidedException(string message, System.Exception inner) : base(message, inner) { }
}