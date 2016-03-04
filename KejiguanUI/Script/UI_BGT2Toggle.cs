using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UI_BGT2Toggle : MonoBehaviour
{
    public Toggle thisToggle;
    public Sprite OnNormal;
    public Sprite OnChoose;
    public GameObject ShowObj;
    public GameObject JinruGIF;
    public RawImage Background2;
    public Texture Backgroundtexture;
    void Start()
    {
        thisToggle.onValueChanged.AddListener(OnChanged);
    }
    public void ShowObjFunction()
    {
        var thisScript = ShowObj.transform.FindChild("Choose/" + Manager.FanhuiParent).gameObject.GetComponent<UI_ActiveOffOn>();
        StartCoroutine(thisScript.Guodu());
    }
    public void OnChanged(bool isOn)
    {
        if (JinruGIF.activeSelf == true)
        {
            JinruGIF.GetComponent<Animator>().SetBool("Jianyin", true);
        }
        Invoke("jinruGifClose", 0.5f);
        if (isOn == true)
        {
            this.GetComponent<Image>().sprite = OnChoose;
            Background2.texture = Backgroundtexture;
            StartCoroutine("ZeroToOne");
        }
        else
        {
            this.GetComponent<Image>().sprite = OnNormal;
            StartCoroutine("OneToZero");
        }
    }
    private void jinruGifClose()
    {
        JinruGIF.SetActive(false);
    }
    IEnumerator OneToZero()
    {
        for (float i = 1; i > 0; i -= 0.1f)
        {
            ShowObj.transform.localScale = new Vector3(i, 1, 1);
            yield return new WaitForSeconds(0.01f);
        }
        ShowObj.transform.localScale = new Vector3(0, 1, 1);
        ShowObj.SetActive(false);
    }
    IEnumerator ZeroToOne()
    {
        yield return new WaitForSeconds(0.1f);
        ShowObj.SetActive(true);
        for (float i = 0; i < 1; i += 0.1f)
        {
            ShowObj.transform.localScale = new Vector3(i, 1, 1);
            yield return new WaitForSeconds(0.01f);
        }
        ShowObj.transform.localScale = new Vector3(1, 1, 1);
        Manager.ToggleChoose = gameObject.name;
    }
}
