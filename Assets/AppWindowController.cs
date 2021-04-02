
 
#if UNITY_STANDALONE_WIN
using System;
using System.Runtime.InteropServices;
#endif
 
public class AppWindowController
{
    public enum CmdShow { Hide = 0, ShowNormal = 1, ShowMinimized = 2, ShowMaximized = 3, ShowNormalDontActivate = 4, Show = 5, Minimize = 6, ShowMinimizedDontActivate = 7, ShowDontActivate = 8, Restore = 9, ShowDefault = 10, ForceMinimize = 11 }

#if UNITY_STANDALONE_WIN
    [DllImport("user32.dll")]
    private static extern IntPtr GetActiveWindow();
    [DllImport("user32.dll")]
    private static extern bool IsIconic(IntPtr hWnd);
    [DllImport("user32.dll")]
    private static extern bool IsZoomed(IntPtr hWnd);
    [DllImport("user32.dll")]
    private static extern bool ShowWindowAsync(IntPtr hWnd, int nCmdShow);
    [DllImport("user32.dll")]
    private static extern long SetWindowLongW(IntPtr hWnd,int nIndex, long dwNewLong);

    private IntPtr handle = IntPtr.Zero;

    const long NO_TASKICON_STYLE = 0x08000000L;
    const long NORMAL_STYLE = 0;
    const int STYLE_INDEX = -20;
#endif

    public bool IsMaximized()
    {
#if UNITY_STANDALONE_WIN
        GetHandle();
        return IsZoomed(handle);
#else
        return false;
#endif
    }

    public bool IsMinimized()
    {
#if UNITY_STANDALONE_WIN
        GetHandle();
        return IsIconic(handle);
#else
        return false;
#endif
    }

    public void Maximize()
    {
        ShowAsync(CmdShow.ShowMaximized);
    }

    public void Minimize()
    {
        ShowAsync(CmdShow.Minimize);
    }

    public void ShowAsync(CmdShow cmd)
    {
#if UNITY_STANDALONE_WIN
        UnityEngine.Debug.Log("WinAppMiniController : ShowAsync : " + cmd);
        GetHandle();
        ShowWindowAsync(handle, (int)cmd);
#endif
    }

    public void SetShowInTaskBarPro(bool show)
    {
        GetHandle();
        if(show)
        {
            SetWindowLongW(handle, STYLE_INDEX, NORMAL_STYLE);
        }
        else
        {
            SetWindowLongW(handle, STYLE_INDEX, NO_TASKICON_STYLE);
        }
    }


#if UNITY_STANDALONE_WIN
    private void GetHandle()
    {
        if (handle != IntPtr.Zero) return;
        handle = GetActiveWindow();
    }
#endif
}
