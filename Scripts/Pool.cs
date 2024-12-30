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

            instiante = Instantiate(prefab);
            return instiante;
        }
        else if (_pool.TryPop(out GameObject popedObject))
        {
            GameObject tempPoolItem = popedObject;
            return tempPoolItem;
        }
        else
        {
            instiante = Instantiate(prefab);
            return instiante;
        }
    }
    public void AddToPool(GameObject objectToAdd) => _pool.Push(objectToAdd);


}