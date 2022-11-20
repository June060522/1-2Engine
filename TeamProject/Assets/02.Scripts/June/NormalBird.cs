using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Team
{
    right = 1,
    left = 2
}
public class NormalBird : Bird
{
    private float time = 0f;
    [SerializeField] Team team = Team.right;
    private void OnEnable()
    {
        if(team == Team.right)
        {
            dir = Vector2.left;
        }
        else
        {
            dir = Vector2.right;
        }
    }

    private void Update()
    {
        if(canMove)
            IMove(dir,speed);

        if(!canMove)
        {
            time += Time.deltaTime;
            if(time >= 2f)
            {
                time = 0f;
                canMove = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Bird") && team != other.GetComponent<NormalBird>().team)
        {
            IFight(other.GetComponent<Bird>().birdSize);
        }

        if(other.CompareTag("Door"))
        {
            throw new System.NotImplementedException();
        }
    }
}
