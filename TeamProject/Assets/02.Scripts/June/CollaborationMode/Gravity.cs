using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    private float gravityScale = 1f;
    Rigidbody2D rb2d;
    private void Awake()
    {
        rb2d =GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        gravityScale *= Time.deltaTime;
    }
    private void Update()
    {
//        transform.position += -transform.up * gravityScale * Time.deltaTime;
        rb2d.AddForce(-transform.up * gravityScale,ForceMode2D.Impulse);
    }
}
