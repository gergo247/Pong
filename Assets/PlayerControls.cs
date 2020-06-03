using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    // Start is called before the first frame update
    //void Start()
    //{

    //}
    //void Start()
    //{
    //    rb = GetComponent<Rigidbody>();
    //}

    private Rigidbody2D rb;



    public KeyCode moveUp; //= Keycode.None;
    public KeyCode moveDown; //= Keycode.None;

    public float speed = 10;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(moveUp))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, speed);
        }
        else
        if (Input.GetKey(moveDown))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, speed*-1);

        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0,0 );

        }
    }
}
