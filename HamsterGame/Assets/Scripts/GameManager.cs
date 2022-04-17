using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int levelNum;
    public bool gameOver = false;

    public GameObject nextLevelButton;
    public GameObject explotionAnim;

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
            gameOver = true;

            if (PlayerPrefs.GetInt("LevelGotTo") <= levelNum)
            {
                PlayerPrefs.SetInt("LevelGotTo", levelNum + 1);
            }

            nextLevelButton.SetActive(true);
        }
    }

    public void PlayerDie(GameObject deadPlayer)
    {
        gameOver = true;

        if (deadPlayer == player1)
        {
            player2.GetComponent<PlayerScript>().otherPlayerDie(player1);
            cameraScript.ZoomPlayer(player2);
            Instantiate(explotionAnim, deadPlayer.transform.position, Quaternion.identity);
        }
        else
        {
            player1.GetComponent<PlayerScript>().otherPlayerDie(player2);
            cameraScript.ZoomPlayer(player1);
            Instantiate(explotionAnim, deadPlayer.transform.position, Quaternion.identity);
        }

        Destroy(deadPlayer);
    }
}
