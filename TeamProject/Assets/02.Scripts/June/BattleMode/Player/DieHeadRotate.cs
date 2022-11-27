using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieHeadRotate : MonoBehaviour
{
    float i = 0;
    [SerializeField] PlayerName playerName = PlayerName.Lplayer;
    [SerializeField] LPlayer lPlayer;
    [SerializeField] RPlayer rPlayer;
    
    void Update()
    {
        if((playerName == PlayerName.Lplayer && lPlayer.GameOver) || (playerName == PlayerName.Rplayer && rPlayer.GameOver))
        {
            transform.rotation = Quaternion.Euler(0,0,i);
            i+= 4f;
        }
    }
}
