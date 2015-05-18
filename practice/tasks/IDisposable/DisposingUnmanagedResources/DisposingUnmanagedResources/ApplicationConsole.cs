using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;

namespace Unmanaged
{
    internal static class UnmanagedMethods
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        internal static extern SafeConsoleHandle GetStdHandle(int nStdHandle);

        [DllImport("Kernel32.dll", SetLastError = true)]
        internal static extern bool WriteConsole(
            SafeConsoleHandle hConsoleOutput,
            string lpBuffer,
            uint nNumberOfCharsToWrite,
            out uint lpNumberOfCharsWritten,
            IntPtr lpReserved);

        [DllImport("kernel32.dll", SetLastError = true)]
        internal static extern bool CloseHandle(IntPtr handle);
    }

    internal class SafeConsoleHandle : SafeHandleZeroOrMinusOneIsInvalid
    {
        private SafeConsoleHandle() : base(true)
        {
            
        }

        protected override bool ReleaseHandle()
        {
            return true;
        }
    }

    public class ApplicationConsole : IDisposable
    {
        private const int StdOutputHandle = -11;
        private readonly SafeConsoleHandle _consoleSafeHandle;

        public ApplicationConsole()
        {
            _consoleSafeHandle = UnmanagedMethods.GetStdHandle(StdOutputHandle);

            if (_consoleSafeHandle.IsInvalid)
                throw new InvalidOperationException("Std handle is not available");

            //WriteLine("Application console has been initialized");
        }

        public void WriteLine(string outputStr, params object[] args)
        {
            if (_consoleSafeHandle.IsInvalid)
               throw new ObjectDisposedException("Object has been already disposed or was not allocated properly!");

            var formatedStr = String.Format(outputStr, args);
            uint charsWritten;
            UnmanagedMethods.WriteConsole(_consoleSafeHandle, formatedStr, (uint)formatedStr.Length, out charsWritten, IntPtr.Zero);
            UnmanagedMethods.WriteConsole(_consoleSafeHandle, "\n", 1, out charsWritten, IntPtr.Zero);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if(_consoleSafeHandle != null && !_consoleSafeHandle.IsInvalid)
                _consoleSafeHandle.Dispose();
        }
    }
}