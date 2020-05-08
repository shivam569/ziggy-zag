using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public int score;
    public int highScore;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        // PlayerPrefs is used to store data on machine (any type of data with a key).
        // here, the key is `score`. and can be used to fetch the data using the key.
        PlayerPrefs.SetInt("score", score);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // ******************* ******************** //

    // increment the score as it touches the diamonds.
    void IncrementScore()
    {
        score += 1;
    }

    // initial score
    public void StartScore()
    {
        InvokeRepeating("IncrementScore", 0.1f, 0.5f);
    }

    // when GameOver stop the score
    public void StopScore()
    {
        CancelInvoke("IncrementScore");

        PlayerPrefs.SetInt("score", score);

        if(PlayerPrefs.HasKey("highScore"))
        {
            if (score > PlayerPrefs.GetInt("highScore"))
            {
                PlayerPrefs.SetInt("highScore", score);
            }
        }
        else
        {
            PlayerPrefs.SetInt("highScore", score);
        }
    }
}
