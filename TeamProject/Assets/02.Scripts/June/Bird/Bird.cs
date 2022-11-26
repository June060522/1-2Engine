using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour, IBird
{
    protected Vector2 dir;
    protected bool canMove = true;
    public BirdType birdSize;
    [SerializeField] protected float speed = 1f;
    public float needFood = 1f;
    public Team team = Team.right;
    [SerializeField] protected int hp = 1;
    LPlayer lPlayer;
    RPlayer rPlayer;
    private int Hp = 0;
    protected float time = 0f;
    private void Awake()
    {
        Hp = hp;
        lPlayer = GameObject.Find("LPlayer").GetComponent<LPlayer>();
        rPlayer = GameObject.Find("RPlayer").GetComponent<RPlayer>();
    }

    private void OnEnable()
    {
        hp = Hp;
    }

    public void IFight(BirdType birdType)
    {
        if (birdSize == birdType || (birdSize != birdType && birdSize == BirdType.Small))
            hp--;
        else
            canMove = false;
    }

    public void IMove(Vector2 dir, float speed = 1)
    {
        transform.Translate(dir * speed * Time.deltaTime);
    }

    private void OnDisable()
    {
        time =2f;
        if(team == Team.left)
            lPlayer.nowSpawn--;
        else if(team == Team.right)
            rPlayer.nowSpawn--;
    }
}
