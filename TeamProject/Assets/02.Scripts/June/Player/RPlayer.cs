using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPlayer : PlayerManager, ISummon
{
    private int nowIndex = 1;
    private int spawnIndex = 0;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            nowIndex++;
            if (nowIndex > window.Length - 1)
                nowIndex = 0;
            transform.position = new Vector2(transform.position.x, window[nowIndex].transform.position.y);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            nowIndex--;
            if (nowIndex < 0)
                nowIndex = window.Length - 1;
            transform.position = new Vector2(transform.position.x, window[nowIndex].transform.position.y);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            spawnIndex--;
            if (spawnIndex < 0)
                spawnIndex = birds.Length - 1;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            spawnIndex++;
            if (spawnIndex > birds.Length - 1)
                spawnIndex = 0;
        }

        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            Summon(Team.right, birds[spawnIndex], new Vector2(transform.position.x - 1.5f, transform.position.y));
        }
    }
}
