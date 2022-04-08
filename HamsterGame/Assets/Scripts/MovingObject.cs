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

    private void moveToward()
    {
        gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, targetPos, speed * Time.deltaTime);
    }
}
