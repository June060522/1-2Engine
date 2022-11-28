using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum state
{
    alive = 1,
    broken = 2
}
public class Window : MonoBehaviour
{
    public Team team = Team.right;
    public float Hp;
    [SerializeField] Sprite[] sprites;
    private SpriteRenderer spR;
    private BoxCollider2D boxCollider2D;

    [SerializeField] RPlayer rPlayer;
    [SerializeField] LPlayer lPlayer;
    [SerializeField] AudioClip bronkwnClip;

    private void Awake()
    {
        spR = GetComponent<SpriteRenderer>();
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    public void Damage(float damage)
    {
        StartCoroutine(OnDamage(damage));
    }

    IEnumerator OnDamage(float damage)
    {
        EffectAudio.Instance.ListenEff(bronkwnClip);
        float returnDamage = 0;
        float yieldDamage = 0;
        while(returnDamage <= damage)
        {
            yieldDamage = 0.1f;
            Hp -= yieldDamage;
            returnDamage += yieldDamage;
            yield return new WaitForSeconds(0.01f);
        }
        if(Hp <= 0)
        {
            spR.sprite = sprites[1];

            if(team == Team.right)
            {
                lPlayer.BirdFood = lPlayer.maxFood;
            }
            else if(team == Team.left)
            {
                rPlayer.BirdFood = rPlayer.maxFood;
            }
        }
        else if(Hp <= 10)
        {
            spR.sprite = sprites[0];
        }
        yield return null;
    }
}
