using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class BottomGroup : MonoBehaviour
{
    public GameObject[] WebButton;//网页模式下需要禁用的按钮
    IEnumerator Start()
    {
#if UNITY_WEBPLAYER
        for (int i = 0; i < WebButton.Length; i++)
        {
            Destroy(WebButton[i]);
        }
        yield return new WaitForEndOfFrame();
        Destroy(this.GetComponent<GridLayoutGroup>());
        Destroy(this);
#endif
#if UNITY_STANDALONE_WIN
        yield return new WaitForEndOfFrame();
        Destroy(this.GetComponent<GridLayoutGroup>());
        Destroy(this);
#endif
    }
}
