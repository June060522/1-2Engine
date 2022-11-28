using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPlayManager : MonoBehaviour
{
    [SerializeField] protected GameObject throwFood;
    [SerializeField] protected CBirdRotate cBirdRotate;
    [SerializeField] protected AudioClip attackClip;
    [SerializeField] protected AudioClip rightClip;

    [SerializeField] float hp;
    public float Hp{get => hp; set => hp = value;}
    [SerializeField] float speed;
    public float Speed{get => speed; set => speed = value;}
    [SerializeField] float jumpPower;
    public float JumpPower{get => jumpPower; set => jumpPower = value;}

    protected SpriteRenderer spriteRenderer;

    public bool isAlive = true;

    protected Rigidbody2D rb2D;

    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
}
