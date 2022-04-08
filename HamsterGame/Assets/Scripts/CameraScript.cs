using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Vector3 targetPos;

    private bool zoomTime = false;
    public float zoomSize;
    public float speed;

    private void FixedUpdate()
    {
        if (zoomTime == true)
        {
            gameObject.transform.position = Vector3.MoveTowards(transform.position, targetPos, speed);
            
            gameObject.GetComponent<Camera>().orthographicSize = zoomSize;
        }
    }

    public void ZoomPlayer(GameObject player)
    {
        targetPos = new Vector3 (player.transform.position.x, player.transform.position.y, transform.position.z);
        zoomTime = true;
    }
}
