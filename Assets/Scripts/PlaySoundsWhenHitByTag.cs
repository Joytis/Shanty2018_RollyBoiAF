using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlaySoundsWhenHitByTag : MonoBehaviour {

    [System.Serializable]
    public struct SoundEffect
    {
        public AudioClip clip;
        public string tag;
        public float optionalImplulseThresh;

    }

    [SerializeField] SoundEffect[] effetcs;
    AudioSource _source;

    void Awake()
    {
        _source = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision coll)
    {
        var other = coll.gameObject;
        foreach(var effect in effetcs) 
            if(LayerMask.LayerToName(other.layer) == effect.tag && coll.impulse.magnitude > effect.optionalImplulseThresh)
                _source.PlayOneShot(effect.clip);
    }
}
