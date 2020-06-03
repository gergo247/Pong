using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    // Start is called before the first frame update
   public float ballSpeed = 100;
    void Start()
    {
            StartCoroutine(WaitForBall(3f));

    }
    IEnumerator WaitForBall(float sec)
    {
        yield return new WaitForSeconds(sec);
        GoBall();
    }
    // Update is called once per frame
    void Update()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        float xVel = rb.velocity.x;
       // Debug.Log("Velocity:" + xVel);
        // != 0 xvel is 0 on start
        if (xVel < 18 && xVel > -18 && xVel != 0)
        {
            //goin right
            if (xVel >0)
            {
                rb.velocity = new Vector2(20, rb.velocity.y);
            }
            else
            {// goin left
                rb.velocity = new Vector2(-20, rb.velocity.y);

            }
        }
    }


    public AudioSource audioClip;
    void OnCollisionEnter2D(Collision2D colInfo)
    {
        if (colInfo.collider.tag == "Player")
        {
           // Debug.Log("Hit player");
            //acceleration
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            float velY = rb.velocity.y;
            velY = velY / 2 + colInfo.collider.attachedRigidbody.velocity.y / 3;

            rb.velocity = new Vector2(rb.velocity.x, velY);
            //audio
            //Debug.Log("audio");

            GetComponent<AudioSource>().pitch = Random.Range(0.8f, 1.2f);
            GetComponent<AudioSource>().Play();
        }
    }

    void ResetBall()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, 0);
        transform.position = new Vector2(0,0);
        StartCoroutine(WaitForBall(0.5f));

    }
    void GoBall()
    {
        float randomNumber = Random.Range(0, 1);
        if (randomNumber <= 0.5)
        {
            Debug.Log("Shoot right");
            GetComponent<Rigidbody2D>().AddForce(new Vector2(ballSpeed, 10));
        }
        else
        {
            Debug.Log("Shoot left");
            GetComponent<Rigidbody2D>().AddForce(new Vector2(-ballSpeed, -10));

        }
    }
}
