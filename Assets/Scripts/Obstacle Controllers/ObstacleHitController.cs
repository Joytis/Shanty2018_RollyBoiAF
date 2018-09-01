using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleHitController : MonoBehaviour {

    //Public Variables
    public float hitPowerLevel; //How strong are we
    public WhaleHealthManager.WhaleDeathType deathType; //What type of death type is this block going to be

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Whale")
        {
            col.gameObject.SendMessage("ApplyPowerLevel",hitPowerLevel, SendMessageOptions.DontRequireReceiver);
            col.gameObject.SendMessage("ApplyHit",deathType, SendMessageOptions.DontRequireReceiver);
        }
    }
}
