using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript1 : MonoBehaviour
{
    public float acceleration;
    public float maxSpeed;
    public int direction;  
    public float jump;
    public bool onGround = false;
    public Rigidbody2D playerRB;

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
        if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.RightArrow))
        {
            direction = 0;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            direction = -1;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            direction = 1;
        }
        else
        {
            direction = 0;
        }

        if ((direction > 0 && playerRB.velocity.x <= maxSpeed) || (direction < 0 && playerRB.velocity.x >= (-1 * maxSpeed)))
        {
            playerRB.AddForce(new Vector2(direction * acceleration, 0));
        }
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && onGround == true)
        {
            playerRB.AddForce(Vector2.up * jump);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        onGround = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        onGround = false;
    }

}
