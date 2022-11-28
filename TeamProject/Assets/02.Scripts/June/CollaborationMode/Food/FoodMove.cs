using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodMove : MonoBehaviour
{
    public Dir dir = Dir.left;
    Rigidbody2D rb2D;
    private bool check = false;
    [SerializeField] protected AudioClip hit;
    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }
    private void OnEnable()
    {
        transform.rotation = Quaternion.Euler(0, 0, TurnObject.Instance.rot);
        check = false;
    }
    void Update()
    {
        if (!check)
        {
            if (dir == Dir.right)
                rb2D.AddForce(transform.right * 2, ForceMode2D.Impulse);
            else if (dir == Dir.left)
                rb2D.AddForce(-transform.right * 2, ForceMode2D.Impulse);
                check = true;
        }
        if (transform.position.x > 14.5f || transform.position.x < -14.5f)
            PoolManager.Instance.Push(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Boss"))
        {
            EffectAudio.Instance.ListenEff(hit);
            other.GetComponent<BossManager>().IOnDamage(1f);
            PoolManager.Instance.Push(gameObject);
        }
    }
}
