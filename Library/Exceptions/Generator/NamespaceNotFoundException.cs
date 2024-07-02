namespace Genesis.Exceptions;

[System.Serializable]
public class NamespaceNotFoundExceptionException : System.Exception
{
    public NamespaceNotFoundExceptionException() { }
    public NamespaceNotFoundExceptionException(string message) : base(message) { }
    public NamespaceNotFoundExceptionException(string message, System.Exception inner) : base(message, inner) { }
}