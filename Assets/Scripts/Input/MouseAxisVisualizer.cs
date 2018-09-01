using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class MouseAxisVisualizer : MonoBehaviour {

    public AxisInputObject _aio;

    public void Update()
    {
        Debug.Log(_aio.Axes);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, 1);
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + (Vector3)_aio.Axes);
    }
}
