using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    // it creates a instance of the UIManager so that
    // we can access all the functions/properties from anywhere (any other script) in the Game.
    public static UIManager instance;

    // create gameObject and Text references for the design mapping.
    public GameObject tapToStart;   // in Canvas
    public GameObject zigZagPanel;  // the ZigZagPanel
    public GameObject gameOverMenuPanel;    // GameOverMenu
    public Text score;          // Initial Score before game begins
    public Text highScore1;     // High Score on start screen in ZigZagPanel
    public Text highScore2;     // High Score on the GameOverPanel

    // awake method is called before Start() and
    // is used to setup evrything before the game
    private void Awake()
    {
        // if there is no instance yet then create a new instance.
        if(instance == null)
        {
            instance = this;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        highScore1.text = "High Score: " + PlayerPrefs.GetInt("highScore");
    }

    // to setup UI when the game Starts
    public void GameStart()
    {
        tapToStart.SetActive(false);
        zigZagPanel.GetComponent<Animator>().Play("PanelMoveUp");
    }

    // setup UI when Game Overs.
    public void GameOver()
    {
        score.text = PlayerPrefs.GetInt("score").ToString();
        highScore2.text = PlayerPrefs.GetInt("highScore").ToString();
        gameOverMenuPanel.SetActive(true);
    }


    // reset the game again.
    public void Reset()
    {
        SceneManager.LoadScene(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
