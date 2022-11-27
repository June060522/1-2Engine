using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{
    [SerializeField] PlayerName playerName = PlayerName.Lplayer;
    [SerializeField] PlayerManager playerManager;
    private SpriteRenderer spR;
    private float maxHp;
    private void Awake()
    {
        spR = GetComponent<SpriteRenderer>();
    }
    private void Start()
    {
        maxHp = playerManager.Hp;
    }
    private void Update()
    {
        if (playerName == PlayerName.Lplayer)
            spR.color = new Color(1, playerManager.Hp / maxHp, playerManager.Hp / maxHp);
        if (playerName == PlayerName.Rplayer)
            spR.color = new Color(playerManager.Hp / maxHp, playerManager.Hp / maxHp, 1);
    }
}
