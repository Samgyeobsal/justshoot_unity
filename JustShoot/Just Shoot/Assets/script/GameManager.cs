using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Text Highscore;
    public Text Scoretext;
    public Text Timetext;
    public Text bulletText;
    public GameObject verText;
    public GameObject highscoreText;
    public float surviveScore;
    public static GameManager instance;
    public GameObject reload;
    public GameObject player1;
    public GameObject player2;
    public GameObject player3;
    public GameObject player4;

    private float surviveTime;
    public bool isGameover;
    public bool islazermode;

    private float infitinyTime;
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }
    void charselect()
    {
        if (SelectManager.instance.whatchar == 0)
        {
            player1.SetActive(true);
        }
        if (SelectManager.instance.whatchar == 1)
        {
            player2.SetActive(true);
        }
        if (SelectManager.instance.whatchar == 2)
        {
            Debug.Log("aa");
            player3.SetActive(true);
        }
        if (SelectManager.instance.whatchar == 3)
        {
            player4.SetActive(true);
        }
    }

    void Start()
    {
        player1.SetActive(false);
        player2.SetActive(false);
        player3.SetActive(false);
        charselect();
        verText.SetActive(true);
        Cursor.visible = false;
        surviveTime = 0;
        surviveScore = 0;
        isGameover = false;
        islazermode = false;
    }
    public void PlayerReload(Vector2 a,Quaternion b)
    {
        Instantiate(reload, a, b);
    }
    public void PlayerReload2(Vector2 a, Quaternion b)
    {
        Instantiate(reload, a, b);
        Instantiate(reload, a, b);
    }
    // Update is called once per frame
    void Update()
    {
        Scoretext.text = "" + (int)surviveScore;
        bulletText.text = ""+playercontrol.instance.nowbullet;
        float bestScoreCheck = PlayerPrefs.GetFloat("BestScore");
        
        if (islazermode)
        {
            bulletText.text = "∞";
            playercontrol.instance.isinfinity = true;
        }
        if(!islazermode)
        {
            playercontrol.instance.isinfinity = false;
        }
        if (surviveScore>bestScoreCheck)
        {
            highscoreText.SetActive(true);
        }
        if(!isGameover)
        {
            surviveTime += Time.deltaTime;
            Timetext.text = "Time : " + (int)surviveTime;
        }
        else
        {
            if(Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("GameScene");
            }
        }
    }
    public void EndGame()
    {
        isGameover = true;
        float bestScore = PlayerPrefs.GetFloat("BestScore");
        if(surviveScore > bestScore)
        {
            bestScore = surviveScore;
            PlayerPrefs.SetFloat("BestScore",bestScore);
        }
        SceneManager.LoadScene("TitleScene");
    }
}
