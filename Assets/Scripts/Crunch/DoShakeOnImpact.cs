using UnityEngine;

public class DoShakeOnImpact : MonoBehaviour {

    [SerializeField] PersistentCameraShake3D _shakeData;
    public float shakePerForce = 0.1f; // Lol what is that unit.

    void OnCollisionEnter(Collision coll) 
    {
        _shakeData.AddTrauma(coll.impulse.magnitude * shakePerForce);
    }

}