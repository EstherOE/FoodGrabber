using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackGround : MonoBehaviour
{
    private Vector3 starpos;

    // Start is called before the first frame update
    void Start()
    {
        starpos = transform.position;    
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x <starpos.x- 23.97)
        {
            transform.position = starpos;
        }
    }
}
