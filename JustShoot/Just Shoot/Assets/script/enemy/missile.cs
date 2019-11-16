using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class missile : MonoBehaviour
{
    public GameObject explosionPar;
    public GameObject non_explosionPar;
    public Transform explosionPos;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "wall" && collision.contacts[0].normal.y >0.7f)
        {
            Instantiate(explosionPar, explosionPos.position, explosionPos.rotation);
            Destroy(gameObject);
        }
        else if (collision.transform.tag == "Hide" && collision.contacts[0].normal.y > 0.7f)
        {
            Instantiate(explosionPar, explosionPos.position, explosionPos.rotation);
            Destroy(gameObject);
        }
        else if(collision.transform.tag == "p_bomb")
        {
            GameManager.instance.PlayerReload(transform.position, transform.rotation);
            Instantiate(non_explosionPar, explosionPos.position, explosionPos.rotation);
            Destroy(gameObject);
            GameManager.instance.surviveScore += 40;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "p_bul")
        {
            GameManager.instance.PlayerReload(transform.position, transform.rotation);
            Instantiate(non_explosionPar, explosionPos.position, explosionPos.rotation);
            Destroy(gameObject);
            GameManager.instance.surviveScore += 40;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
