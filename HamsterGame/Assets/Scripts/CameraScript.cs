using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    private Camera mainCamera;
    private GameObject deathCanvas;

    public Vector3 targetPos;

    private float zoomDistance;
    private float distance;

    private bool zoomTime = false;
    public float zoomSize;

    public float zoomSpeed;
    public float speed;

    private void Start()
    {
        mainCamera = gameObject.GetComponent<Camera>();
        deathCanvas = GameObject.Find("Death Canvas");
        deathCanvas.SetActive(false);
    }

    private void FixedUpdate()
    {
        if (zoomTime == true)
        {
            gameObject.transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * distance);
            
            mainCamera.orthographicSize = Mathf.MoveTowards(mainCamera.orthographicSize, zoomSize, zoomSpeed * zoomDistance);

            if (mainCamera.transform.position == targetPos && mainCamera.orthographicSize == zoomSize)
            {
                zoomTime = false;
                deathCanvas.SetActive(true);
            }
        }

        // add 'DeathCanvas' with restart button that appears when the camera is zoomed in
    }

    public void ZoomPlayer(GameObject player)
    {
        targetPos = new Vector3 (player.transform.position.x, player.transform.position.y + 1, transform.position.z);

        zoomDistance = mainCamera.orthographicSize - zoomSize;
        distance = Vector3.Distance(targetPos, new Vector3(transform.position.x, transform.position.y, targetPos.z));

        zoomTime = true;
    }
}
