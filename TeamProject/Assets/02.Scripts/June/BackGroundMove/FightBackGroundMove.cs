using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightBackGroundMove : MonoBehaviour
{
    void Update()
    {
        transform.position -= new Vector3(0.0005f,0,0);
        if(transform.position.x < -27.75)
            transform.position = new Vector3(23.35f,0f,0);
    }
}
