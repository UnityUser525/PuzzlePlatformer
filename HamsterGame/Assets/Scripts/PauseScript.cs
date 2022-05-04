using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour
{
    public GameObject pauseMenu;
    private bool paused = false;

    public GameObject pauseImage;

    public Sprite pauseSprite;
    public Sprite playSprite;

    public void pauseLevel()
    {
        if (paused == false)
        {
            pauseMenu.SetActive(true);
            pauseImage.GetComponent<SpriteRenderer>().sprite = pauseSprite;
            Time.timeScale = 0;
            paused = true;
        }
        else if (paused == true)
        {
            pauseMenu.SetActive(false);
            pauseImage.GetComponent<SpriteRenderer>().sprite = playSprite;
            Time.timeScale = 1;
            paused = false;
        }
    }
}
