using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombforward : MonoBehaviour
{
    public float bombSpd;
    // Start is called before the first frame update
    void Start()
    {
        bombSpd = 10;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * Time.deltaTime * bombSpd);
    }
}
