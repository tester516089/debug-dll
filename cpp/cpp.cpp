#include <iostream>
#include <Windows.h>

using namespace std;

int main()
{
    //Place the path of the dll file here, "DLLs\\HookDLL.dll" is the default path.
    char dllPath[] = "HookDLL.dll";

    //Display a pop-up message with the "NOT HOOKED" message and title. 
    MessageBoxA(NULL, "NOT HOOKED", "NOT HOOKED", MB_OK);

    //Load the dll file
    HMODULE hModule = LoadLibraryA((LPCSTR)dllPath);

    //If hModule is null, then the dll wasn't loaded.
    //An error message will be printed out to the console.
    if (!hModule) {
        cout << "Couldn't load the DLL file!" << endl;

        return 1;
    }

    //This is the tricky part.
    //This should display a pop-up message like before with the "NOT HOOKED" message and title,
    //but the dll that was loaded should hook MessageBoxA function,
    //and call a new one with a "HOOKED" message and title instead.
    MessageBoxA(NULL, "NOT HOOKED", "NOT HOOKED", MB_OK);

    FreeLibrary(hModule);

    return 0;
}