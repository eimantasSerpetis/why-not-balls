using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class TimerController : MonoBehaviour
{
    // Start is called before the first frame update
    public float timerLength = 2f;
    public PlayerMovement playerController;
    Slider thisSlider;
    bool doTimer;
    void Start()
    {
        thisSlider = GetComponent<Slider>();
        thisSlider.maxValue = timerLength;
        thisSlider.value = timerLength;
        doTimer = false;

    }

    // Update is called once per frame
    void Update()
    {
        if(thisSlider.value <= 0)
        {
            doTimer = false;
            thisSlider.value = 0;
        }

        if (doTimer)
        {
                thisSlider.value -= Time.unscaledDeltaTime;
        }

    }
    public bool TimerRunning()
    {
        return doTimer;
    }
    public void restartTimer()
    {
        thisSlider.value = timerLength;
        doTimer = true;
    }
    public void startTimer()
    {
        doTimer = true;
    }


    public void Disable()
    {
        gameObject.SetActive(false);
    }
}
