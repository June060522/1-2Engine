using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    private float gravityScale = 50f;
    
    private void Start()
    {
        gravityScale *= Time.deltaTime;
    }
    private void Update()
    {
        transform.position += -transform.up * gravityScale * Time.deltaTime;
    }
}
