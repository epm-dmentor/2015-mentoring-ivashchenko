using System;

namespace Unmanaged
{
    class Program
    {
        public static void Main()
        {
            for (var i = 0; i < 1000000; i++)
            {
                var console = new ApplicationConsole();
                console.WriteLine("Line number: {0}", i);
            }
            Console.ReadKey();
        }

    }
}
