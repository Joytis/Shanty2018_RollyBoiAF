using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeThingOnCollideWith : MonoBehaviour {

    [System.Serializable]
    public struct ThingEffect
    {
        public GameObject thing;
        public string layer;
        public float destroyAfter;

    }

    [SerializeField] ThingEffect[] effetcs;
    AudioSource _source;

    void OnCollisionEnter(Collision coll)
    {
        var other = coll.gameObject;
        foreach(var effect in effetcs) {
            if(LayerMask.LayerToName(other.layer) == effect.layer) {
                // _source.PlayOneShot(effect.clip);
                var neweffect = GameObject.Instantiate(effect.thing, coll.contacts[0].point, Quaternion.identity);
                Destroy(neweffect, effect.destroyAfter);
            }
        }
    }
}
