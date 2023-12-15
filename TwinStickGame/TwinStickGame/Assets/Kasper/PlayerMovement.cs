using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    float speed = 5;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Transform>().position = new Vector3(speed * Input.GetAxis("Horizontal"), 0, 0);
    }

    void FixedUpdate()
    {
        
    }
}
