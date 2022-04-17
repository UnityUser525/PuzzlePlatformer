using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowballScript : MonoBehaviour
{
    public float speed;

    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * speed);
    }
}
