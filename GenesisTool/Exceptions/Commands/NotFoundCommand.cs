namespace GenesisTool.Exceptions;

[System.Serializable]
public class NotFoundCommandException : System.Exception
{
    public NotFoundCommandException() { }
    public NotFoundCommandException(string message) : base(message) { }
    public NotFoundCommandException(string message, System.Exception inner) : base(message, inner) { }
}