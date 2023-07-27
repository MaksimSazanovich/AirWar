using UnityEngine;

public class BackGroundMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Vector3 startPos;
    [SerializeField] private Vector3 endPos;
    void Start()
    {
        transform.position = startPos;
    }

    void Update()
    {
        transform.position += Vector3.down * speed * Time.deltaTime;
        if (transform.position.y <= endPos.y)
        {
            transform.position = startPos;
        }
    }
}
