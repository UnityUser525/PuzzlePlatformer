using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcicleScript : MonoBehaviour
{
    private bool startFalling = false;

    public float fallSpeed;

    private void Update()
    {
        Falling();
    }

    private void FixedUpdate()
    {
        if (startFalling == false)
        {
            RaycastHit2D objectHit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - (0.5f * transform.localScale.y)), Vector2.down);

            if (objectHit.collider.gameObject.CompareTag("Player1") || objectHit.collider.gameObject.CompareTag("Player2"))
            {
                startFalling = true;
            }
        }
    }

    private void Falling()
    {
        if (startFalling == true)
        {
            transform.Translate(Vector3.down * Time.deltaTime * fallSpeed);
        }
    }
}
