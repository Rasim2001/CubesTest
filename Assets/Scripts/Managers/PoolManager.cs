using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager<T> where T : MonoBehaviour
{
    public T Prefab;
    public Transform Container;
    public bool AutoExpand;

    private List<T> pool;
    public PoolManager(T prefab, int count, Transform container)
    {
        Prefab = prefab;
        Container = container;

        CreatePool(count);
    }

    private void CreatePool(int count)
    {
        pool = new List<T>();
        for (int i = 0; i < count; i++)
        {
            CreateObject();
        }
    }

    private T CreateObject(bool isActiveByDefault = false)
    {
        var createdObject = UnityEngine.Object.Instantiate(Prefab, Container);
        createdObject.gameObject.SetActive(isActiveByDefault);
        pool.Add(createdObject);
        return createdObject;
    }

    private bool HasFreeElement(out T element)
    {
        foreach (var mono in pool)
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

        throw new System.Exception("Error");
    }

    public void ReturnAllObjects()
    {
        foreach (var mono in pool)
        {
            if (mono.gameObject.activeInHierarchy)
            {
                mono.gameObject.SetActive(false);
                mono.transform.DOKill();
            }
        }
    }
}

[System.Serializable]
public struct PoolInfo
{
    public Cube Cube;
    public Transform PoolContainer;
    public int PoolCount;
    public bool AutoExpand;
}