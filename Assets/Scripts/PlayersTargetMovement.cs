using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersTargetMovement : MonoBehaviour
{
    public void SetPosition(Transform obj)
    {
        obj.position = Input.mousePosition;
    }
}
