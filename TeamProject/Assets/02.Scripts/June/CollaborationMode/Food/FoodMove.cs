using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodMove : MonoBehaviour
{
    public Dir dir = Dir.left;
    Rigidbody2D rb2D;
    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }
    private void OnEnable()
    {
        transform.rotation = Quaternion.Euler(0,0,TurnObject.Instance.rot);
        if(dir == Dir.right)
            rb2D.AddForce(-transform.right * 2,ForceMode2D.Impulse);
        else if(dir == Dir.left)
            rb2D.AddForce(transform.right * 2,ForceMode2D.Impulse);
    }
    void Update()
    {
        if(transform.position.x > 9.5f || transform.position.x < -9.5f)
            PoolManager.Instance.Push(gameObject);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Boss"))
        {
            other.GetComponent<BossManager>().IOnDamage(1f);
            PoolManager.Instance.Push(gameObject);
        }
    }
}
