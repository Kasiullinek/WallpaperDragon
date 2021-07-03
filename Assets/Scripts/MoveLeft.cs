using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private Rigidbody Rb;

    public float speed;
    private float destroyBound = -22;

    // Start is called before the first frame update
    void Start()
    {
        Rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Rb.AddForce(Vector3.right * -speed, ForceMode.Impulse);

        if(transform.position.x < destroyBound)
        {
            Destroy(gameObject);
        }
    }
}
