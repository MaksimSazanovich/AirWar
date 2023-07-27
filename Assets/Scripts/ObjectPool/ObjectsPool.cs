using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectsPool : MonoBehaviour
{
    protected readonly List<GameObject> objects = new List<GameObject>();
    public virtual void AddObjects(GameObject objectPrefab, int count)
    {
        for (int i = 0; i < count; i++)
        {
            InitObject(objectPrefab);
        }
    }

    public virtual void AddObjects(GameObject objectPrefab, int count, Vector3 position)
    {
        for (int i = 0; i < count; i++)
        {
            InitObject(objectPrefab);
        }
    }

    public virtual void AddObject(GameObject objectPrefab)
    {
        InitObject(objectPrefab);
    }

    public virtual void AddObject(GameObject objectPrefab, Vector3 position)
    {
        InitObject(objectPrefab, position);
    }

    public virtual void InitObject(GameObject objectPrefab)
    {
        GameObject currentObject = Instantiate(objectPrefab, transform);
        currentObject.SetActive(false);
        objects.Add(currentObject);
    }

    public virtual void InitObject(GameObject objectPrefab, Vector3 position)
    {
        GameObject currentObject = Instantiate(objectPrefab, position, Quaternion.identity, transform);
        currentObject.SetActive(false);
        objects.Add(currentObject);
    }

    public virtual GameObject GetObject()
    {
        for (int i = 0; i < objects.Count; i++)
        {
            if (!objects[i].activeInHierarchy)
                return objects[i];
        }
        return null;
    }

    public virtual GameObject GetRandomObject()
    {
        int i = Random.Range(0, objects.Count - 1);
        if (!objects[i].activeInHierarchy)
            return objects[i];
        return GetRandomObject();
    }
}