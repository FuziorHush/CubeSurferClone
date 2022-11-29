using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private PoolElement _objectToInstantiate = null;
    private List<PoolElement> _objects;

    public int MaxCapacity => _objects.Count;

    public void InitPool(int maxCapacity)
    {
        _objects = new List<PoolElement>(maxCapacity);
        for (int i = 0; i < maxCapacity; i++)
            _objects.Add(Instantiate(_objectToInstantiate, transform));
    }

    public PoolElement GetInactivePoolObject()
    {
        if (TryGetObject(out PoolElement poolElement))
            return poolElement;
        else
            return null;
    }

    public bool TryGetObject(out PoolElement element)//Возвращает первый элемент из пула, который неактивен и не на таймере деактивации
    {
        for (int i = 0; i < _objects.Count; i++)
        {
            GameObject obj = _objects[i].gameObject;
            if (!obj.activeInHierarchy && !obj.CompareTag("ReturningToPool"))
            {
                element = _objects[i];
                element.gameObject.SetActive(true);
                return true;
            }
        }

        element = null;
        return false;
    }
}
