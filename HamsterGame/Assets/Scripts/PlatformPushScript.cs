using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformPushScript : MonoBehaviour
{
    public float platformPushAdjust;

    private MovingObject movingObject;

    // Start is called before the first frame update
    void Start()
    {
        movingObject = gameObject.GetComponent<MovingObject>();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player1") || collision.gameObject.CompareTag("Player2"))
        {
            if (collision.gameObject.transform.position.x < gameObject.transform.position.x)
            {
                collision.gameObject.transform.Translate(Vector3.left * movingObject.speed * gameObject.transform.lossyScale.x * platformPushAdjust);
            }
            else
            {
                collision.gameObject.transform.Translate(Vector3.right * movingObject.speed * gameObject.transform.lossyScale.x * platformPushAdjust);
            }
        }
    }
}
