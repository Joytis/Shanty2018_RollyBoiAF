using UnityEngine;

public class CameraShake3D : MonoBehaviour {

    [SerializeField] PersistentCameraShake3D _shakeData;

    // Range from 0-1
    Vector3 offset = Vector3.zero;
    Quaternion baseRotation;
    Quaternion rotation;

    void Awake() {
        baseRotation = transform.rotation;
    }

    void Update() {
        _shakeData.UpdateTrauma(Time.deltaTime);

        if(_shakeData.Trauma > 0) {
            float shake = _shakeData.Shake;
    
            // Compute shake angle and offset
            rotation = Quaternion.identity; 

            // Perlin noise based off current time. 
            offset.x = Mathf.PerlinNoise(Time.time * _shakeData.XTimeScale, 0.0f);
            offset.y = Mathf.PerlinNoise(0.0f, Time.time * _shakeData.YTimeScale);
            
            // Change range of number from (0,1) to (-1, 1) and scales by appropriate values.
            offset.x =  _shakeData.MaxAngle * shake * (offset.x - 0.5f) * 2f;
            offset.y =  _shakeData.MaxAngle * shake * (offset.y - 0.5f) * 2f;
    
            // Add it to camera for that frame. 
            transform.rotation = Quaternion.Euler(offset) * baseRotation;
        }
    }       
}