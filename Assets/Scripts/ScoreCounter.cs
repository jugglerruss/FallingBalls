using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScoreCounter : MonoBehaviour
{
    private int _highScore;
    private int _score;
    public UnityEvent<int> ChangeScore;
    public UnityEvent<int> ChangeHiScore;
    private void Start()
    {
        PlayerPrefs.SetInt("Highscore", 0);
        _highScore = PlayerPrefs.GetInt("Highscore", 0);
        SetStartScore();
    }
    public void TrySetHighScore(int score) 
    {
        if (score > _highScore)
        {
            _highScore = score;
            PlayerPrefs.SetInt("Highscore", score);
            ChangeHiScore?.Invoke(_score);
        }            
    }
    public void AddScore(int amount)
    {
        _score += amount;
        ChangeScore?.Invoke(_score);
        TrySetHighScore(_score); 
    }
    public void SetStartScore()
    {
        _score = 0;
        ChangeScore?.Invoke(_score);
        ChangeHiScore?.Invoke(_highScore);
    }

}
