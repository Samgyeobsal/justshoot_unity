using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item_bomb : MonoBehaviour
{
    private float lifeTime;
    public float fadeinSpd;
    public GameObject explo;
    // Start is called before the first frame update
    void Start()
    {
        fadeinSpd = 0.1f;
        lifeTime = 0;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "enemy")
        {
            Instantiate(explo, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag =="enemy")
        {
            Instantiate(explo, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        lifeTime += Time.deltaTime;
        if(lifeTime>=8)
        {
            Instantiate(explo, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
