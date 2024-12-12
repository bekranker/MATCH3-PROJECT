using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{

    private Stack<GameObject> _pool = new();

    public GameObject GetFromPool(GameObject prefab)
    {
        GameObject instiante;
        if (_pool == null)
        {
            _pool = new();

            instiante = Object.Instantiate(prefab);
            return instiante;
        }
        else if (_pool.TryPeek(out GameObject instiante2))
        {
            GameObject tempPoolItem = _pool.Pop();
            return tempPoolItem;
        }
        else
        {
            instiante = Object.Instantiate(prefab);
            return instiante;
        }
    }
    public void AddToPool(GameObject objectToAdd) => _pool.Push(objectToAdd);


}