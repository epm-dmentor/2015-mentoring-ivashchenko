using System;

namespace Convestudo.Unmanaged
{
    /// <summary>
    /// Access type to device or file
    /// <see cref="http://msdn.microsoft.com/en-us/library/windows/desktop/aa446632(v=vs.85).aspx"/>
    /// </summary>
    [Flags]
    internal enum DesiredAccess : uint
    {
        Read = 0x80000000,
        Write = 0x40000000
    }

    /// <summary>
    /// Sharing mode, 
    /// <see cref="http://msdn.microsoft.com/en-us/library/windows/desktop/aa363858(v=vs.85).aspx"/>
    /// </summary>
    [Flags]
    internal enum ShareMode : uint
    {
        /// <summary>
        /// Prevents other processes from opening file/device
        /// </summary>
        None = 0x0,

        Read = 0x1,
        Write = 0x2,
        Delete = 0x4,
    }


    /// <summary>
    /// Defines an action to do on creating file /to open, create, fails if exists...
    /// <see cref="http://msdn.microsoft.com/en-us/library/windows/desktop/aa363858(v=vs.85).aspx"/>
    /// </summary>
    internal enum CreationDisposition : uint
    {
        CreateNew = 1,
        CreateAlways = 2,
        OpenExisting = 3,
        OpenAlways = 4,
        TruncateExsting = 5
    }


    /// <summary>
    /// 
    /// <see cref="http://msdn.microsoft.com/en-us/library/windows/desktop/aa363858(v=vs.85).aspx"/>
    /// </summary>
    [Flags]
    public enum FlagsAndAttributes : uint
    {

        Normal = 0x80
        //and others, see WinApi documentation
    }
}