using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeIneffect : MonoBehaviour
{
    // Start is called before the first frame update
    public float faddinSpd = 0.01f;
    void Start()
    {
        StartCoroutine("FadeIn");
    }

    // Update is called once per frame
    void Update()
    {


    }
    IEnumerator FadeIn()
    {
        for(float i = 1f;i>=0;i-=faddinSpd)
        {
            Color color = new Vector4(1, 1, 1, i);
            GetComponent<Renderer>().material.color = color;
            yield return 0;

        }
    }
}
