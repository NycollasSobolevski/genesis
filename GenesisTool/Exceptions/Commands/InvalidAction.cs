namespace GenesisTool.Exceptions;

[System.Serializable]
public class InvalidActionException : System.Exception
{
    private const string defaultMessage = """
    Invalid Action
    try 'gns help' to see all options.
    """;
    public InvalidActionException() : base(defaultMessage) { }
    public InvalidActionException(string message) : base(message) { }
    public InvalidActionException(string message, System.Exception inner) : base(message, inner) { }
}