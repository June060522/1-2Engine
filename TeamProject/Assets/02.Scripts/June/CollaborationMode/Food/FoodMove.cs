using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodMove : MonoBehaviour
{
    public Dir dir = Dir.left;
    void Update()
    {
        if(dir == Dir.right)
            transform.position += new Vector3(1,0,0) * 3 * Time.deltaTime;
        else if(dir == Dir.left)
            transform.position += new Vector3(-1,0,0) * 3 * Time.deltaTime;

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
