using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonScript : MonoBehaviour
{
    public GameObject snowBall;
    public GameObject firePoint;
    public GameObject nozzle;

    public GameObject player1;
    public GameObject player2;
    private GameManager gameManager;
    private GameObject targetPlayer;

    public bool lockCannon;
    public float fireDelay;
    public float rotationSpeed;

    private bool player1Seen;
    private bool player2Seen;
    private float player1Distance;
    private float player2Distance;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        player1 = GameObject.Find("Player1");
        player2 = GameObject.Find("Player2");
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.gameOver == true)
        {
            return;
        }

        if (lockCannon == true)
        {
            StartCoroutine(ShootSnowball());
        }
        else
        {
            RaycastHit2D player1Target = Physics2D.Raycast(transform.position + ((player1.transform.position - transform.position).normalized * transform.localScale.y), player1.transform.position - transform.position);

            if (player1Target.collider.gameObject.CompareTag("Player1") || player1Target.collider.gameObject.CompareTag("Snowball"))
            {
                player1Distance = Vector2.Distance(transform.position, player1.transform.position);
                player1Seen = true;
            }
            else
            {
                player1Seen = false;
            }

            RaycastHit2D player2Target = Physics2D.Raycast(transform.position + ((player2.transform.position - transform.position).normalized * transform.localScale.y), player2.transform.position - transform.position);

            if (player2Target.collider.gameObject.CompareTag("Player2") || player2Target.collider.gameObject.CompareTag("Snowball"))
            {
                player2Distance = Vector2.Distance(transform.position, player2.transform.position);
                player2Seen = true;
            }
            else
            {
                player2Seen = false;
            }

            if (player1Seen == true && player2Seen == true)
            {
                if (player1Distance < player2Distance)
                {
                    targetPlayer = player1;
                }
                else
                {
                    targetPlayer = player2;
                }
            }
            else if (player1Seen == true)
            {
                targetPlayer = player1;
            }
            else if (player2Seen == true)
            {
                targetPlayer = player2;
            }

            if (player1Seen == true || player2Seen == true)
            {
                float targetAngle = Mathf.Atan2(targetPlayer.transform.position.y - transform.position.y, targetPlayer.transform.position.x - transform.position.x) * Mathf.Rad2Deg;
                Quaternion rotation = Quaternion.AngleAxis(targetAngle, Vector3.forward);
                nozzle.transform.rotation = Quaternion.Slerp(nozzle.transform.rotation, rotation, rotationSpeed * Time.deltaTime);
            }

            RaycastHit2D nozzleDirection = Physics2D.Raycast(firePoint.transform.position, firePoint.transform.position - transform.position);

            if (nozzleDirection.collider.gameObject.CompareTag("Player1") || nozzleDirection.collider.gameObject.CompareTag("Player2"))
            {
                StartCoroutine(ShootSnowball());
            }
        }
    }



    private bool reloadFinish = true;
    IEnumerator ShootSnowball()
    {
        if (reloadFinish == true)
        {
            reloadFinish = false;

            Instantiate(snowBall, firePoint.transform.position, nozzle.transform.rotation);

            yield return new WaitForSeconds(fireDelay);

            reloadFinish = true;
        }

    }
}
