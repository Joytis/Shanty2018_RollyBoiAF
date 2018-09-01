using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class MouseDeltaGrabber : MonoBehaviour {

    public AxisInputObject axisInputObject;
    public Vector2 mouseDeltaScalar = Vector2.one;

    // Vector3 lastMousePosition;
    Vector2 screenSize; 

    // Vector2 normalizedMovementDelta;

    void OnEnable() {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void OnDisable() {
        Cursor.lockState = CursorLockMode.None;
    }


	// Use this for initialization
	void Start () {
        axisInputObject.RemoveAllDelta();

        screenSize = new Vector2(Screen.width, Screen.height);

        // lastMousePosition = Input.mousePosition;
	}
	
	// Update is called once per frame
	void Update () {
        // var position = Input.mousePosition;
        // var mouseDelta = position - lastMousePosition;

        var normalizedMovementDelta = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        normalizedMovementDelta *= Time.deltaTime;
        normalizedMovementDelta *= mouseDeltaScalar;

        axisInputObject.AddDelta(normalizedMovementDelta);
	}
}
