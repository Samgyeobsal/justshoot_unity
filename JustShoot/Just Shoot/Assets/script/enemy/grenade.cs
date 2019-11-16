using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class grenade : MonoBehaviour
{
    public float fireSpd = 8f;
    public float rotateSpd = 15f;
    public float explosionT = 3f;
    public GameObject particle;
    public GameObject non_explo;
    
    float afterExplo;
    public Rigidbody2D rigi;
    // Start is called before the first frame update
    void Start()
    {
        rigi = GetComponent<Rigidbody2D>();
        afterExplo = 0;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "p_bul")
        {
            GameManager.instance.PlayerReload(transform.position, transform.rotation);
            GameObject non = Instantiate(non_explo, transform.position, transform.rotation);
            Destroy(gameObject);
            GameManager.instance.surviveScore += 20;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "wall"&&collision.contacts[0].normal.y>0.7f||collision.transform.tag == "Hide")
        {
            Destroy(gameObject);
            Instantiate(particle, transform.position, transform.rotation);
        }
        else if (collision.transform.tag == "p_bomb")
        {
            GameManager.instance.PlayerReload(transform.position, transform.rotation);
            GameObject non = Instantiate(non_explo, transform.position, transform.rotation);
            Destroy(gameObject);
            GameManager.instance.surviveScore += 20;
        }
    }
    // Update is called once per frame
    void Update()
    {
        afterExplo += Time.deltaTime;
        transform.Rotate(0, 0,rotateSpd * Time.deltaTime);
        //transform.Translate(Vector2.up * fireSpd * Time.deltaTime);
        if(afterExplo >= explosionT)
        {
            Destroy(gameObject);
            Instantiate(particle, transform.position, transform.rotation);
        }
        
    }
}
