using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpherePooll : MonoBehaviour
{
    [SerializeField] private float _speedAccelerate = 1f;
    [SerializeField] private float _speedCreate = 1f;
    [SerializeField] private int _poolCount = 5;
    [SerializeField] private bool autoExpand = true;
    [SerializeField] private Sphere spherePrefab;
    [SerializeField] private float minX;
    [SerializeField] private float maxX;
    [SerializeField] private float minY;
    [SerializeField] private float maxY;
    [SerializeField] private float instantiatingY;
    private Game _game;
    private PoolMono<Sphere> _pool; 
    private float _speedSphere;
    void Start()
    {
        _game = FindObjectOfType<Game>();
        _pool = new PoolMono<Sphere>(spherePrefab, _poolCount, this.transform);
        _pool.AutoExpand = autoExpand;
    }
    private void OnDisable()
    {
        StopCoroutine("Generate");
        StopCoroutine("SpeedTimer");
    }
    public void OnEnable()
    {
        StartCoroutine("Generate");
        StartCoroutine("SpeedTimer");
    }
    private IEnumerator Generate()
    {
        while (true)
        {
            yield return new WaitForSeconds(_speedCreate);
            CreateSphere();
        }            
    }
    private IEnumerator SpeedTimer()
    {
        _speedSphere = 0;
        while (true)
        {
            yield return new WaitForSeconds(_speedAccelerate);
            _speedSphere += Time.deltaTime;
        }            
    }
    private void CreateSphere()
    {
        var rX = UnityEngine.Random.Range(minX, maxX);
        var rZ = UnityEngine.Random.Range(minY, maxY);
        var y = instantiatingY;
        var rPosition = new Vector3(rX, y, rZ);
        var sphere = _pool.GetFreeElement();
        sphere.transform.position = rPosition;
        Debug.Log(_speedSphere);
        sphere.SetVelocityY(_speedSphere);
    }
}
