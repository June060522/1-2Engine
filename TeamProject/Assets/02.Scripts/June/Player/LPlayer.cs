using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class LPlayer : PlayerManager
{
    private int nowIndex = 2;
    private int spawnIndex = 0;

    public bool isMove = false;

    private void Start()
    {
        Hp = 30f;
        BirdFood = 50;
    }
    void Update()
    {
        if(!isMove && Hp > 0)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                nowIndex++;
                if (nowIndex > window.Length - 1)
                    nowIndex = 0;
                StartCoroutine(MoveFloor());
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                nowIndex--;
                if (nowIndex < 0)
                    nowIndex = window.Length - 1;
                StartCoroutine(MoveFloor());
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
                Summon(Team.left,birds[spawnIndex],new Vector2(transform.position.x + 0.5f,transform.position.y - 0.7f),Quaternion.identity);
            }
        }

        if(Input.GetKeyDown(KeyCode.P))
            Hp = 0;
        if(Hp <= 0 && !GameOver)
        {
            GameOver = true;
            transform.GetComponent<SpriteRenderer>().sortingOrder = 999;
            DOTween.Sequence().Append(transform.DORotate(new Vector3(0, 0, -16), 0.3f)
            .OnComplete(() => transform.DOMoveY(-7,2f)
            .OnComplete(()=>SceneManager.LoadScene("EndScene"))));
        }
    }

    IEnumerator MoveFloor()
    {
        isMove = true;
        DOTween.Sequence().Append(transform.DORotate(new Vector3(0, 180, 0), 0.3f)
        .OnComplete(() => DOTween.Sequence().Append(transform.DOMoveX(transform.position.x - 1f, 0.5f))));
        yield return new WaitForSeconds(1f);
        transform.rotation = Quaternion.Euler(0, 0, 0);
        transform.position = new Vector3(transform.position.x, window[nowIndex].transform.position.y + 0.7f);
        transform.DOMoveX(transform.position.x +1f, 0.5f);
        yield return new WaitForSeconds(0.7f);
        yield return isMove = false;
    }
}
