using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerHead : MonoBehaviour
{
    float rotationSpeed = 1f;
    [SerializeField] PlayerName playerName = PlayerName.Lplayer;
    private void Start()
    {  
        PlayerHeadMove();
    }

    private void PlayerHeadMove()
    {
        if(playerName == PlayerName.Lplayer)
        {
            DOTween.Sequence().Append(transform.DORotate(new Vector3(0,0,-6),rotationSpeed))
            .OnComplete(() => DOTween.Sequence().Append(transform.DORotate(new Vector3(0,0,6),rotationSpeed))
            .OnComplete(()=>PlayerHeadMove()));
        }

        if(playerName == PlayerName.Rplayer)
        {
            DOTween.Sequence().Append(transform.DORotate(new Vector3(0,180,-6),rotationSpeed))
            .OnComplete(() => DOTween.Sequence().Append(transform.DORotate(new Vector3(0,180,6),rotationSpeed))
            .OnComplete(()=>PlayerHeadMove()));
        }
    }
}
