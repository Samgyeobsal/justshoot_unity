using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleSceneManager : MonoBehaviour
{
    public Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible=true;
    }

    // Update is called once per frame
    void Update()
    {
        float bestscore = PlayerPrefs.GetFloat("BestScore");
        scoreText.text = "HIGHSCORE : " + bestscore;
    }
}
