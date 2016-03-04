using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class Back : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        Application.LoadLevel(Manager.BackSceneName);
    }
}
