using UnityEngine;
using System.Collections;

public class Manager
{
    public static string ToggleChoose = "";
    public static string FanhuiParent = "";
    public static AssetBundle bundle;
    public static string LoadbundleName, OpenSceneName, BackSceneName;
    public static string Address =
#if UNITY_STANDALONE_WIN
        "file://" + Application.dataPath + "/";
#endif
#if UNITY_WEBPLAYER
        Application.dataPath + "/";
#endif
}
