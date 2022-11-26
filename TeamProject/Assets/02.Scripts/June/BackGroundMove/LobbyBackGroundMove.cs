using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyBackGroundMove : MonoBehaviour
{
    void Update()
    {
        transform.position -= new Vector3(0.01f,0,0);
        if(transform.position.x < -21.6)
            transform.position = new Vector3(21.6f,-1.1f,0);
    }
}
