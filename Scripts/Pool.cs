using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Pool<T> where T : Object
{
    [field: SerializeField]
    private SerializableDictionary<string, PoolIdentifier<T>> _poolDictionary = new SerializableDictionary<string, PoolIdentifier<T>>();

    private Dictionary<string, PoolIdentifier<T>> PoolDict => _poolDictionary.ToDictionary();

    public void SpawnAllDictionary()
    {
        var poolDict = PoolDict;
        foreach (var item in poolDict)
        {
            item.Value.Init(item.Value.ItemType);
            item.Value.SpawnItems();
        }
    }

    public T GetPoolObject(string key)
    {
        var poolDict = PoolDict;
        if (!poolDict.ContainsKey(key))
        {
            Debug.LogError($"Key '{key}' isn't recorded in the pool.");
            return null;
        }

        return poolDict[key].GetObject();
    }

    public void AddToPool(string key, T value)
    {
        var poolDict = PoolDict;
        if (!poolDict.ContainsKey(key))
        {
            poolDict[key] = new PoolIdentifier<T>();
        }

        poolDict[key].AddToPool(value);
        _poolDictionary.FromDictionary(poolDict);
    }
}

[System.Serializable]
public class PoolIdentifier<T> where T : Object
{
    private Queue<T> _items = new();
    [field: SerializeField] private T _itemType;
    [field: SerializeField] private int _count = 1;

    public T ItemType => _itemType;

    public void Init(T itemType)
    {
        _itemType = itemType;
        SpawnItems();
    }

    public void SpawnItems()
    {
        if (_itemType == null)
        {
            Debug.LogError("Item type is not initialized. Call Init() before spawning items.");
            return;
        }

        for (int i = 0; i < _count; i++)
        {
            T tempCreated = Object.Instantiate(_itemType);
            _items.Enqueue(tempCreated);
        }
    }

    public void AddToPool(T value) => _items.Enqueue(value);
    public T GetObject() => _items.Dequeue();
}
