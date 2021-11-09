using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HP : MonoBehaviour
{
    [SerializeField] private int _maxHp;
    private int _hp;
    public UnityEvent GameOver;
    public UnityEvent Change;

    public int Hp { get => _hp; private set => _hp = value; }

    private void Start()
    {
        SetStartValue();
    }

    public void SetStartValue()
    {
        _hp = _maxHp;
        Change.Invoke();
    }

    public void TakeDamage(float amount)
    {
        _hp -= (int)amount;
        Change.Invoke();
        if (_hp < 1)
        {
            GameOver.Invoke();
        } 
    }

}
