using UnityEngine;

public class DoShakeOnImpact : MonoBehaviour {

    [SerializeField] PersistentCameraShake3D _shakeData;

    // Range from 0-1
    Vector3 offset = Vector3.zero;
    Quaternion baseRotation;
    Quaternion rotation;

    public float shakePerForce = 1f; // Lol what is that unit.

    void OnCollisionEnter(Collision coll) {

    }

}