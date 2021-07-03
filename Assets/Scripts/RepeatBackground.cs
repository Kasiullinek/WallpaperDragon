using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Vector3 startPos;
    private float repeatWidth;
    public float speed;

    private GameManager gameManagerS;

    // Start is called before the first frame update
    void Start()
    {
        gameManagerS = GameObject.Find("GameManager").GetComponent<GameManager>();
        startPos = transform.position;
        repeatWidth = GetComponent<BoxCollider>().size.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManagerS.isGameActive == true)
        {
            transform.Translate(Vector3.right * -speed * Time.deltaTime);

            if (transform.position.x < startPos.x - repeatWidth)
            {
                transform.position = startPos;
            }   
        }
    }
}
