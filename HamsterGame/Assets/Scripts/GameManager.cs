using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int levelNum;
    public GameObject nextLevelButton;

    public Door Door1;
    public Door Door2;

    void Start()
    {
        Door1 = GameObject.Find("Door1").GetComponent<Door>();
        Door2 = GameObject.Find("Door2").GetComponent<Door>();
    }

    public void WinLevel()
    {
        if (Door1.atDoor == true && Door2.atDoor == true)
        {
            if (PlayerPrefs.GetInt("LevelGotTo") <= levelNum)
            {
                PlayerPrefs.SetInt("LevelGotTo", levelNum + 1);
            }

            nextLevelButton.SetActive(true);
        }
    }
}
