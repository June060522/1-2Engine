using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadMove : MonoBehaviour
{
    float rotationSpeed = 1f;
    [SerializeField] PlayerName playerName = PlayerName.Lplayer;
    [SerializeField] LPlayer lPlayer;
    [SerializeField] RPlayer rPlayer;

    float rotZ = 0;

    bool isCo = true;
    void Start()
    {
        StartCoroutine(Move());
    }

    void Update()
    {
        if(playerName == PlayerName.Lplayer)
            rotationSpeed = 1 * 10 / lPlayer.Hp;
        else if(playerName == PlayerName.Rplayer)
            rotationSpeed = 1 * 10 / rPlayer.Hp;

        if(((playerName == PlayerName.Lplayer && lPlayer.isMove) || lPlayer.GameOver) || ((playerName == PlayerName.Rplayer && rPlayer.isMove) || rPlayer.GameOver))
        {
            StopAllCoroutines();
            isCo = false;
        }
        else if((playerName == PlayerName.Rplayer && !isCo) || (playerName == PlayerName.Lplayer && !isCo))
        {
            StartCoroutine(Move());
            rotZ = 0;
        }

    }

    IEnumerator Move()
    {
        isCo = true;
        if(playerName == PlayerName.Lplayer)
        {
            for(; rotZ < 6; rotZ += rotationSpeed)
            {
                transform.rotation = Quaternion.Euler(0,0,rotZ);
                yield return new WaitForSeconds(0.01f);
            }
            for(; rotZ > -6; rotZ -= rotationSpeed)
            {
                transform.rotation = Quaternion.Euler(0,0,rotZ);
                yield return new WaitForSeconds(0.01f);
            }
            yield return StartCoroutine(Move());
        }
        else if(playerName == PlayerName.Rplayer)
        {
            for(; rotZ < 6; rotZ += rotationSpeed)
            {
                transform.rotation = Quaternion.Euler(0,180,rotZ);
                yield return new WaitForSeconds(0.01f);
            }
            for(; rotZ > -6; rotZ -= rotationSpeed)
            {
                transform.rotation = Quaternion.Euler(0,180,rotZ);
                yield return new WaitForSeconds(0.01f);
            }
            
            yield return StartCoroutine(Move());
        }
    }
}
