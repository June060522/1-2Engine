using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowPosition : MonoBehaviour
{
    [SerializeField] LPlayer lPlayer;
    [SerializeField] RPlayer rPlayer;
    [SerializeField] Team team = Team.right;
    void Update()
    {
        if(team == Team.right)
        {
            transform.position = new Vector2(transform.position.x,3f - (rPlayer.SpawnIndex * 1.5f)); 
        }
        else if(team == Team.left)
        {
            transform.position = new Vector2(transform.position.x,3f - (lPlayer.SpawnIndex * 1.5f));
        }
    }
}
