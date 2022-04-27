using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour
{
    public GameObject pauseMenu;
    private bool paused = false;

    public void pauseLevel()
    {
        if (paused == false)
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
            paused = true;
        }
        else if (paused == true)
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1;
            paused = false;
        }
    }
}
