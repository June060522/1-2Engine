using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowPlayerHp : MonoBehaviour
{
    [SerializeField] Slider hpSlider;
    [SerializeField] RPlayer rPlayer;
    [SerializeField] LPlayer lPlayer;
    [SerializeField] PlayerName playerName = PlayerName.Lplayer;
    private float playerMaxHp = 0f;
    void Start()
    {
        if(playerName == PlayerName.Lplayer)
            playerMaxHp = lPlayer.Hp;
        else if(playerName == PlayerName.Rplayer)
            playerMaxHp = rPlayer.Hp;
    }

    
    void Update()
    {
        if(playerName == PlayerName.Lplayer)
            hpSlider.value = lPlayer.Hp / playerMaxHp;
        else if(playerName == PlayerName.Rplayer)
            hpSlider.value = rPlayer.Hp / playerMaxHp;
    }
}
