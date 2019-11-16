using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpd = 8f;

    // Start is called before the first frame update

    public void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "enemy"||collision.tag == "Hide"||collision.tag == "rocket")
        {
            Destroy(gameObject);
        }
    }
    private void Update()
    {
        transform.Translate(Vector2.up * bulletSpd * Time.deltaTime);
        
    }
    // Update is called once per frame
}
