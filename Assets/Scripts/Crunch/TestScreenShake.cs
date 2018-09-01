using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScreenShake : MonoBehaviour {

    [SerializeField] PersistentCameraShake3D _shakeData;
    public float shameAmnt = 0.3f;

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) {
            Debug.Log("CameraShake3D Space pressed");
            _shakeData.AddTrauma(shameAmnt);
        }
    }
}
