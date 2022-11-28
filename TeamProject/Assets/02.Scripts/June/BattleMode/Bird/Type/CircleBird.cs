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
            if (time >= 1.3f)
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

            if(team == Team.right)
            {
                PoolManager.Instance.Pop(FightImage,transform.position,Quaternion.identity);
                EffectAudio.Instance.ListenEff(fightClip);
            }
        }

        if (other.CompareTag("Window"))
        {
            Window window = other.GetComponent<Window>();
            if (window.team != team && window.Hp > 0)
            {
                window.Damage(power);
                PoolManager.Instance.Push(this.gameObject);
            }
            else if(window.team != team && window.Hp <= 0)
            {
                if(team == Team.right)
                {
                    lPlayer.Hp -= power;
                }
                else if(team == Team.left)
                {
                    rPlayer.Hp -= power;
                }
                PoolManager.Instance.Push(this.gameObject);
            }
        }
    }
}
