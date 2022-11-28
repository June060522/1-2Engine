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
    }
    private void OnEnable()
    {
        EffectAudio.Instance.ListenEff(wing);
        transform.DOMove(new Vector3(5.51f,-0.46f),3f)
        .OnComplete(() => StartCoroutine(PatternStart()));
    }
    void Update()
    {
        if (Hp <= 0)
        {
            PlayerPrefs.SetString("WinnerName", "Normal Stage Clear!!");
            SceneManager.LoadScene("EndScene");
        }

        if (cLPlayer.Hp <= 0 && cRPlayer.Hp <= 0)
        {
            PlayerPrefs.SetString("WinnerName", "Normal Stage Fail..");
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
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -8.5f, 8.5f), Mathf.Clamp(transform.position.y, -4.5f, 4.5f));
    }
    IEnumerator PatternStart()
    {
        EffectAudio.Instance.ListenEff(wing);
        while (true)
        {
            pattern = Random.Range(0, 2);
            float index = Random.Range(0, 2);
            if (index == 0)
            {
                try
                {
                    target = GameObject.Find("LPlayer");
                }
                catch
                {
                    target = GameObject.Find("RPlayer");
                }
            }
            else
            {
                try
                {
                    target = GameObject.Find("RPlayer");
                }
                catch
                {
                    target = GameObject.Find("LPlayer");
                }
            }
            float random = Random.Range(-60, 60);
            turnObject.Turning(random);
            switch (pattern)
            {
                case 0:
                    float x = Random.Range(target.transform.position.x - 2 > -8.5 ? target.transform.position.x - 2 : -8.5f
                    , target.transform.position.x + 2 < 8.5 ? target.transform.position.x + 2 : 8.5f);
                    float y = Random.Range(target.transform.position.y - 1 > -4.5 ? target.transform.position.y - 1 : -4.5f
                    , target.transform.position.y - 1 > -4.5 ? target.transform.position.y - 1 : -4.5f);
                    transform.DOMove(new Vector2(x, y), 2.6f);
                    PoolManager.Instance.Pop(attack,transform.position,Quaternion.Euler(0,0,transform.rotation.z));
                    break;
                case 1:
                    time = 0;
                    while (time < 3)
                    {
                        time += Time.deltaTime;
                        Vector2 dir = target.transform.position - transform.position;
                        transform.Translate(dir.normalized * 3 *Time.deltaTime);
                        yield return new WaitForSeconds(0.01f);
                    }
                    break;
            }

            yield return new WaitForSeconds(7f);
        }
    }
}
