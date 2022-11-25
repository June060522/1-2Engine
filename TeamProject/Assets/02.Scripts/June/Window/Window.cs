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

    private void Awake()
    {
        spR = GetComponent<SpriteRenderer>();
    }

    public void Damage(float damage)
    {
        StartCoroutine(OnDamage(damage));
    }

    IEnumerator OnDamage(float damage)
    {
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
        }
        else if(Hp <= 10)
        {
            spR.sprite = sprites[0];
        }
        yield return null;
    }
}
