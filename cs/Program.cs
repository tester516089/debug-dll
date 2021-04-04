using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace cs
{
    class Program
    {
        [DllImport("user32.dll")]
        static extern int MessageBoxA(IntPtr hWnd,
            string lpText,
            string lpCaption,
            uint uType);
        [DllImport("kernel32.dll")]
        public static extern IntPtr LoadLibrary(string dllToLoad);
        [DllImport("kernel32.dll")]
        public static extern bool FreeLibrary(IntPtr hModule);
        static void Main(string[] args)
        {
            //Place the path of the dll file here, "DLLs\\HookDLL.dll" is the default path.
            string dllPath = "HookDLL.dll";

            //Display a pop-up message with the "NOT HOOKED" message and title. 
            MessageBoxA(IntPtr.Zero, "NOT HOOKED", "NOT HOOKED", 0);

            //Load the dll file
            IntPtr hModule = LoadLibrary(dllPath);

            //If hModule is null, then the dll wasn't loaded.
            //An error message will be printed out to the console.
            if (hModule == IntPtr.Zero)
            {
                Console.WriteLine("Couldn't load the DLL file!");

                return;
            }

            //This is the tricky part.
            //This should display a pop-up message like before with the "NOT HOOKED" message and title,
            //but the dll that was loaded should hook MessageBoxA function,
            //and call a new one with a "HOOKED" message and title instead.
            MessageBoxA(IntPtr.Zero, "NOT HOOKED", "NOT HOOKED", 0);

            //GetClipboardData(1);

            FreeLibrary(hModule);
        }
    }
}
