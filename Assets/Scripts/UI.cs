using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private TextMeshProUGUI _hiScoreText;
    [SerializeField] private TextMeshProUGUI _hpText;
    [SerializeField] private Transform _losePanel;
 
    public void SetScore(int score)
    {
        _scoreText.text = ($"Score: {score}");
    }
    public void SetHiScore(int score)
    {
        _hiScoreText.text = ($"HiScore: {score}");
    }
    public void SetHP(int hp)
    {
        _hpText.text = ($"HP: {hp}");
    }
    public void ShowLosePanel()
    {
        _losePanel.gameObject.SetActive(true);
    }
    public void HideLosePanel()
    {
        _losePanel.gameObject.SetActive(false);
    }
}
