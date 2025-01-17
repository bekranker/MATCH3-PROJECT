using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Pool<T> where T : MonoBehaviour
{
    [field: SerializeField]
    private SerializableDictionary<string, PoolIdentifier<T>> _poolCustomDictionary = new SerializableDictionary<string, PoolIdentifier<T>>();

    private Dictionary<string, PoolIdentifier<T>> PoolDict => _poolCustomDictionary.ToDictionary();

    //this function will spawn all items by givin string key from dictionary and giving count.
    public void SpawnAllDictionary(string key, int count)
    {
        PoolDict[key].Init(PoolDict[key].ItemType, count);
    }
    public PoolIdentifier<T> GetPool(string key) => PoolDict[key];
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

        poolDict[key].AddToQueue(value);
        _poolCustomDictionary.FromDictionary(poolDict);
    }
}

[System.Serializable]
public class PoolIdentifier<T> where T : MonoBehaviour
{
    public Queue<T> Items = new();
    [field: SerializeField] private T _itemType;
    public int Count { get; set; }
    [SerializeField] private Transform _parent;
    public T ItemType => _itemType;


    //Initializing the queue of pool's item
    public void Init(T itemType, int count)
    {
        if (_parent == null)
        {
            _parent = new GameObject($"------{ItemType.name}------").transform;
        }
        Count = count;
        _itemType = itemType;
        SpawnItems();
    }

    public void SpawnItems()
    {
        //if there is no item that defined break function;
        if (_itemType == null)
        {
            Debug.LogError("Item type is not initialized. Call Init() before spawning items.");
            return;
        }
        //Spawning Count times
        for (int i = 0; i < Count; i++)
        {
            T tempCreated = Object.Instantiate(_itemType);
            tempCreated.transform.SetParent(_parent);
            tempCreated.gameObject.SetActive(false);
            Items.Enqueue(tempCreated);

        }
    }

    public void AddToQueue(T value)
    {
        value.gameObject.SetActive(false);
        Items.Enqueue(value);
    }
    public T GetObject()
    {
        T temp = Items.Dequeue();
        temp.gameObject.SetActive(true);
        return temp;
    }
}
