using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour, IBird
{
    protected Vector2 dir;
    protected bool canMove = true;
    public BirdType birdSize;
    [SerializeField]protected float speed = 1f;
    public float needFood = 1f;
    public Team team = Team.right;

    public void IFight(BirdType birdType)
    {
        if(birdSize == birdType || (birdSize != birdType && birdSize == BirdType.Small))
            PoolManager.Instance.Push(this.gameObject);
        else
            canMove = false;
    }

    public void IMove(Vector2 dir, float speed = 1)
    {
        transform.Translate(dir * speed * Time.deltaTime);
    }
}
