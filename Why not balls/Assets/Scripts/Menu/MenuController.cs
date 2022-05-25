using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void PlayHoverSound()
    {
        FindObjectOfType<AudioManager>().Play("hoverOnButton");
    }

    public void PlaySelectSound()
    {
        FindObjectOfType<AudioManager>().Play("clickOnButton");
    }

}
