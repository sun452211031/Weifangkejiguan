using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UI_Jiazai : MonoBehaviour
{
    private WWW download;
    public Scrollbar jindutiao;
    public Text showText;
    void OnEnable()
    {
        Caching.CleanCache();
        System.GC.Collect();
        if (Manager.bundle != null)
        {
            Manager.bundle.Unload(false);
        }
        StartCoroutine("jiazai");
    }
    IEnumerator jiazai()
    {
        Manager.BackSceneName = Application.loadedLevelName;
        yield return new WaitForSeconds(1);
        while (!Caching.ready)
        {
            Caching.CleanCache();
            showText.text = "缓存空间不足";
        }
        using (download = WWW.LoadFromCacheOrDownload(Manager.Address + "AssetBundles/" + Manager.LoadbundleName, 1))
        {
            yield return download;
            if (download.error != null)
            {
                showText.text = "加载失败";
            }
            Manager.bundle = download.assetBundle;
            AssetBundleManifest mainfest = (AssetBundleManifest)Manager.bundle.LoadAsset(Manager.LoadbundleName + ".manifest");
            yield return mainfest;
            Application.LoadLevel(Manager.OpenSceneName);
        }
    }
    void Update()
    {
        if (download != null)
        {
            if (download.progress < 0.1f)
            {
                jindutiao.size = 0.1f;
                showText.text = "准备加载";
            }
            else if (download.progress >= 0.1f && download.progress < 1)
            {
                jindutiao.size = download.progress;
                showText.text = "加载" + Mathf.Round(download.progress * 100) + "%";
            }
            else
            {
                jindutiao.size = 1;
                showText.text = "加载完成请等待开启";
            }
        }
    }
}
