using System.Collections.Generic;
using UnityEngine;

public class InstantiatePoolObj : MonoBehaviour
{
    [SerializeField]
    private GameObject _prefab;
    private List<GameObject> _pools = new List<GameObject>();
    public void InstantiateObject(Transform target)
    {
        GameObject obj = GetPooledObject();
        if ( obj != null)
        {
            obj.transform.position = target.position;
            obj.transform.rotation = target.rotation;
            obj.SetActive(true);
        }
    }
    private GameObject GetPooledObject()
    {
        GameObject obj = null;
        obj = _pools.Find(x => !x.activeInHierarchy);
        if (obj == null)
        {
            obj = Instantiate(_prefab);
            _pools.Add(obj);
            obj.SetActive(false);
        }
        return obj;
    }
}
