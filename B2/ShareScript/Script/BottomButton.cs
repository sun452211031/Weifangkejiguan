using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;

public class BottomButton : MonoBehaviour
{
    public GameObject ActiveObj;
    public Sprite EnterSprite;
    private Sprite NormalSprite;
    private Toggle thisToggle;
    private Image thisImage;
    void Start()
    {
        if (ActiveObj)
        {
            if (ActiveObj.activeSelf == true)
            {
                ActiveObj.SetActive(false);
            }
        }
        thisImage = this.GetComponent<Image>();
        NormalSprite = thisImage.sprite;
        thisToggle = this.GetComponent<Toggle>();
        thisToggle.onValueChanged.AddListener(OnChanged);
    }
    public void OnChanged(bool isOn)
    {
        if (isOn == false)
        {
            thisImage.sprite = NormalSprite;
            thisImage.transform.localScale = Vector3.one;
            if (ActiveObj)
            {
                ActiveObj.SetActive(false);
            }
        }
        else
        {
            transform.SetSiblingIndex(10);
            thisImage.sprite = EnterSprite;
            thisImage.transform.localScale = new Vector3(1.02f, 1.3f, 1.02f);
            if (ActiveObj)
            {
                ActiveObj.SetActive(true);
            }
        }
    }
}
