using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//beweegt langs een path

public class PathFollower : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _arrivalThreshold;

    private Path _path;
    private Waypoint _currentWaypoint;

    private void Start()
    {
        SetupPath();
    }

    private void Update()
    {
        transform.LookAt(_currentWaypoint.GetPosition());
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
        
        //1. Am i near the currentWaypoint?
        float distanceToWaypoint = Vector3.Distance(transform.position, _currentWaypoint.GetPosition());
        if (distanceToWaypoint <= _arrivalThreshold)
        {
            //1.1 if yes, complete the path.
            if (_currentWaypoint == _path.GetPathEnd())
            {
                //1.1.1 Call upon Path Complete.
                PathComplete();
            }
            
            else
            {
                //1.2 if not, go to the next waypoint.
                _currentWaypoint = _path.GetNextWaypoint(_currentWaypoint);
                //1.2.1 Rotate to next waypoint.
                transform.LookAt(_currentWaypoint.GetPosition());
            }
            //1.3 Identifies that it has found the waypoint.
            Debug.Log("I'm close!");
            
        }
                    
    }

    private void SetupPath()
    {
        _path = FindObjectOfType<Path>();
        _currentWaypoint = _path.GetPathStart();
    }

    
    private void PathComplete()
    {
        //1.4 Indicates that it has reached the end.
        Debug.Log("ENDING!!!!");
        //1.4.1 Murders the object in question.
        Destroy(this.gameObject);
    }
}
