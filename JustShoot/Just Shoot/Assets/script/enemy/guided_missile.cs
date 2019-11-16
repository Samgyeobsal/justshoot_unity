using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class guided_missile : MonoBehaviour
{
    public float missileSpd;
    public GameObject non_explo;
    public GameObject explo;
    
    private float howManyHit;
    private float destroyTime;
    // Start is called before the first frame update
    public void guid()
    {
        Vector3 pos = playercontrol.instance.transform.position - transform.position;
        transform.position += pos * missileSpd * Time.deltaTime;
        float Zangle = Mathf.Atan2(pos.y, pos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, Zangle - 90);
    }
    void Start()
    {
        missileSpd = 1;
        destroyTime = 0;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "wall"||collision.transform.tag == "Hide"|| collision.transform.tag == "Player")
        {
            Instantiate(explo, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        else if (collision.transform.tag == "p_bomb")
        {
            GameManager.instance.PlayerReload(transform.position, transform.rotation);
            Instantiate(non_explo, transform.position, Quaternion.identity);
            Destroy(gameObject);
            GameManager.instance.surviveScore += 40;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "p_bul")
        {
            howManyHit++;
        }
        if(howManyHit>=4|| collision.tag == "rocket" || collision.tag == "p_bomb")
        {
            GameManager.instance.PlayerReload(transform.position, transform.rotation);
            GameManager.instance.surviveScore += 70;
            Instantiate(non_explo, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        destroyTime += Time.deltaTime;
        guid();
        if(destroyTime >= 7)
        {
            Instantiate(explo, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
