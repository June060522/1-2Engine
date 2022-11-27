using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollaborationBackGroundMove : MonoBehaviour
{
    void Update()
    {
        transform.Translate(Vector3.left * 0.004f);
        if(transform.position.x < -38)
            transform.position = new Vector3(38,0,0);
    }
}
