using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftMover : MonoBehaviour
{
    public GameObject Lift;
    public List<Transform> Waypoints;

    public float MovementSpeed = 5.0f;
    public bool ShouldLoop = true;
    public float WaitAtWaitpointTime = 1.0f;

    private int _waypoimtIndex = 0;
    private float _moveTimer = 0.0f;
    private bool _isMoving = true;
    private Transform _liftTransform;

    private void Awake()
    {
        _liftTransform = Lift.transform;
    }

    private void Update()
    {
        if (Time.time >= _moveTimer)
        {
            MoveLift();
        }
    }

    private void MoveLift()
    {
        if ((Waypoints.Count != 0) && _isMoving) 
        {
            _liftTransform.position = Vector3.MoveTowards(_liftTransform.position, Waypoints[_waypoimtIndex].position, MovementSpeed * Time.deltaTime);

            if (Vector3.Distance(_liftTransform.position, Waypoints[_waypoimtIndex].position) <= 0.0f) 
            {
                _waypoimtIndex++;
                _moveTimer = Time.time + WaitAtWaitpointTime;
            }

            if (_waypoimtIndex >= Waypoints.Count)
            {
                if (ShouldLoop)
                {
                    _waypoimtIndex = 0;
                }
                else
                {
                    _isMoving = false;
                }
            }
        }
    }

}
