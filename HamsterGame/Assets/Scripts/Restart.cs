using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void RestartGame()
    {
        PlayerPrefs.SetInt("LevelGotTo", 1);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
