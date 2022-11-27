using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CRPlayer : CPlayManager
{
    private void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x,-8.5f,8.5f),Mathf.Clamp(transform.position.y,-4.5f,4.5f));

        if(transform.position.y >= 4.5f)
        {
            Hp -= 0.1f;
            rb2D.velocity = Vector2.zero;
            rb2D.AddForce(Vector2.down * JumpPower);
        }
        else if(transform.position.y <= -4.5f)
        {
            Hp -= 0.1f;
            rb2D.velocity = Vector2.zero;
            rb2D.AddForce(Vector2.up * JumpPower * 8);
        }
        if(transform.position.x >= 8.5f)
        {
            rb2D.velocity = new Vector2(0,rb2D.velocity.y);
        }
        else if(transform.position.x <= -8.5f)
        {
            rb2D.velocity = new Vector2(0,rb2D.velocity.y);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(new Vector3(1,0,0) * Speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(new Vector3(-1,0,0) * Speed * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            StartCoroutine(Jump());
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if(cBirdRotate.dir == Dir.right)
            {
                GameObject food = PoolManager.Instance.Pop(throwFood,transform.position,Quaternion.identity);
                food.GetComponent<FoodMove>().dir = Dir.right;
            }
            else
            {
                GameObject food = PoolManager.Instance.Pop(throwFood,transform.position,Quaternion.identity);
                food.GetComponent<FoodMove>().dir = Dir.left;
            }
        }
        if(Input.GetKeyDown(KeyCode.RightShift))
        {
            if(spriteRenderer.flipX == true)
                rb2D.AddForce(Vector2.left * 3,ForceMode2D.Impulse);
            else
                rb2D.AddForce(Vector2.right * 3,ForceMode2D.Impulse);
        }

        if(Hp <= 0)
        {
            gameObject.SetActive(false);
        }
    }
    IEnumerator Jump()
    {
        int i = 0;
        while(i < JumpPower)
        {
            i++;
            transform.Translate(new Vector3(0,transform.position.y + JumpPower,0)* JumpPower * Time.deltaTime);
            yield return new WaitForSeconds(0.01f);
        }
    }
}
