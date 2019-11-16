using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_Rocket : MonoBehaviour
{
    // Start is called before the first frame update
    public float rocketSpd = 8f;
    private float hitCount;
    public GameObject non_explo;
    public Transform gerpoint;
    public int value;
    private float lunchpoint;
    bool isdroped;
    private int drop;
    
    public GameObject grenadePre;
    void Start()
    {
        hitCount = 0;   
        lunchpoint = Random.Range(-20.85f, 20.85f);
        drop = Random.Range(0, 5);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "p_bul")
        {
            hitCount += 1;
        }
        if(collision.tag == "delete")
        {
            Destroy(gameObject);
        }
        if (hitCount == 5||collision.tag == "p_bomb")
        {
            float random = Random.Range(1, 4);
            GameManager.instance.surviveScore += 50;
            Instantiate(non_explo, transform.position, transform.rotation);
            Destroy(gameObject);
            if (random == 1)
            {
            GameManager.instance.PlayerReload(transform.position, transform.rotation);
            }
            else if (random == 2)
            {
                GameManager.instance.PlayerReload2(transform.position, transform.rotation);
            }

        }
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * rocketSpd * Time.deltaTime);
        if(Random.Range(1,101)<=value)
        {
            if(transform.position.x < lunchpoint&& isdroped == false)
            {
                isdroped = true;
                Instantiate(grenadePre, gerpoint.position, gerpoint.rotation);
            }
        }
        
    }
}
