using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class NormalBoss : BossManager
{
    private void Start()
    {
        x = transform.position.x;
        StartCoroutine(PatternStart());
    }
    void Update()
    {
        if (Hp <= 0)
        {
            PlayerPrefs.SetString("WinnerName", "Easy Stage Clear!!");
            SceneManager.LoadScene("EndScene");
        }

        if (cLPlayer.Hp <= 0 && cRPlayer.Hp <= 0)
        {
            PlayerPrefs.SetString("WinnerName", "Easy Stage Fail..");
            SceneManager.LoadScene("EndScene");
        }

        if (x > transform.position.x && spriteRenderer.flipX == true)
        {
            spriteRenderer.flipX = false;
        }
        else if (x < transform.position.x && spriteRenderer.flipX == false)
        {
            spriteRenderer.flipX = true;
        }
        x = transform.position.x;
        time += Time.deltaTime;

    }
    IEnumerator PatternStart()
    {
        while (true)
        {
            pattern = Random.Range(2, 3);
            float index = Random.Range(0, 2);
            if (index == 0)
            {
                target = GameObject.Find("LPlayer");
            }
            else
            {
                target = GameObject.Find("RPlayer");
            }
            switch (pattern)
            {
                case 0:
                    float x = Random.Range(-8.5f, 8.5f);
                    float y = Random.Range(-4.5f, 4.5f);
                    transform.DOMove(new Vector2(x, y), 2.6f);
                    break;
                case 1:
                    float random = Random.Range(-80, 80);
                    turnObject.Turning(random);
                    break;
                case 2:
                    time = 0;
                    while (time < 3)
                    {
                        Vector2 dir = target.transform.position - transform.position;
                        transform.Translate(dir.normalized * Time.deltaTime);
                    }
                    break;
            }

            yield return new WaitForSeconds(12f);
        }
    }
}
