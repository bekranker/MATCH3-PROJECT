using System;
using System.Collections.Generic;
using UnityEngine;


//this is a custom Dictionary for showing in the Inspector
[Serializable]
public class SerializableDictionary<TKey, TValue>
{

    //tihs part is the our Dictionary Value's and Key's structer
    [Serializable]
    public struct KeyValue
    {
        public TKey Key;
        public TValue Value;
    }

    //tihs part is the Dictionary
    [SerializeField]
    private List<KeyValue> ItemsOfDictionary = new List<KeyValue>();

    public Dictionary<TKey, TValue> ToDictionary()
    {
        Dictionary<TKey, TValue> dict = new Dictionary<TKey, TValue>();

        foreach (KeyValue entry in ItemsOfDictionary)
        {
            if (!dict.ContainsKey(entry.Key))
            {
                dict[entry.Key] = entry.Value;
            }
        }
        return dict;
    }
    //its taking values from a giving dictionary to our custom dicitonary.
    public void FromDictionary(Dictionary<TKey, TValue> dict)
    {
        foreach (KeyValuePair<TKey, TValue> kvp in dict)
        {
            ItemsOfDictionary.Add(new KeyValue { Key = kvp.Key, Value = kvp.Value });
        }
    }
}
