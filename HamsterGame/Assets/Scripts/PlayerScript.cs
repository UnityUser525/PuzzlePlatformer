using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float accelerate;
    public float maxSpeed;
    public float jump;
    public bool onGround = false;
    public int direction;
    public Rigidbody2D playerRB;

    public KeyCode upKey;
    public KeyCode leftKey;
    public KeyCode rightKey;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
    }

    private void FixedUpdate()
    {
        Movement();
    }

    private void Movement()
    {
        if (Input.GetKey(leftKey) && Input.GetKey(rightKey))
        {
            direction = 0;
        }
        else if (Input.GetKey(leftKey))
        {
            direction = -1;
        }
        else if (Input.GetKey(rightKey))
        {
            direction = 1;
        }
        else
        {
            direction = 0;
        }

        if ((direction > 0 && playerRB.velocity.x <= maxSpeed) || (direction < 0 && playerRB.velocity.x >= (-1 * maxSpeed)))
        {
            playerRB.AddForce(new Vector2(direction * accelerate, 0));
        }
    }

    private void Jump()
    {
        if (Input.GetKeyDown(upKey) && onGround == true)
        {
            playerRB.AddForce(Vector2.up * jump);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.isTrigger == false)
        {
            onGround = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        onGround = false;
    }
    

    public void playerDie()
    {
        GameObject.Find("Game Manager").GetComponent<GameManager>().PlayerDie(gameObject);
    }
}
