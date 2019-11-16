using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pop : MonoBehaviour
{
    public Rigidbody2D rigi;
    public float popSpd;
    // Start is called before the first frame update
    void Start()
    {
        popSpd = 600;
        rigi = GetComponent<Rigidbody2D>();
        rigi.AddForce(new Vector2(0,popSpd));
    }


}
