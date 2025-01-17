using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SerializableDictionary<TKey, TValue>
{
    [Serializable]
    public struct KeyValue
    {
        public TKey Key;
        public TValue Value;
    }

    [SerializeField]
    private List<KeyValue> _entries = new List<KeyValue>();

    public Dictionary<TKey, TValue> ToDictionary()
    {
        var dict = new Dictionary<TKey, TValue>();
        foreach (var entry in _entries)
        {
            if (!dict.ContainsKey(entry.Key))
            {
                dict[entry.Key] = entry.Value;
            }
        }
        return dict;
    }

    public void FromDictionary(Dictionary<TKey, TValue> dict)
    {
        _entries.Clear();
        foreach (var kvp in dict)
        {
            _entries.Add(new KeyValue { Key = kvp.Key, Value = kvp.Value });
        }
    }
}
