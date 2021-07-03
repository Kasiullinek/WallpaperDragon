using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    private GameManager gameManagerS;
    private AudioSource playerAudio;
    public AudioClip collectingSound;
    private float timeToDestroyPlane = 1f;

    // Start is called before the first frame update
    void Start()
    {
        gameManagerS = GameObject.Find("GameManager").GetComponent<GameManager>();
        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        //When the player hit the plane
        if (collision.gameObject.CompareTag("Enemy"))
        {
            gameManagerS.RemoveLives(1);
            Destroy(collision.gameObject, timeToDestroyPlane);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //When the player hit the ball
        if (other.gameObject.CompareTag("Ball"))
        {
            Destroy(other.gameObject);
            playerAudio.PlayOneShot(collectingSound, 1.0f);
            gameManagerS.AddScore(5);
        }
    }
}
