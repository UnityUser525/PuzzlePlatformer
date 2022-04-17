using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    public bool destroyOnHit;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player1") == true || collision.gameObject.CompareTag("Player2") == true)
        {
            collision.gameObject.GetComponent<PlayerScript>().playerDie();
        }

        if (destroyOnHit == true)
        {
            Destroy(gameObject);
        }
    }
}
