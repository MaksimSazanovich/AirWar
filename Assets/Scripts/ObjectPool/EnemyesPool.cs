using UnityEngine;
using Zenject;

public class EnemyesPool : ObjectsPool
{
    [SerializeField, Inject] private DiContainer _container;

    public override void InitObject(GameObject objectPrefab)
    {
        GameObject currentObject = _container.InstantiatePrefab(objectPrefab, transform);
        currentObject.SetActive(false);
        objects.Add(currentObject);
    }

    public override void InitObject(GameObject objectPrefab, Vector3 position)
    {
        GameObject currentObject = _container.InstantiatePrefab(objectPrefab, position, Quaternion.identity, transform);
        currentObject.SetActive(false);
        objects.Add(currentObject);
    }
}