using System;

namespace Zoo
{
    public static class Logger
    {
        public static void Log(string str)
        {
            if (AppSettings.IsLoggingEnabled)
                Console.WriteLine(str);
        }

        public static void Log(string str, params object[] args)
        {
            if (AppSettings.IsLoggingEnabled)
                Console.WriteLine(str, args);
        }

        public static void LogYellow(string str)
        {
            if (AppSettings.IsLoggingEnabled)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(str);
                Console.ResetColor();
            }
        }

        public static void LogYellow(string str, params object[] args)
        {
            if (AppSettings.IsLoggingEnabled)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(str, args);
                Console.ResetColor();
            }
        }
    }
}