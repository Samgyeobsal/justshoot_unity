using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontrol : MonoBehaviour
{
    public float playerSpd = 8f;
    public float fireSpd = 1f;
    public Rigidbody2D rigi;
    public Transform firePos;
    public Transform firePos2;
    public GameObject die_par;
    public int nowbullet;
    public static playercontrol instance;
    public GameObject mime;
    float nowTime;
    float lazermodeTime;
    float nextFire;
    bool isfiremode;
    bool isreloadmode;
    public GameObject bulletpre;
    private Vector3 target;
    public bool isinfinity;
    public bool isdeadmode;
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }
    void mouseMove()
    {
    Vector2 pos = (transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition));
    float Zangle = Mathf.Atan2(pos.y, pos.x) * Mathf.Rad2Deg;
    transform.rotation = Quaternion.Euler(0, 0, Zangle+90);
    }
    void Start()
    {
        isdeadmode = false;
        Cursor.visible = true;
        lazermodeTime = 3;
        nowbullet = 25;
        nextFire = Time.time;
        rigi = GetComponent<Rigidbody2D>();
        isinfinity = false;
    }
    void after3second()
    {
        GameManager.instance.EndGame();
    }
    void Die()
    {
        gameObject.SetActive(false);
        Instantiate(die_par, transform.position, transform.rotation);
        Invoke("after3second", 3);
    }
    // Update is called once per frame
    private void OnParticleCollision(GameObject other)
    {
        if(other.tag == "enemy"||other.tag == "ger_enemy")
        {  
         Die();
        }
    }   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "enemy"||collision.tag == "rocket")
        {
            Die();
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "enemy")
        {
            Die();
        }
    }
    void Update()
    {
        float time = 0;
        
        float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");

        float xSpd = playerSpd * xInput;
        float ySpd = playerSpd * yInput;

        Vector3 velo = new Vector2(xSpd, ySpd);
        rigi.velocity = velo;
        mouseMove();
        Cursor.visible = true;
        if(time >=5)
        {
            time = 0;
            isinfinity = false;
            Debug.Log("end");
        }
        if (Input.GetMouseButton(0)&& nextFire<Time.time&&nowbullet != 0)
        {
            if (this.tag == "mine_player")
            {
                nextFire = Time.time + fireSpd;
                Instantiate(mime, firePos.position, transform.rotation);
                nowbullet--;
            }
            else
            {
                nextFire = Time.time + fireSpd;
                Instantiate(bulletpre, firePos.position, transform.rotation);
                //bullet = Instantiate(bulletpre, firePos2.position, transform.rotation);
                nowbullet--;
            }
        }
        if(Input.GetMouseButton(0)&&isinfinity == true)
        {
            
            Instantiate(bulletpre, firePos.position, transform.rotation);
        }
        if(isinfinity)
        {
            Debug.Log("eat");
            if(lazermodeTime>0)
            {
                lazermodeTime -= Time.deltaTime;
            }
            if(lazermodeTime<=0)
            {
                lazermodeTime = 3;
                GameManager.instance.islazermode = false;
            }
            
        }

        }
        
    }

