using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class InstantiatePoolObj : MonoBehaviour
{
    [SerializeField]
    private GameObject _prefab;
    [SerializeField]
    private Transform _parent;
    private List<GameObject> _pools = new List<GameObject>();
    public void InstantiateObject(Transform target)
    {
        GameObject obj = GetPooledObject();
        if (obj != null)
        {
            PositionObject(obj, target.position, target.rotation);
        }
    }
    public void InstantiateObject(Vector3 position)
    {
        GameObject obj = GetPooledObject();
        if (obj != null)
        {
            PositionObject(obj, position, Quaternion.identity);
        }
    }
    private void PositionObject(GameObject obj, Vector3 position, Quaternion rotation)
    {
        if (_parent != null)
        {
            obj.transform.SetParent(_parent, false);
            obj.transform.SetLocalPositionAndRotation(position, rotation);
        }
        else
        {
            obj.transform.SetLocalPositionAndRotation(position, rotation);
        }
        obj.SetActive(true);
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
