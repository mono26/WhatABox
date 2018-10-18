using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Distances")]
    public Vector3 CameraOffset;

    [Header("Movement Speed")]
    /// How fast the camera moves
    public float CameraSpeed = 0.3f;

    [Header("Dependencies")]
    [SerializeField]
    protected Camera _camera;
    [SerializeField]
    protected Transform _target;

    protected float _offsetZ;
    protected Vector3 _lastTargetPosition;
    protected Vector3 _currentVelocity;

    protected void Awake()
    {
        _camera = GetComponent<Camera>();

        _lastTargetPosition = _target.position;
        _offsetZ = (transform.position - _target.position).z;
        transform.parent = null;

        return;
    }

    protected void LateUpdate()
    {
        //GetLevelBounds();

        FollowTarget();

        return;
    }

    protected virtual void FollowTarget()
    {
        // if the player has moved since last update
        float xMoveDelta = (_target.position - _lastTargetPosition).x;

        Vector3 aheadTargetPos = _target.position + Vector3.forward * _offsetZ + CameraOffset;
        Vector3 newCameraPosition = Vector3.SmoothDamp(transform.position, aheadTargetPos, ref _currentVelocity, CameraSpeed);

        transform.position = newCameraPosition;

        _lastTargetPosition = _target.position;
    }
}
