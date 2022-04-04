using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    public int levelNumber;

    public TextMeshProUGUI levelSelectText;

    // Start is called before the first frame update
    void Start()
    {
        levelSelectText = gameObject.GetComponent<TextMeshProUGUI>();

        if (PlayerPrefs.GetInt("LevelGotTo") < 1)
        {
            PlayerPrefs.SetInt("LevelGotTo", 1);
        }

        if (PlayerPrefs.GetInt("LevelGotTo") < levelNumber)
        {
            levelSelectText.text = "X";
        }
        else
        {
            levelSelectText.text = levelNumber.ToString();
        }
    }

    public void SelectLevel()
    {
        if (PlayerPrefs.GetInt("LevelGotTo") >= levelNumber)
        {
            SceneManager.LoadScene("Level" + levelNumber, LoadSceneMode.Single);
        }
    }
}