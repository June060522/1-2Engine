using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollaborationBackGroundMove : MonoBehaviour
{
    void Update()
    {
        transform.position -= new Vector3(0.004f,0,0);
        if(transform.position.x < -19)
            transform.position = new Vector3(19,0,0);
    }
}
