using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 250;
    private float topBound = 7;
    private float bottomBound = -7;

    public Rigidbody playerRb;
    private GameManager gameManagerS;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        gameManagerS = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManagerS.isGameActive == true)
        {
            //While the player press key input
            if (Input.GetKeyDown(KeyCode.Space))
            {
                playerRb.AddForce(Vector3.up * speed, ForceMode.Impulse);
            }

            // If the player is too high
            if (transform.position.y >= topBound)
            {
                transform.position = new Vector3(transform.position.x, topBound, transform.position.z);
            }

            // If the player is too low
            if (transform.position.y <= bottomBound)
            {
                transform.position = new Vector3(transform.position.x, bottomBound, transform.position.z);
            }
        }
    }
    
}
