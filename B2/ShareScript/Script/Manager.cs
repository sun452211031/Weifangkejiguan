using UnityEngine;
using System.Collections;

public class Manager : MonoBehaviour
{
    public static AssetBundle bundle;
    public static string LoadbundleName, OpenSceneName, BackSceneName;
    public static string Address =
#if UNITY_STANDALONE_WIN
        "file://" + Application.dataPath + "/AssetBundles/";
#endif
#if UNITY_WEBPLAYER
        "Application.dataPath"+ "/AssetBundles/";
#endif
}
