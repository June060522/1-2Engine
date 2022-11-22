using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowPlayerFood : MonoBehaviour
{
    [SerializeField] Slider FoodSlider;
    [SerializeField] RPlayer rPlayer;
    [SerializeField] LPlayer lPlayer;
    [SerializeField] PlayerName playerName = PlayerName.Lplayer;
    private float playerMaxFood = 0f;
    void Start()
    {
        if(playerName == PlayerName.Lplayer)
            playerMaxFood = lPlayer.BirdFood;
        else if(playerName == PlayerName.Rplayer)
            playerMaxFood = rPlayer.BirdFood;
    }

    
    void Update()
    {
        if(playerName == PlayerName.Lplayer)
            FoodSlider.value = lPlayer.BirdFood / playerMaxFood;
        else if(playerName == PlayerName.Rplayer)
            FoodSlider.value = rPlayer.BirdFood / playerMaxFood;
    }
}
