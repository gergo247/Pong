using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideWalls : MonoBehaviour
{

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.name == "Ball")
        {
            Debug.Log("why" + hitInfo.name);

            string wallName = transform.name;

            GetComponent<AudioSource>().Play();

            GameManager.Score(wallName);
            hitInfo.gameObject.SendMessage("ResetBall");


        }
    }
}
