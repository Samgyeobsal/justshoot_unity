using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lazerItem : MonoBehaviour
{
    public GameObject parti;
    public float lazerSpd;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Instantiate(parti, transform.position, Quaternion.identity);
            GameManager.instance.surviveScore -= 30;
            GameManager.instance.islazermode = true;
            Destroy(gameObject);
        }
        if(collision.tag == "delete")
        {
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * lazerSpd * Time.deltaTime);
    }
}
