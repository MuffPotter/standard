using System;
using System.Runtime.InteropServices;

namespace Standard.Win32
{
   partial class NativeMethods
   {
      public static IntPtr INVALID_HANDLE_VALUE = new IntPtr(-1);

      /// <summary>Closes an open object handle.</summary>
      /// <remarks>
      ///   <para>The CloseHandle function closes handles to the following objects:</para>
      ///   <para>Access token, Communications device, Console input, Console screen buffer, Event, File, File mapping, I/O completion port,
      ///   Job, Mailslot, Memory resource notification, Mutex, Named pipe, Pipe, Process, Semaphore, Thread, Transaction, Waitable
      ///   timer.</para>
      ///   <para>SetLastError is set to <see langword="false"/>.</para>
      ///   <para>Minimum supported client: Windows 2000 Professional [desktop apps | Windows Store apps]</para>
      ///   <para>Minimum supported server: Windows 2000 Server [desktop apps | Windows Store apps]</para>
      /// </remarks>
      /// <returns>
      ///   <para>If the function succeeds, the return value is nonzero.</para>
      ///   <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
      ///   <para>If the application is running under a debugger, the function will throw an exception if it receives either a handle value
      ///   that is not valid or a pseudo-handle value.This can happen if you close a handle twice, or if you call CloseHandle on a handle
      ///   returned by the FindFirstFile function instead of calling the FindClose function.</para>
      /// </returns>
      [DllImport(Kernel32, SetLastError = false, CharSet = CharSet.Unicode)]
      [return: MarshalAs(UnmanagedType.Bool)]
      public static extern bool CloseHandle(IntPtr hObject);
   }
}
