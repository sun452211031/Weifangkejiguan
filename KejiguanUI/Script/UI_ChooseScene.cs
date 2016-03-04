using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_ChooseScene : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public string LoadbundleName;
    public string OpenSceneName;
    public Text AboutText;
    public Color EnterColor;
    public Color ExitColor;
    public GameObject Jiazai;
    public void OnPointerClick(PointerEventData eventData)
    {
        var thisName = gameObject.name;
        Manager.BackSceneName = "UILevel1";
        if (LoadbundleName != "" && OpenSceneName != "")
        {
            Manager.LoadbundleName = LoadbundleName;
            Manager.OpenSceneName = OpenSceneName;
            Manager.FanhuiParent = gameObject.transform.parent.gameObject.name;
            Jiazai.SetActive(true);
        }
        else
        {
            Debug.Log("缺失");
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        AboutText.color = new Color(0.74f, 0, 0.53f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        AboutText.color = new Color(0, 0.13f, 0.46f);
    }
}
