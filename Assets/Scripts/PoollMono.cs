using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public class PoolMono<T> where T : MonoBehaviour
{
    public T Prefab { get; }
    public bool AutoExpand { get; set; }
    public Transform Conteiner { get; }
    private List<T> _pool;
    public PoolMono(T prefab, int count)
    {
        Prefab = prefab;
        Conteiner = null;
        CreatePool(count);
    } 
    public PoolMono(T prefab, int count,Transform conteiner)
    {
        Prefab = prefab;
        Conteiner = conteiner;
        CreatePool(count);
    }
    private void CreatePool(int count)
    {
        _pool = new List<T>();
        for (int i = 0; i < count; i++) 
            CreateObject();
    }
    private T CreateObject(bool isActiveByDefault = false)
    {
        var createdObject = Object.Instantiate(Prefab, Conteiner);
        createdObject.gameObject.SetActive(isActiveByDefault);
        _pool.Add(createdObject);
        return createdObject;
    }
    public bool HasFreeElement(out T element)
    {
        foreach (var mono in _pool)
        {
            if (!mono.gameObject.activeInHierarchy)
            {
                element = mono;
                mono.gameObject.SetActive(true);
                return true;
            }
        }
        element = null;
        return false;
    }
    public T GetFreeElement()
    {
        if (HasFreeElement(out var element))
            return element;
        if (AutoExpand)
            return CreateObject(true);

        throw new Exception($"Нет свободных элементов в пуле типа {typeof(T)}");
    }
}
