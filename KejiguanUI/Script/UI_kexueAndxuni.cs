using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;
using System.Diagnostics;
public class UI_kexueAndxuni : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        Process.Start(Application.dataPath + "/StreamingAssets/" + gameObject.name + ".exe");
    }
}
