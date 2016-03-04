using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;
using System.Runtime.InteropServices;
public class Back : MonoBehaviour, IPointerClickHandler
{
    [DllImport("user32.dll", EntryPoint = "FindWindowA")]
    public static extern IntPtr FindWindowA(string lp1, string lp2);

    [DllImport("user32.dll", EntryPoint = "ShowWindow")]
    public static extern IntPtr ShowWindow(IntPtr hWnd, int _value);
    void OnApplicationQuit()
    {
        IntPtr hTray = FindWindowA("Shell_TrayWnd", String.Empty);
        ShowWindow(hTray, 5);
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        Application.LoadLevel(Manager.BackSceneName);
    }
}
