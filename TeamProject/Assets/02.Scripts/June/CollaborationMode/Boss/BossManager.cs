using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossManager : MonoBehaviour , IBoss
{
    [SerializeField] float hp;
    public float Hp{get => hp; set => hp = value;}

    [SerializeField] float power;
    public float Power{get => power; set => power = value;}

    [SerializeField] protected CLPlayer cLPlayer;
    [SerializeField] protected CRPlayer cRPlayer;
    [SerializeField] protected TurnObject turnObject;
    [SerializeField] protected GameObject attack;
    [SerializeField] protected AudioClip wing;

    protected GameObject target = null;
    protected float x;
    protected float time = 0;
    protected SpriteRenderer spriteRenderer;

    protected int pattern = 0;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void IAttack(GameObject target, float attackDelay)
    {
        throw new System.NotImplementedException();
    }

    public void IMove(Vector2 dir, float speed)
    {
        throw new System.NotImplementedException();
    }

    public void IOnDamage(float damage)
    {
        hp-= damage;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.CompareTag("Bird"))
        {
            other.GetComponent<CPlayManager>().Hp -= power;
        }
    }
}
