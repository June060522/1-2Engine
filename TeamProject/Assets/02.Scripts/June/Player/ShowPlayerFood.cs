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

    private bool check = true;

    void Update()
    {
        if (check)
        {
            if (playerName == PlayerName.Lplayer)
            {
                playerMaxFood = lPlayer.BirdFood;
                lPlayer.BirdFood = 0;
            }
            else if (playerName == PlayerName.Rplayer)
            {
                playerMaxFood = rPlayer.BirdFood;
                rPlayer.BirdFood = 0;
            }
            check = false;
        }
        if (playerName == PlayerName.Lplayer)
            FoodSlider.value = lPlayer.BirdFood / playerMaxFood;
        else if (playerName == PlayerName.Rplayer)
            FoodSlider.value = rPlayer.BirdFood / playerMaxFood;

    }
}
