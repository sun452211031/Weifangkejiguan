using UnityEngine;
using System.Collections;

public class UI_AudioYanshi : MonoBehaviour
{
    public float YanshiTime;
    void OnEnable()
    {
        Invoke("AudioPlay", YanshiTime);
    }
    private void AudioPlay()
    {
        gameObject.GetComponent<AudioSource>().Play();
    }
}
