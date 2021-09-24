using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// is een verzameling van waypoints
// en bied bepaalde toegang

public class Path : MonoBehaviour
{
    [SerializeField] private Waypoint[] _waypoints;

    public Waypoint GetPathStart()
    {
        return _waypoints[0];
    }

    public Waypoint GetPathEnd()
    {
        return _waypoints[_waypoints.Length - 1];
    }

    public Waypoint GetNextWaypoint(Waypoint currentWaypoint)
    {
        for (int i = 0; i < _waypoints.Length; i++)
        {
            if (_waypoints[i] == currentWaypoint)
            {
                return _waypoints[i + 1];
            }
        }
        return null;
    }
}
