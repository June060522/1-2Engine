using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoadName : MonoBehaviour
{
    [SerializeField] PlayerName playerName = PlayerName.Lplayer;
    [SerializeField] TextMeshProUGUI nameTxt;
    private void Awake()
    {
        nameTxt = GetComponent<TextMeshProUGUI>();
    }
    void Start()
    {
        if (playerName == PlayerName.Lplayer)
        {
            if(PlayerPrefs.GetString("RPlayerName") == "")
                nameTxt.text = "Player1";
            else
                nameTxt.text = "Player1 : "+ PlayerPrefs.GetString("LPlayerName");
        }
        else if (playerName == PlayerName.Rplayer)
        {
            if(PlayerPrefs.GetString("RPlayerName") == "")
                nameTxt.text = "Player2";
            else
                nameTxt.text = "Player2" + PlayerPrefs.GetString("RPlayerName");
        }
    }
}
