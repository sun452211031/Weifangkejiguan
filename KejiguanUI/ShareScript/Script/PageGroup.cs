using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class PageGroup : MonoBehaviour
{
    public Toggle ControlToggle;//触发按钮
    public GameObject[] page;//书页
    private GameObject isActive;
    private int stepCount;
    private int StepCount
    {
        get
        {
            if (stepCount <= 0)
            {
                return 0;
            }
            else if (stepCount >= page.Length - 1)
            {
                return page.Length - 1;
            }
            else
            {
                return stepCount;
            }
        }
        set
        {
            stepCount = value;
        }
    }
    void OnEnable()
    {
        for (int i = 0; i < page.Length; i++)
        {
            if (page[i])
            {
                page[i].SetActive(false);
            }
        }
        if (page[0])
        {
            page[0].SetActive(true);
        }
        isActive = page[0];
        StepCount = 0;
    }
    public void Left()
    {
        StepCount -= 1;
        isActive.SetActive(false);
        page[StepCount].SetActive(true);
        isActive = page[StepCount];
    }
    public void Right()
    {
        StepCount += 1;
        isActive.SetActive(false);
        page[StepCount].SetActive(true);
        isActive = page[StepCount];
    }
    public void Esc()
    {
        ControlToggle.isOn = false;
    }
}
