using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerManager : MonoBehaviour, ISummon
{
    public void Summon(Team team, GameObject bird, Vector2 pos,Quaternion rotation)
    {
        if(BirdFood >= bird.GetComponent<Bird>().bridFood)
        {
            BirdFood -= bird.GetComponent<Bird>().bridFood;
            bird = PoolManager.Instance.Pop(bird, pos, rotation);
            bird.GetComponent<Bird>().team = team;
        }
    }
    [SerializeField] protected GameObject[] window;
    [SerializeField] protected GameObject[] birds;

    public bool GameOver = false;
    private float hp;
    private float birdFood;
    public float Hp { get => hp; set => hp = value; }
    public float BirdFood { get => birdFood; set => birdFood = value;}

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
    }
}
