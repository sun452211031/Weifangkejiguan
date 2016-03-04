using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using System.Runtime.InteropServices;
public class UI_UIManager : MonoBehaviour
{
    [DllImport("user32.dll", EntryPoint = "FindWindowA")]
    public static extern IntPtr FindWindowA(string lp1, string lp2);
    [DllImport("user32.dll", EntryPoint = "ShowWindow")]
    public static extern IntPtr ShowWindow(IntPtr hWnd, int _value);
    public GameObject Background2;
    public GameObject Shouye;
    public GameObject Jiazai;
    public GameObject JinruGIF;
    public Text KexuyouxiText;
    public Text XunizhanxiangText;
    public GameObject KexueyouxiGUI;
    public GameObject XunizhanxiangGUI;
    public GameObject XunikexuefanhuiUI;
    public static bool iskexuexunifanhui = false;

    void Awake()
    {
        IntPtr hTray = FindWindowA("Shell_TrayWnd", String.Empty);
        ShowWindow(hTray, 0);
        if (Manager.ToggleChoose == "" && Manager.FanhuiParent == "")
        {
            if (iskexuexunifanhui == true)
            {
                Zhitongche();
            }
        }
        else
        {
            Background2.SetActive(true);
            Shouye.SetActive(true);
            var thistoggle = GameObject.Find("Canvas/Background2/ToggleGroup/" + Manager.ToggleChoose);
            if (Manager.ToggleChoose == "3")
            {
                thistoggle.GetComponent<Toggle>().isOn = true;
                thistoggle.GetComponent<UI_BGT2Toggle>().OnChanged(true);
            }
            else
            {
                thistoggle.GetComponent<Toggle>().isOn = true;
                thistoggle.GetComponent<UI_BGT2Toggle>().OnChanged(true);
                thistoggle.GetComponent<UI_BGT2Toggle>().ShowObjFunction();
            }
        }
    }
    void OnApplicationQuit()
    {
        IntPtr hTray = FindWindowA("Shell_TrayWnd", String.Empty);
        ShowWindow(hTray, 5);
    }
    public void zhanguan3D()
    {
        Manager.LoadbundleName = "a0.scene";
        Manager.OpenSceneName = "A0";
        Manager.ToggleChoose = "";
        Jiazai.SetActive(true);
    }
    public void Zhitongche()
    {
        Background2.SetActive(true);
        Shouye.SetActive(true);
        JinruGIF.SetActive(true);
    }
    public void kexueyouxi()
    {
        Shouye.SetActive(false);
        XunikexuefanhuiUI.SetActive(true);
        if (KexueyouxiGUI.activeSelf == false)
        {
            if (JinruGIF.activeSelf == true)
            {
                JinruGIF.GetComponent<Animator>().SetBool("Jianyin", true);
            }
            Invoke("jinruGifClose", 0.5f);
            KexuyouxiText.color = Color.yellow;
            XunizhanxiangText.color = Color.white;
            StartCoroutine(KexueXuniGuodu(KexueyouxiGUI, XunizhanxiangGUI));
        }
    }
    public void xunizhanxiang()
    {
        Shouye.SetActive(false);
        XunikexuefanhuiUI.SetActive(true);
        if (XunizhanxiangGUI.activeSelf == false)
        {
            if (JinruGIF.activeSelf == true)
            {
                JinruGIF.GetComponent<Animator>().SetBool("Jianyin", true);
            }
            Invoke("jinruGifClose", 0.5f);
            KexuyouxiText.color = Color.white;
            XunizhanxiangText.color = Color.yellow;
            StartCoroutine(KexueXuniGuodu(XunizhanxiangGUI, KexueyouxiGUI));
        }
    }
    public void xunikexuefanhui()
    {
        iskexuexunifanhui = true;
        Manager.ToggleChoose = "";
        Manager.FanhuiParent = "";
        Application.LoadLevel("UILevel1");
    }
    public void ShouyeFunction()
    {
        iskexuexunifanhui = false;
        Manager.ToggleChoose = "";
        Manager.FanhuiParent = "";
        Application.LoadLevel("UILevel1");
    }
    IEnumerator KexueXuniGuodu(GameObject On, GameObject Off)
    {
        if (On.transform.GetSiblingIndex() < Off.transform.GetSiblingIndex())
        {
            On.transform.SetSiblingIndex(Off.transform.GetSiblingIndex());
        }
        On.SetActive(true);
        for (float i = 0; i < 1; i += 0.1f)
        {
            On.GetComponent<RawImage>().color = new Color(1, 1, 1, i);
            yield return new WaitForSeconds(0.01f);
        }
        On.GetComponent<RawImage>().color = new Color(1, 1, 1, 1);
        if (Off.activeSelf == true)
        {
            Off.SetActive(false);
        }
    }
    private void jinruGifClose()
    {
        JinruGIF.SetActive(false);
    }
}
