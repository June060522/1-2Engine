using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LPlayer : PlayerManager
{
    private int nowIndex = 1;
    private int spawnIndex = 0;

    private void Start()
    {
        Hp = 30f;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            nowIndex++;
            if (nowIndex > window.Length - 1)
                nowIndex = 0;
            transform.position = new Vector2(transform.position.x, window[nowIndex].transform.position.y);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            nowIndex--;
            if (nowIndex < 0)
                nowIndex = window.Length - 1;
            transform.position = new Vector2(transform.position.x, window[nowIndex].transform.position.y);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            spawnIndex--;
            if (spawnIndex < 0)
                spawnIndex = birds.Length - 1;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            spawnIndex++;
            if (spawnIndex > birds.Length - 1)
                spawnIndex = 0;
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Summon(Team.left,birds[spawnIndex],new Vector2(transform.position.x + 1.5f,transform.position.y));
        }
    }
}
