using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class NonsensePlatformController : MonoBehaviour {

    public enum AxisOfRotation : byte { 
        X, 
        Y, 
        Z 
    }

    public enum MeshBounds : byte
    {
        Width,
        Height,
        Depth
    }

    // Actual input for the platform. 
    public AxisInputObject _aio;
    public Transform _whaleOrb;
    public PersistentCameraShake3D _shakeData;
    Collider _whaleCollider;
    Collider _meshCollider;

    public float maxAbsAngVelocity = 5f;
    public float maxAbsVertVelocity = 1f;
    [Range(0, 1)] public float bumpTrauma = 0.2f;
    public AxisOfRotation axis = AxisOfRotation.Z;

    public MeshBounds meshBoundsOffsetPlatform = MeshBounds.Height;
    public MeshBounds meshBoundsOffsetWhale = MeshBounds.Height;

    float currentAngVelocity = 0f;
    float currentVelocity = 0f;

    // Constrain the movement of our platform. 
    Vector3 originalPosition = Vector3.zero;
    public float allowedVerticalDeviation = 2f;
    Quaternion originalRotationDistance = Quaternion.identity;
    public float allowedAngularDeviation = 30f;

    bool shakeOnCooldown = false;
    public float shakeCooldown = 0.5f;

    void Awake() 
    {
        _meshCollider = GetComponent<Collider>();
        _whaleCollider = _whaleOrb.gameObject.GetComponent<Collider>();

        originalPosition = transform.position;
        originalRotationDistance = transform.rotation;
    }


    Vector3 GetAngularVelocity(float angle)
    {
        switch(axis)
        {
            case AxisOfRotation.X: 
                return new Vector3(-angle, 0, 0);
            case AxisOfRotation.Y: 
                return new Vector3(0, -angle, 0);
            case AxisOfRotation.Z: 
                return new Vector3(0, 0, -angle);
        }
        return Vector3.zero;
    }

    Vector3 GetBoundsOffset(MeshBounds bounds, Collider coll)
    {
        var extents = coll.bounds.extents;
        switch(bounds)
        {
            case MeshBounds.Width:
                return (extents.x * coll.transform.right);
            case MeshBounds.Height:
                return (extents.y * coll.transform.up);
            case MeshBounds.Depth:
                return (extents.z * coll.transform.forward);
        }
        return Vector3.zero;
    }

	// Update is called once per frame
	void Update () 
    {
        // Update the axes manually. 
        _aio.UpdateAxes(Time.deltaTime);
        _shakeData.MinimumTrauma = 0.0f;

        // Get Angular momentum. 
        // Bounds checking
        var cachedRotation = transform.rotation;
        var currentAngVelocity = _aio.Axes.x * maxAbsAngVelocity;
        Vector3 angularVelocity = GetAngularVelocity(currentAngVelocity);
        transform.rotation = Quaternion.Euler(angularVelocity) * transform.rotation;

        // Check if we're too rotated
        var angleDistance = Quaternion.Angle(transform.rotation, originalRotationDistance);
        if(Mathf.Abs(angleDistance) >allowedAngularDeviation)
        {
            // Stop movement and shake screen. 
            _aio.RemoveOneTenthX();
            transform.rotation = cachedRotation;
            _shakeData.MinimumTrauma = 0.1f;
        }

        // Move vertically
        var cachedPosition = transform.position;
        currentVelocity = _aio.Axes.y * maxAbsVertVelocity;
        var addedPosition = new Vector3(0, currentVelocity, 0); 
        transform.position += addedPosition;

        // Constrain the position. 
        if((transform.position - originalPosition).magnitude >  allowedVerticalDeviation) 
        {
            _aio.RemoveOneTenthY();
            transform.position = cachedPosition;
            _shakeData.MinimumTrauma = 0.1f;
        }

    }

    void OnCollisionStay()
    {
        // Move the whale slightly based off angle rotated. 
        var meshColliderBoudns = _meshCollider.bounds;

        // Offset pivot by meshes.
        var offset = GetBoundsOffset(meshBoundsOffsetPlatform, _meshCollider);
        var whaleOffset = GetBoundsOffset(meshBoundsOffsetWhale, _whaleCollider);
        var totalOffset = transform.position + offset + whaleOffset;
        _whaleOrb.RotateAround(totalOffset, Vector3.forward, currentAngVelocity);

        // var posToAdd = 
        var addedPosition = new Vector3(0, currentVelocity, 0); 
        _whaleOrb.position += addedPosition;
    }
}
