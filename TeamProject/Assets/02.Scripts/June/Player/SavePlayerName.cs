using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public enum PlayerName
{
    Lplayer = 1,
    Rplayer = 2
}
public class SavePlayerName : MonoBehaviour
{
    [SerializeField] PlayerName playerName = PlayerName.Lplayer;
    [SerializeField] TextMeshProUGUI pName;
    private void Awake()
    {
        pName = GetComponent<TextMeshProUGUI>();
    }
    private void Update()
    {
        if(playerName == PlayerName.Lplayer)
        {
            if(pName.text.Length <= 8)
                PlayerPrefs.SetString("LPlayerName",pName.text);
        }
        else if(playerName == PlayerName.Rplayer)
        {
            if(pName.text.Length <= 8)
                PlayerPrefs.SetString("RPlayerName",pName.text);
        }
    }
}
