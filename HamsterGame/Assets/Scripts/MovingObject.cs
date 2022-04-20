using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
    public ActivatorScript activatorScript;

    public float speed;
    public bool oneTime;
    private bool oneTimeDone = false;

    public GameObject point1;
    public GameObject point2;

    public Vector2 targetPos;

    private bool playerOnBool = false;
    private GameObject playerOntop;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.position = point1.transform.position;

        activatorScript = gameObject.GetComponent<ActivatorScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (activatorScript.isActive == true && (oneTimeDone == false || oneTime == false))
        {
            oneTimeDone = true;
            targetPos = point2.transform.position;
        }
        else if (oneTimeDone == false || oneTime == false)
        {
            targetPos = point1.transform.position;
        }

        moveToward();
    }

    private float pastPosX = 0;
    public float playerAdjust;
    private void moveToward()
    {
        playerAdjust = transform.position.x - pastPosX;
        pastPosX = transform.position.x;

        if (playerOnBool == true)
        {
            playerOntop.transform.position = Vector2.MoveTowards(playerOntop.transform.position, new Vector2(targetPos.x + (playerOntop.transform.position.x - gameObject.transform.position.x), targetPos.y + (playerOntop.transform.position.y - gameObject.transform.position.y)), speed * Time.deltaTime);
        }
        gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, targetPos, speed * Time.deltaTime);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player1") || collision.gameObject.CompareTag("Player2"))
        {
            playerOnBool = true;
            playerOntop = collision.gameObject;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player1") || collision.gameObject.CompareTag("Player2"))
        {
            playerOnBool = false;
        }
    }
}
