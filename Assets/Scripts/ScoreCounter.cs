using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScoreCounter : MonoBehaviour
{
    private int _highScore;
    private int _score;
    public int Highscore => _highScore;
    public int Score => _score;
    public UnityEvent Change;
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
            Change?.Invoke();
        }            
    }
    public void AddScore(float amount)
    {
        _score += (int)amount;
        Change?.Invoke();
        TrySetHighScore(_score);
    }
    public void SetStartScore()
    {
        _score = 0;
        Change?.Invoke();
    }

}
