using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleBird : Bird
{
    [SerializeField] private float power;
    
    private void Update()
    {
        if (team == Team.right)
        {
            dir = Vector2.left;
        }
        else
        {
            dir = Vector2.right;
        }
        if (canMove)
        {
            if(team == Team.right)
                IMove(-dir, speed);
            else
                IMove(dir,speed);

        }

        if (!canMove)
        {
            time += Time.deltaTime;
            if (time >= 2f)
            {
                canMove = true;
            }
        }
        if(hp <= 0)
            PoolManager.Instance.Push(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bird") && team != other.GetComponent<Bird>().team)
        {
            time = 0f;
            IFight(other.GetComponent<Bird>().birdSize);
        }

        if (other.CompareTag("Window"))
        {
            if (other.GetComponent<Window>().team != team)
            {
                other.GetComponent<Window>().Damage(power);
                PoolManager.Instance.Push(this.gameObject);
            }
        }
    }
}
