using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerHead : MonoBehaviour
{
    float rotationSpeed = 1f;
    [SerializeField] PlayerName playerName = PlayerName.Lplayer;
    [SerializeField] LPlayer lPlayer;
    [SerializeField] RPlayer rPlayer;

    bool isCo = true;
    private void Start()
    {  
        StartCoroutine(PlayerHeadMove());
    }

    private void Update()
    {
        if(playerName == PlayerName.Lplayer)
            rotationSpeed = 1 * 30 / lPlayer.Hp;
        else if(playerName == PlayerName.Rplayer)
            rotationSpeed = 1 * 30 / rPlayer.Hp;

        if(playerName == PlayerName.Rplayer && !rPlayer.isMove)
        {
            StopAllCoroutines();
            isCo = false;
        }
        else if(!isCo)
            StartCoroutine(PlayerHeadMove());

        if(playerName == PlayerName.Lplayer && !lPlayer.isMove)
        {
            StopAllCoroutines();
            isCo = false;
        }
        else if(!isCo)
            StartCoroutine(PlayerHeadMove());
    }

    IEnumerator PlayerHeadMove()
    {
        isCo = true;
        if(playerName == PlayerName.Lplayer)
        {
            DOTween.Sequence().Append(transform.DORotate(new Vector3(0,0,-6),rotationSpeed))
            .OnComplete(() => DOTween.Sequence().Append(transform.DORotate(new Vector3(0,0,6),rotationSpeed))
            .OnComplete(() => StartCoroutine(PlayerHeadMove())));
        }
        else if(playerName == PlayerName.Rplayer)
        {
            DOTween.Sequence().Append(transform.DORotate(new Vector3(0,180,-6),rotationSpeed))
            .OnComplete(() => DOTween.Sequence().Append(transform.DORotate(new Vector3(0,180,6),rotationSpeed))
            .OnComplete(() => StartCoroutine(PlayerHeadMove())));
        }
        yield return null;
    }
}
