using System;
using System.Runtime.CompilerServices;

using Color = System.ConsoleColor;

namespace Genesis.Generator;
public static class Verbose
{
    public static int Level {get; private set;} = 1;

    public static void SetVerboseLevel (int level)
        => Level = level;

    private static void message(
        int level,
        object msg,
        Color color
    ){
        if(Level < level)
            return;

        Console.ForegroundColor = color;
        Console.WriteLine(msg);
        Console.ForegroundColor = Color.Gray;
    }

    public static void Info(object text, int level = 0)
        => message(level, text, Color.Blue);
    public static void Warning(object text, int level = 0)
        => message(level, text, Color.Yellow);
    public static void Danger(object text, int level = 0)
        => message(level, text, Color.Red);
    public static void Success(object text, int level = 0)
        => message(level, text, Color.Green);
    public static void Content(object text, int level = 0)
        => message(level, text, Color.White);
    
}