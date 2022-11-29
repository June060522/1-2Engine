using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpawnCol : MonoBehaviour
{
    public static SpawnCol Instance;
    public float[] LplayerSpawnCool;
    public float[] RplayerSpawnCool;
    public float[] LplayerNowSpawnCool;
    public float[] RplayerNowSpawnCool;
    public TextMeshProUGUI[] text;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("Multiple GameManager is running!");
        }
        Instance = this;
    }
    private void Update()
    {
        for (int i = 0; i < 4; i++)
        {
            LplayerNowSpawnCool[i] += Time.deltaTime;
            if (LplayerNowSpawnCool[i] > 3)
            {
                text[i].text = "";
            }
            else
            {
                text[i].text = $"{(int)(LplayerSpawnCool[i] - LplayerNowSpawnCool[i])}초";
            }
        }
        for (int i = 0; i < 4; i++)
        {
            RplayerNowSpawnCool[i] += Time.deltaTime;
            if (RplayerNowSpawnCool[i] > 3)
            {
                text[i + 4].text = "";
            }
            else
            {
                text[i + 4].text = $"{(int)(RplayerSpawnCool[i] - RplayerNowSpawnCool[i])}초";
            }
        }
    }
}
