using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerManager : MonoBehaviour, ISummon
{
    public void Summon(Team team, GameObject bird, Vector2 pos,Quaternion rotation,BirdType birdType)
    {
        if((birdType == BirdType.Small)? BirdFood >= bird.GetComponent<Bird>().needFood : BirdFood * 2 >= bird.GetComponent<Bird>().needFood)
        {
            bird = PoolManager.Instance.Pop(bird, pos, rotation);
            Bird B = bird.GetComponent<Bird>(); 
            B.team = team;
            B.birdSize = birdType;
            if(birdType == BirdType.Big)
            {
                birdFood -= B.needFood * 2;
                bird.transform.localScale = new Vector3(0.3f,0.3f,1);
            }
            else
            {
                birdFood -= B.needFood;
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
    protected int maxSpawn = 5;
    public int nowSpawn = 0;
    protected float plusBirdFood = 0.01f;
    public float PlusBirdFood {get => plusBirdFood; set => plusBirdFood = value;}

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

        Hp = 30f;
        BirdFood = 50;
        maxFood = BirdFood;
    }

    protected void SetPlusBirdFood(float plus)
    {
        BirdFood += plus;
    }
}
