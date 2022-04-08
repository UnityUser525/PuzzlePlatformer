using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int levelNum;
    public GameObject nextLevelButton;

    public Door door1;
    public Door door2;

    public GameObject player1;
    public GameObject player2;

    public CameraScript cameraScript;

    void Start()
    {
        door1 = GameObject.Find("Door1").GetComponent<Door>();
        door2 = GameObject.Find("Door2").GetComponent<Door>();

        player1 = GameObject.Find("Player1");
        player2 = GameObject.Find("Player2");

        cameraScript = GameObject.Find("Main Camera").GetComponent<CameraScript>();
    }

    public void WinLevel()
    {
        if (door1.atDoor == true && door2.atDoor == true)
        {
            if (PlayerPrefs.GetInt("LevelGotTo") <= levelNum)
            {
                PlayerPrefs.SetInt("LevelGotTo", levelNum + 1);
            }

            nextLevelButton.SetActive(true);
        }
    }

    public void PlayerDie(GameObject deadPlayer)
    {
        if (deadPlayer == player1)
        {
            cameraScript.ZoomPlayer(player2);
        }
        else
        {
            cameraScript.ZoomPlayer(player1);
        }
    }
}
