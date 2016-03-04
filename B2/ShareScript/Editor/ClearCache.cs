using UnityEditor;
using UnityEngine;
public class ClearCache
{
    [MenuItem("Assets/Clear AssetBundles")]
    static void Clear()
    {
        Caching.CleanCache();
    }
}