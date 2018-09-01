using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MouseDeltaGrabber : MonoBehaviour {

    public AxisInputObject axisInputObject;
    public Vector2 mouseDeltaScalar = Vector2.one;

    public float inputDeadTime = 0.3f;

    void OnEnable() {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void OnDisable() {
        Cursor.lockState = CursorLockMode.None;
    }


    // every 2 seconds perform the print()
    IEnumerator DeadenInputForTime(float waitTime)
    {
        float currentTime = 0f;
        while (currentTime < waitTime)
        {
            axisInputObject.RemoveAllDelta();
            yield return null;
            currentTime += Time.deltaTime;
        }
    }

	// Use this for initialization
	void Start () {
        axisInputObject.RemoveAllDelta();

        // HACK! Spin off a coroutine toat nulls inputs for a little bit of time. 
        StartCoroutine(DeadenInputForTime(inputDeadTime));
	}

	void Update () {

        var normalizedMovementDelta = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        normalizedMovementDelta *= Time.deltaTime;
        normalizedMovementDelta *= mouseDeltaScalar;

        axisInputObject.AddDelta(normalizedMovementDelta);
	}
}
