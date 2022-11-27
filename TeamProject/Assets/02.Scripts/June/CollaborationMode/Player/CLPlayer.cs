using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CLPlayer : CPlayManager
{
    void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x,-8.5f,8.5f),Mathf.Clamp(transform.position.y,-4.5f,4.5f));

        if(transform.position.y >= 4.5f)
        {
            Hp -= 0.1f;
            rb2D.AddForce(-transform.up * JumpPower);
        }
        else if(transform.position.y <= -4.5f)
        {
            Hp -= 0.1f;
            rb2D.AddForce(transform.up * JumpPower * 8);
        }
        if(transform.position.x >= 8.5f)
        {
            rb2D.velocity = new Vector2(0,rb2D.velocity.y);
        }
        else if(transform.position.x <= -8.5f)
        {
            rb2D.velocity = new Vector2(0,rb2D.velocity.y);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * Speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * Speed * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            rb2D.AddForce(transform.up * JumpPower,ForceMode2D.Impulse);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (cBirdRotate.dir == Dir.right)
            {
                GameObject food = PoolManager.Instance.Pop(throwFood, transform.position, Quaternion.identity);
                food.GetComponent<FoodMove>().dir = Dir.right;
            }
            else
            {
                GameObject food = PoolManager.Instance.Pop(throwFood, transform.position, Quaternion.identity);
                food.GetComponent<FoodMove>().dir = Dir.left;
            }
        }
        if(Input.GetKeyDown(KeyCode.Space))
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
}
