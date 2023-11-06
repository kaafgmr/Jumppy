using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public void MoveCamera(Transform Pos)
    {
        transform.position = new Vector3(Pos.position.x, Pos.position.y, transform.position.z);
    }
}