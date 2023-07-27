using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector3 m_Offset;
    private float m_ZCoord;

    private Vector2 _screenBounds;

    [SerializeField] private Camera _cam;

    private void Start()
    {
        _screenBounds = _cam.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, _cam.transform.position.z));
    }
    private void Update()
    {
        CheckBoundaries();
    }

    private void OnMouseDrag()
    {
        transform.position = GetMouseWorldPos() + m_Offset;
    }

    private void OnMouseDown()
    {
        m_ZCoord = _cam.WorldToScreenPoint(gameObject.transform.position).z;
        m_Offset = gameObject.transform.position - GetMouseWorldPos();
    }

    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = m_ZCoord;
        return _cam.ScreenToWorldPoint(mousePoint);
    }

    private void CheckBoundaries()
    {
        float X = Mathf.Clamp(transform.position.x, -_screenBounds.x, _screenBounds.x);
        float Y = Mathf.Clamp(transform.position.y, -_screenBounds.y, _screenBounds.y);
        transform.position = new Vector3(X, Y, 0);
    }
}
