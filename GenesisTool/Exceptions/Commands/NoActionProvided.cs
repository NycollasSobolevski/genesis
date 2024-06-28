namespace GenesisTool.Exceptions;

[System.Serializable]
public class NoActionProvidedException : System.Exception
{
    private const string defaultMessage = """
        No action provided.
        try '--help' to see all options
        """;
    public NoActionProvidedException() : base(defaultMessage) {  }
    public NoActionProvidedException(string message) : base(message) { }
    public NoActionProvidedException(string message, System.Exception inner) : base(message, inner) { }
}