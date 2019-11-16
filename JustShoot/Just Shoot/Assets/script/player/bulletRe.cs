using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletRe : MonoBehaviour
{
    // Start is called before the first frame update
    public float Spd;
    public void guid()
    {
        Vector3 pos = playercontrol.instance.transform.position - transform.position;
        transform.position += pos * Spd * Time.deltaTime;
        float Zangle = Mathf.Atan2(pos.y, pos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, Zangle);
    }
    void Start()
    {

    }
   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (playercontrol.instance.nowbullet + 5 > 1000)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            if (collision.transform.tag == "Player")
            {
                playercontrol.instance.nowbullet += 5;
                Destroy(gameObject);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        guid();
    }
}
