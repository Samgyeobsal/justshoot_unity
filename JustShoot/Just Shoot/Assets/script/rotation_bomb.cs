using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotation_bomb : MonoBehaviour
{
    public float rotateSpd;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.parent.Rotate(0, 0, rotateSpd);
    }
}
