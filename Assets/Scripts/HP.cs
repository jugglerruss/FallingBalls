using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HP : MonoBehaviour
{
    [SerializeField] private int _maxHp;
    private int _hp;
    public UnityEvent GameOver;
    public UnityEvent<int> Change;

    private void Start()
    {
        SetStartValue();
    }
    public void SetStartValue()
    {
        _hp = _maxHp;
        Change.Invoke(_hp);
    }
    public void TakeDamage(float amount)
    {
        _hp -= (int)amount;
        Change.Invoke(_hp);
        if (_hp < 1)
        {
            GameOver.Invoke();
        } 
    }

}
