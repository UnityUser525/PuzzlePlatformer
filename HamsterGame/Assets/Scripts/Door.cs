using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameManager gameManager;

    public string playerTag;
    public bool atDoor = false;

    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(playerTag))
        {
            atDoor = true;
            gameManager.WinLevel();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(playerTag))
        {
            atDoor = false;
        }
    }
}
