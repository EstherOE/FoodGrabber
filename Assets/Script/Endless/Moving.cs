using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    Rigidbody2D body;
    Vector3 target;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        target = transform.localScale;

    }

    // Update is called once per frame
    void Update()
    {
        body.velocity = new Vector2(body.velocity.x,  -speed );

    }
}
