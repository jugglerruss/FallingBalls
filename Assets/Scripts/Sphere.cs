using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Renderer))]
public class Sphere : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particleClick;
    [SerializeField] [Range(1f, 5f)] private float _minRndSpeed;
    [SerializeField] [Range(5f, 20f)] private float _maxRndSpeed;
    private Game _game;
    private ScoreCounter _scoreCounter;
    private HP _hp;
    private Camera _cam;
    private Rigidbody _rb;
    private Renderer _mr;
    private float _timeKoeff;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _mr = GetComponent<Renderer>();
        _game = FindObjectOfType<Game>();
        _scoreCounter = _game.gameObject.GetComponent<ScoreCounter>();
        _hp = _game.gameObject.GetComponent<HP>();
        _cam = FindObjectOfType<Camera>();
    }
    private void Start()
    {
        _timeKoeff = 0;
    }
    private void OnEnable()
    {
        StartCoroutine("LifeRoutine");
        _mr.material.color = GetRandomColor();
    }
    private void OnDisable()
    {
        StopCoroutine("LifeRoutine");
    }
    private void OnMouseDown()
    {
        ShowEffect();
        Deactivate();
        _scoreCounter.AddScore(transform.position.z);
    }
    private Color GetRandomColor()
    {
        return Random.ColorHSV();
    }
    private void ShowEffect()
    {
        var particleMain = Instantiate(_particleClick, transform.position, new Quaternion()).main;
        particleMain.startColor = _mr.material.color;
    }
    public void SetVelocityY(float timeKoeff)
    {
        _rb.velocity = new Vector3(0, - Random.Range(_minRndSpeed + timeKoeff, _maxRndSpeed + timeKoeff), 0);
    }

    private IEnumerator LifeRoutine()
    {
        while (true)
        {
            yield return new WaitForEndOfFrame();
            if(0 > _cam.WorldToViewportPoint(transform.position).y)
            {
                var dmg = Math.Abs(transform.position.z * _rb.velocity.y);
                _hp.TakeDamage(dmg);
                Deactivate();
            }
        }
    }

    public void Deactivate()
    {
        gameObject.SetActive(false);
        _rb.velocity = new Vector3();
    }
}
