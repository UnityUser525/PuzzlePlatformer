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

    public List<GameObject> objectOnTopList = new List<GameObject>();


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

        for (int i = 0; i < objectOnTopList.Count; i++)
        {
            objectOnTopList[i].transform.position = Vector2.MoveTowards(objectOnTopList[i].transform.position, new Vector2(targetPos.x + (objectOnTopList[i].transform.position.x - gameObject.transform.position.x), targetPos.y + (objectOnTopList[i].transform.position.y - gameObject.transform.position.y)), speed * Time.deltaTime);
        }


        gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, targetPos, speed * Time.deltaTime);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (objectOnTopList.Contains(collision.gameObject) == false && collision.gameObject.GetComponent<Rigidbody2D>() != null && collision.gameObject.GetComponent<Rigidbody2D>().bodyType == RigidbodyType2D.Dynamic)
        {
            objectOnTopList.Add(collision.gameObject);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (objectOnTopList.Contains(collision.gameObject))
        {
            objectOnTopList.Remove(collision.gameObject);
        }
    }
}
