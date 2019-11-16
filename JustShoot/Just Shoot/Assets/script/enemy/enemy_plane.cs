using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_plane : MonoBehaviour
{
    public float planeSpd = 8f;
    public Transform dropPos;
    public GameObject missilePre;
    public GameObject non_explosion;
    public GameObject guidMissilepre;

    int whatDrop;
    bool isDropped;
    int howManyHit = 0;
    float dropPiont;
    // Start is called before the first frame update
    void Start()
    {
        dropPiont = Random.Range(-20.85f, 20.85f);
        whatDrop = Random.Range(1, 3);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "delete")
        {

            Destroy(gameObject);
            
        }
        else if (collision.tag == "p_bul"||collision.tag == "p_bomb")
        {
            howManyHit++;
            if(howManyHit>=4||collision.tag == "p_bomb")
            {
                GameManager.instance.PlayerReload2(transform.position, transform.rotation);
                Instantiate(non_explosion, transform.position, transform.rotation);
                Destroy(gameObject);
                GameManager.instance.surviveScore += 100;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * planeSpd * Time.deltaTime);
        //Debug.Log(transform.position.x);
        //Debug.Log(dropPoint);
        if(whatDrop == 1)
        {
            if(transform.position.x > dropPiont&& isDropped==false)
            {
                isDropped = true;
                Instantiate(missilePre, dropPos.position, dropPos.rotation);
                dropPiont = Random.Range(-20.85f, 20.85f);
                whatDrop = Random.Range(1, 3);
            }
        }
        else
        {
            if (transform.position.x > dropPiont && isDropped == false)
            {
                isDropped = true;
                Instantiate(guidMissilepre, dropPos.position, dropPos.rotation);
                dropPiont = Random.Range(-20.85f, 20.85f);
                whatDrop = Random.Range(1, 3);
            }
        }


    }
}
