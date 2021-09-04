using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace phpFE
{
    internal static class API
    {
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll", SetLastError = true)]
        internal static extern long SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        [DllImport("user32.dll", EntryPoint = "GetWindowLongA", SetLastError = true)]
        internal static extern long GetWindowLong(IntPtr hwnd, int nIndex);

        //deprecated 
        //[DllImport("user32.dll", EntryPoint = "SetWindowLongA", SetLastError = true)]
        //private static extern long SetWindowLong(IntPtr hwnd, int nIndex, long dwNewLong);

        [DllImport("user32.dll", EntryPoint = "SetWindowLongW")]
        internal static extern int SetWindowLong32(HandleRef hWnd, int nIndex, int dwNewLong);

        [DllImport("user32.dll", EntryPoint = "SetWindowLongPtrW")]
        internal static extern IntPtr SetWindowLongPtr64(HandleRef hWnd, int nIndex, IntPtr dwNewLong);

        [DllImport("user32.dll", SetLastError = true)]
        internal static extern long SetWindowPos(IntPtr hwnd, long hWndInsertAfter, long x, long y, long cx, long cy, long wFlags);

        [DllImport("user32.dll", SetLastError = true)]
        internal static extern bool MoveWindow(IntPtr hwnd, int x, int y, int cx, int cy, bool repaint);

        internal const int SWP_NOOWNERZORDER = 0x200;
        internal const int SWP_NOREDRAW = 0x8;
        internal const int SWP_NOZORDER = 0x4;
        internal const int SWP_SHOWWINDOW = 0x0040;
        internal const int WS_EX_MDICHILD = 0x40;
        internal const int SWP_FRAMECHANGED = 0x20;
        internal const int SWP_NOACTIVATE = 0x10;
        internal const int SWP_ASYNCWINDOWPOS = 0x4000;
        internal const int SWP_NOMOVE = 0x2;
        internal const int SWP_NOSIZE = 0x1;
        internal const int GWL_STYLE = (-16);
        internal const int WS_VISIBLE = 0x10000000;
        internal const int WM_CLOSE = 0x10;
        internal const int WS_CHILD = 0x40000000;

        internal static IntPtr SetWindowLongPtr(HandleRef hWnd, int nIndex, IntPtr dwNewLong)
        {   // This helper static method is required because the 32-bit version of user32.dll does not contain this API
            // (on any versions of Windows), so linking the method will fail at run-time. The bridge dispatches the request
            // to the correct function (GetWindowLong in 32-bit mode and GetWindowLongPtr in 64-bit mode)
            //https://www.pinvoke.net/default.aspx/user32.setwindowlong
            //https://gist.github.com/jojonv/dc5ee2919028a1ccf608bf29585ed658#file-hidewindowclosebuttonbehavior-cs-L31

            if (IntPtr.Size == 8)
                return SetWindowLongPtr64(hWnd, nIndex, dwNewLong);
            else
                return new IntPtr(SetWindowLong32(hWnd, nIndex, dwNewLong.ToInt32()));
        }
    }
}
