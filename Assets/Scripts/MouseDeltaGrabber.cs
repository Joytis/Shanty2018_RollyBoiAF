using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class MouseDeltaGrabber : MonoBehaviour {

    public AxisInputObject axisInputObject;
    public Vector2 mouseDeltaScalar = Vector2.one;

    void OnEnable() {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void OnDisable() {
        Cursor.lockState = CursorLockMode.None;
    }


	// Use this for initialization
	void Start () {
        axisInputObject.RemoveAllDelta();
	}

	void Update () {

        var normalizedMovementDelta = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        normalizedMovementDelta *= Time.deltaTime;
        normalizedMovementDelta *= mouseDeltaScalar;

        axisInputObject.AddDelta(normalizedMovementDelta);
	}
}
