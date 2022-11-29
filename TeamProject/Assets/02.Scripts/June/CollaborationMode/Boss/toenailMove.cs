using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toenailMove : MonoBehaviour
{
    private void OnEnable()
    {
        //transform.rotation = Quaternion.Euler(0,0,transform.rotation.z - 90);
    }

    void Update()
    {
        transform.Translate(Vector3.down * 2 * Time.deltaTime);

        if(transform.position.x > 9.5f || transform.position.x < -9.5f)
        {
            transform.rotation = Quaternion.Euler(0,0,0);
            PoolManager.Instance.Push(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Bird"))
        {
            other.GetComponent<CPlayManager>().Hp -= 5;
            transform.rotation = Quaternion.Euler(0,0,0);
            PoolManager.Instance.Push(gameObject);
        }
    }
}
