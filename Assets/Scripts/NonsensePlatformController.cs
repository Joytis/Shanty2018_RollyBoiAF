using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshCollider))]
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

    public float maxAbsAngVelocity = 5f;
    public AxisOfRotation axis = AxisOfRotation.Z;
    public MeshBounds meshBoundsOffset = MeshBounds.Height;

    public float maxAbsVertVelocity = 1f;

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

	// Update is called once per frame
	void Update () 
    {
        // Bounds checking
        var currentAngVelocity = _aio.Axes.x * maxAbsAngVelocity;

        // Get Angular momentum. 
        Vector3 angularVelocity = GetAngularVelocity(currentAngVelocity);
        transform.rotation = Quaternion.Euler(angularVelocity) * transform.rotation;

        // Move the whale slightly based off angle rotated. 
        var offsetPosition = 
        _whaleOrb.RotateAround(transform.position, Vector3.forward, currentAngVelocity);

        var currentVelocity = _aio.Axes.y * maxAbsVertVelocity;
        // var posToAdd = 
        var addedVelocity = new Vector3(0, currentVelocity, 0); 
        transform.position += addedVelocity;

        // Update the axes manually. 
        _aio.UpdateAxes(Time.deltaTime);

        // Add to whale for smooth transition. 
        _whaleOrb.position += addedVelocity;
	}
}
