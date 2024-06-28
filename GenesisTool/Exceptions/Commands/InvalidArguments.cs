namespace GenesisTool.Exceptions;

[System.Serializable]
public class InvalidArgumentsException : System.Exception
{
    private const string defaultMessage = """
        Invalid Arguments
        try '--help' to see all options
        """;
    public InvalidArgumentsException() : base(defaultMessage) {  }
    public InvalidArgumentsException(string message) : base(message) { }
    public InvalidArgumentsException(string message, System.Exception inner) : base(message, inner) { }
}