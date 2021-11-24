using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(ScoreCounter))]
[RequireComponent(typeof(HP))]
public class Game : MonoBehaviour
{
    [SerializeField] private UI _UI;
    [SerializeField] private ScoreCounter _scoreCounter;
    [SerializeField] private HP _hp;
    private bool _isPaused;
    public bool IsPaused => _isPaused;
    public UnityEvent StartGame;
    public void Pause()
    {
        _isPaused = true;
        foreach (var sphere in FindObjectsOfType<Sphere>())
        {
            sphere.Deactivate();
        }
    }
    public void UnPause()
    {
        _isPaused = false;
        StartGame.Invoke();
    }
    public void Restart()
    {
        _scoreCounter.SetStartScore();
        _hp.SetStartValue();
        _UI.HideLosePanel();
        UnPause();
    }
} 
