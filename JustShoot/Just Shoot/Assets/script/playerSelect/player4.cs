using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class player4 : MonoBehaviour
{
    Button player_4;
    // Start is called before the first frame update
    void Start()
    {
        player_4 = this.GetComponent<Button>();
        player_4.onClick.AddListener(click);
    }
    void click()
    {
        SelectManager.instance.whatchar = 3;
        SceneManager.LoadScene("GameScene");
    }
    // Update is called once per frame
}
