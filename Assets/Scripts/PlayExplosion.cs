using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayExplosion : MonoBehaviour
{
    public ParticleSystem explosion;
    public AudioSource explosionSound;
    private GameManager gameManagerS;

    // Start is called before the first frame update
    void Start()
    {
        gameManagerS = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            explosionSound.Play();
            explosion.Play();
        }
    }
}
