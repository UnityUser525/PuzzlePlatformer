using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    public GameManager gameManager;

    void Start()
    {
        if (GameObject.Find("Game Manager") != null)
        {
            gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        }
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene("Level" + (gameManager.levelNum + 1));
    }

    public void LoadScene (string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
