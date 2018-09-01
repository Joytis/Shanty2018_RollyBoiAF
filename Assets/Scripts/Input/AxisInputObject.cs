using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "aio_AxisInputObject", menuName = "Game/AxisInputObject", order = 1)]
public class AxisInputObject : ScriptableObject {

    [SerializeField] float timeFromMaxToMin = 1.0f;
    public float TimeFromMaxToMin => timeFromMaxToMin;

    Vector2 _axes;
    public Vector2 Axes => _axes;
    public Vector2 Offset => _axes * _axes;

    // NOTE: Put rigidbodies in the bones and skin weights. 

    // float traumaDrainRate;

    // Use this for initialization
    // void OnEnable () => traumaDrainRate = 1f / timeFromMaxToMin;
    public void RemoveAllDelta() => _axes = Vector2.zero;
    public void RemoveOneTenthX() => _axes.x = 0.9f * _axes.x;
    public void RemoveOneTenthY() => _axes.y = 0.9f * _axes.y;
    
    public void AddDelta(Vector2 inputDelta) 
    {
        // Add to _axes and clamp to prevent overfitting. 
        _axes.x += inputDelta.x;
        _axes.x = Mathf.Clamp(_axes.x, -1, 1);
        if(Mathf.Approximately(0, _axes.x))
            _axes.x = 0;

        _axes.y += inputDelta.y;
        _axes.y = Mathf.Clamp(_axes.y, -1, 1);
        if(Mathf.Approximately(0, _axes.y))
            _axes.y = 0;
    }


    public void UpdateAxes(float deltaTime) {
        // _axes.x = ApproachZero(_axes.x, deltaTime);
        // _axes.y = ApproachZero(_axes.y, deltaTime);
    }
}
