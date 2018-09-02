using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeOnCollisionWith : MonoBehaviour 
{
    [System.Serializable]
    public struct ShakeEffects
    {
        public string layer;
        public float intensity;

    }

    [SerializeField] ShakeEffects[] effetcs;
    [SerializeField] PersistentCameraShake3D _shakeData;

    void OnCollisionEnter(Collision coll)
    {
        var other = coll.gameObject;
        foreach(var effect in effetcs) 
            if(LayerMask.LayerToName(other.layer) == effect.layer)
                _shakeData.AddTrauma(effect.intensity);
    }
	
}
