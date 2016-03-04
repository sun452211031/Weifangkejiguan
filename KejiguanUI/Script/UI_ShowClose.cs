using UnityEngine;
using System.Collections;

public class UI_ShowClose : MonoBehaviour
{
    public GameObject Choose;
    public GameObject[] ABCD;
    void OnDisable()
    {
        Choose.transform.localScale = Vector3.one;
        Choose.SetActive(true);
        for (int i = 0; i < ABCD.Length; i++)
        {
            ABCD[i].transform.localScale = Vector3.zero;
        }
    }
}
