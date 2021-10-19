using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    PlayerMovement thePlayer;
    private Vector3 lastPlayerPosition;
    private float distanceBetween;
    private void Start()
    {
        thePlayer = FindObjectOfType<PlayerMovement>();
        lastPlayerPosition = thePlayer.transform.position;
    }



    // Update is called once per frame
    void LateUpdate()
    {
        distanceBetween = thePlayer.transform.position.x - lastPlayerPosition.x;
        transform.position = new Vector3(transform.position.x + distanceBetween, transform.position.y, transform.position.z);

        lastPlayerPosition = thePlayer.transform.position;
    }
}
