using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace NostaleUselessTrainer
{
    public class SystemFunctions
    {
        private delegate bool EnumWindowsProc(System.IntPtr hWnd, int lParam);

        [DllImport("USER32.DLL")]
        private static extern bool EnumWindows(EnumWindowsProc enumFunc, int lParam);

        [DllImport("USER32.DLL")]
        private static extern int GetWindowText(System.IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        [DllImport("USER32.DLL")]
        private static extern int GetWindowTextLength(System.IntPtr hWnd);

        [DllImport("USER32.DLL")]
        private static extern System.IntPtr GetShellWindow();
    
        public static IDictionary<System.IntPtr, string> GetOpenWindows()
        {
            System.IntPtr shellWindow = GetShellWindow();
            Dictionary<System.IntPtr, string> windows = new Dictionary<System.IntPtr, string>();

            EnumWindows(delegate(System.IntPtr hWnd, int lParam)
            {
                if (hWnd == shellWindow) return true;

                int length = GetWindowTextLength(hWnd);
                if (length == 0) return true;

                StringBuilder builder = new StringBuilder(length);
                GetWindowText(hWnd, builder, length + 1);

                windows[hWnd] = builder.ToString();
                return true;

            }, 0);

            return windows;
        }
    }
}