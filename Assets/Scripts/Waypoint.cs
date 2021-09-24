using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// houdt een positie bij om ernaar toe te bewegen
public class Waypoint : MonoBehaviour
{
    public Vector3 GetPosition()
    {
        Vector3 position = transform.position;
        position.y += 0.5f;
        return position;
    }
}
