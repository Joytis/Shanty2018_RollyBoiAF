using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleHitController : MonoBehaviour {

    //Public Variables
    public enum HitType {Obstacle, Powerup};

    public HitType hittype;
    public float hitPowerLevel; //How strong are we
    public int scoreCost;
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
            //Figure out what hit type we are then apply accordingly what we're doing
            switch(hittype)
            {
                case HitType.Obstacle:
                    var hitDirection = (col.transform.position - transform.position).normalized;
                    col.gameObject.SendMessage("ApplyPowerLevel", hitPowerLevel, SendMessageOptions.DontRequireReceiver);
                    col.gameObject.SendMessage("ApplyDirection", hitDirection, SendMessageOptions.DontRequireReceiver);
                    col.gameObject.SendMessage("ApplyHit", deathType, SendMessageOptions.DontRequireReceiver);
                    break;
                case HitType.Powerup:
                    Debug.Log("Tell our whale to add score");
                    col.gameObject.SendMessage("ApplyScore", scoreCost, SendMessageOptions.DontRequireReceiver);
                    break;

            }
            Destroy(this.gameObject);
        }

    }
}
