using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    // Start is called before the first frame update
    public void doSlowmotion(float slowdownFactor)
    {
        Time.timeScale = slowdownFactor;
    }
    public void undoSlowmotion()
    {
        Time.timeScale = 1f;
    }
}
