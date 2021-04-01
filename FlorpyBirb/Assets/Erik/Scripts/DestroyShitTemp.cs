using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroyShitTemp : MonoBehaviour
{
    bool gameStarted = false;
    public float Score = 0;
    Text scoreText => transform.GetChild(1).GetComponent<Text>();
    Text highScoreText => transform.GetChild(2).GetComponent<Text>();
    GameObject startbutton => GetComponentInChildren<Button>().gameObject;
    private void Start()
    {
        PlayerPrefs.SetInt("HighScore", 10);
        if (PlayerPrefs.GetInt("HighScore") != 0) highScoreText.text = "HighScore : " + PlayerPrefs.GetInt("HighScore");
        else highScoreText.enabled = false;
    }
    public void DestroyShit()
    {
        highScoreText.enabled = false;
        gameStarted = true;
        startbutton.SetActive(false);
    }
    public void GainPoints(int yeet)
    {
        Score += yeet;
    }
    private void Update()
    {
        if (!gameStarted) return;
        if (FindObjectOfType<PlayerMovementScript>())
        {
            if (FindObjectOfType<PlayerMovementScript>().IsAlive)
            {
                Score += Time.deltaTime * (int)Settings.settings.difficulty * 4;
            }
        }
        else
        {
            Score += Time.deltaTime * (int)Settings.settings.difficulty * 4;
        }
        scoreText.text = "SCORE : " + Mathf.RoundToInt(Score);
    }
}
