using System;
using System.Runtime.InteropServices;

namespace Unmanaged
{
    public class ApplicationConsole
    {
        private const int StdOutputHandle = -11;
        private readonly IntPtr _consoleHandle;

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr GetStdHandle(int nStdHandle);

        [DllImport("Kernel32.dll", SetLastError = true)]
        private static extern bool WriteConsole(
            IntPtr hConsoleOutput,
            string lpBuffer,
            uint nNumberOfCharsToWrite,
            out uint lpNumberOfCharsWritten,
            IntPtr lpReserved);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool CloseHandle(IntPtr handle);

        public ApplicationConsole()
        {
            _consoleHandle = GetStdHandle(StdOutputHandle);

            if (_consoleHandle == IntPtr.Zero)
                throw new InvalidOperationException("Std handle is not available");

            //WriteLine("Application console has been initialized");
        }

        public void WriteLine(string outputStr, params object[] args)
        {
            if (_consoleHandle == IntPtr.Zero)
                throw new ObjectDisposedException("Object has been already disposed or was not allocated properly!");

            var formatedStr = String.Format(outputStr, args);
            uint charsWritten;
            WriteConsole(_consoleHandle, formatedStr, (uint)formatedStr.Length, out charsWritten, IntPtr.Zero);
            WriteConsole(_consoleHandle, "\n", 1, out charsWritten, IntPtr.Zero);
        }
    }
}