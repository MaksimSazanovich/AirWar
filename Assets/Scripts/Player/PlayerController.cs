using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

//[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    //[SerializeField] private DynamicJoystick joystick;
    //[SerializeField] private RectTransform handle;

    //private Rigidbody2D rigidbody2D;
    //private Vector2 direction = Vector2.zero;

    //[SerializeField] private float speed = 3f;
    //[SerializeField] private float hor;
    //[SerializeField] private float vert;

    //private void Awake()
    //{
    //    rigidbody2D = GetComponent<Rigidbody2D>();
    //}
    //private void FixedUpdate()
    //{
    //    if (handle.position.x != 62.75344 || handle.position.y != 111.5617)
    //    {
    //        if (joystick.Horizontal != 0 || joystick.Vertical != 0)
    //        {
    //            direction.x = joystick.Horizontal - hor;
    //            direction.y = joystick.Vertical - vert;
    //            rigidbody2D.MovePosition(rigidbody2D.position + speed * Time.fixedDeltaTime * direction);
    //        }
    //    }
    //}

    //private void Update()
    //{

    //}

    private Vector3 mOffset;
    private float mZCoord;
    private void OnMouseDrag()
    {
        transform.position = GetMouseWorldPos() + mOffset;
    }

    private void OnMouseDown()
    {
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        mOffset = gameObject.transform.position - GetMouseWorldPos();
    }

    private Vector3 GetMouseWorldPos()
    { 
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = mZCoord;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }
}
