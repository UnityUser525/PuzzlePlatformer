using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private GameManager gameManager;

    private Animator playerAnimator;
    private SpriteRenderer playerSpriteRenderer;

    public float accelerate;
    public float maxSpeed;
    public float jumpPow;
    public bool onGround = false;
    public int direction;
    public Rigidbody2D playerRB;

    public KeyCode upKey;
    public KeyCode leftKey;
    public KeyCode rightKey;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        playerRB = gameObject.GetComponent<Rigidbody2D>();
        playerAnimator = gameObject.GetComponent<Animator>();
        playerSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.gameOver == true)
        {
            if (playerAnimator.GetInteger("StateNum") != 0 && onGround == true)
            {
                playerAnimator.SetInteger("StateNum", 1);
            }
            return;
        }

        BasicAnim();
        Jump();
    }

    private void FixedUpdate()
    {
        if (gameManager.gameOver == true)
        {
            return;
        }

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
            playerSpriteRenderer.flipX = true;
        }
        else if (Input.GetKey(rightKey))
        {
            direction = 1;
            playerSpriteRenderer.flipX = false;
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

    private bool playJumpAnim = false;
    private void Jump()
    {
        if (Input.GetKeyDown(upKey) && onGround == true)
        {
            playerRB.AddForce(Vector2.up * jumpPow);
            playJumpAnim = true;
        }
    }

    private bool jumpAnimPlayed = false;
    private void BasicAnim()
    {
        if (onGround == false && jumpAnimPlayed == false && playJumpAnim == true)
        {
            playerAnimator.SetInteger("StateNum", 3);
            jumpAnimPlayed = true;
            playJumpAnim = false;
            
        }
        else if (onGround == true)
        {
            jumpAnimPlayed = false;

            if (direction == 0)
            {
                playerAnimator.SetInteger("StateNum", 1);
            }
            else
            {
                playerAnimator.SetInteger("StateNum", 2);
            }
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


    public void otherPlayerDie(GameObject deadPlayer)
    {
        if (deadPlayer.transform.position.x > transform.position.x)
        {
            playerSpriteRenderer.flipX = false;
        }
        else
        {
            playerSpriteRenderer.flipX = true;
        }

        playerAnimator.SetInteger("StateNum", 0);
    }


    public void playerDie()
    {
        if (gameManager.gameOver == false)
        {
            GameObject.Find("Game Manager").GetComponent<GameManager>().PlayerDie(gameObject);
        }
    }
}
