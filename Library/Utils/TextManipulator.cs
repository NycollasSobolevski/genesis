namespace Genesis.Text;

public static class TextManipulator
{
    
    public static string ToPascalCase(string text)
    {
        string[] list = text.Split( text.Contains('-') ? "-" : text.Contains('_') ? "_" : "." );
        string result = "";
        foreach (var item in list )
            result += TextManipulator.ToSingleTitle(item);

        return result;
    }

    public static string ToNamespaceConvention(string text)
        => text.Replace(" ", "_").Replace("-","_");
    
    public static string ToSingleTitle (string text)
        => char.ToUpper(text[0]) + text[1..];

    public static string ToCompoundTitle (string text)
    {
        string[] list = text.Split(' ');
        string result = "";
        foreach (var item in list)
            result += char.ToUpper(item[0]) + item[1..];
        return result;
    }

    

}