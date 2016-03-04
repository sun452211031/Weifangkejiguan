using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class UI_ActiveOffOn : MonoBehaviour,IPointerClickHandler
{
    public GameObject ActiveOn;
    public GameObject ActiveOff;

    public void OnPointerClick(PointerEventData eventData)
    {

        StartCoroutine("Guodu");
    }
    public IEnumerator Guodu()
    {
        for (float i = 1; i > 0; i -= 0.1f)
        {
            ActiveOff.transform.localScale = new Vector3(i, i, i);
            yield return new WaitForSeconds(0.01f);
        }
        ActiveOff.transform.localScale = new Vector3(0, 0, 0);
        ActiveOn.SetActive(true);
        for (float i = 0; i < 1; i += 0.1f)
        {
            ActiveOn.transform.localScale = new Vector3(i, i, i);
            yield return new WaitForSeconds(0.01f);
        }
        ActiveOn.transform.localScale = new Vector3(1, 1, 1);
        ActiveOff.SetActive(false);
    }
}
