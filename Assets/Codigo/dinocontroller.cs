using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dinocontroller : MonoBehaviour
{
    private SpriteRenderer sr;
    private Rigidbody2D rb2d;
    private float speed = 5;
    // Start is called before the first frame update
    void Start()
    {
        sr= GetComponent<SpriteRenderer>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        sr.flipX = true;
         rb2d.velocity = new Vector2(-speed,rb2d.velocity.y);
    }
}
