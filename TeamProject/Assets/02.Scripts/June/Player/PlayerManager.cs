using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerManager : MonoBehaviour, ISummon
{
    public void Summon(Team team, GameObject bird, Vector2 pos,Quaternion rotation,BirdType birdType)
    {
        if(BirdFood >= bird.GetComponent<Bird>().needFood)
        {
            bird = PoolManager.Instance.Pop(bird, pos, rotation);
            bird.GetComponent<Bird>().team = team;
            bird.GetComponent<Bird>().birdSize = birdType;
            if(birdType == BirdType.Big)
            {
                birdFood -= bird.GetComponent<Bird>().needFood * 2;
                bird.transform.localScale = new Vector3(0.3f,0.3f,1);
            }
            else
            {
                birdFood -= bird.GetComponent<Bird>().needFood;
                bird.transform.localScale = new Vector3(0.2f,0.2f,1);
            }
        }
    }
    [SerializeField] protected GameObject[] window;
    [SerializeField] protected GameObject[] birds;
    [SerializeField] protected GameObject[] showBird;

    private Window[] windowS = new Window[3];

    public bool GameOver = false;
    private float hp;
    private float birdFood;
    public float Hp { get => hp; set => hp = value; }
    public float BirdFood { get => birdFood; set => birdFood = value;}
    public float maxFood;

    protected int nowIndex = 2;
    protected int spawnIndex = 0;
    public int SpawnIndex => spawnIndex;
    public bool isMove = false;

    protected BirdType birdSize = BirdType.Big;

    protected void InBrokenWindow()
    {
        if(windowS[nowIndex].Hp <= 0)
            hp -= 0.01f;
    }

    protected void Awake()
    {
        foreach (GameObject W in window)
        {
            try
            {
                W.GetComponent<Window>();
            }
            catch (NullReferenceException)
            {
                Debug.LogError($"NullReferenceExpception : {W}");
            }
            catch (UnassignedReferenceException)
            {
                Debug.LogError($"UnassignedReferenceException : {W}");
            }
        }

        for(int i = 0; i < windowS.Length; i++)
        {
            windowS[i] = window[i].GetComponent<Window>();
        }
    }
}
