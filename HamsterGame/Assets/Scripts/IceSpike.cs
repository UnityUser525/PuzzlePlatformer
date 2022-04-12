using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceSpike : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player1") == true || collision.gameObject.CompareTag("Player2") == true)
        {
            collision.gameObject.GetComponent<PlayerScript>().playerDie();
        }
    }
}
