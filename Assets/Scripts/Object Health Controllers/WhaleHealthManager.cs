using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhaleHealthManager : MonoBehaviour {

    //Public Variables
    public enum WhaleDeathType {INSTAKILL, HOTJUMP, SLAP, HOTSLAP}; //Insta kill drops the whale off the platform, Hotjump gives the whale upwards movement, Slap pushes 
                                                                    //the whale to one side or the other, and hot slap does both slap and hotjump

    public WhaleDeathType deathType; //Our death type our whale is set to
    public float force; //The amount of force we place on the whale when we call the method we want


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ApplyScore(int score)
    {
        Debug.Log("Adding score ");
        GameObject.FindGameObjectWithTag("ScoreManager").SendMessage("EarnScore", score,SendMessageOptions.DontRequireReceiver);
    }

    void ApplyPowerLevel(float powerLevel)
    {
        force = powerLevel;
    }

    void ApplyHit(WhaleDeathType type)
    {
        //Change our deathtype to what we recieved from the object
        deathType = type;

        switch(deathType)
        {
            case WhaleDeathType.INSTAKILL:
                INSTAKILLTHEWHALE();
                break;
            case WhaleDeathType.HOTJUMP:
                HOTJUMP();
                break;
            case WhaleDeathType.SLAP:
                SLAP();
                break;
            case WhaleDeathType.HOTSLAP:
                HOTJUMP();
                SLAP();
                break;
        }
    }

    //Our methods that control what the heck happens to our poor poor fat whale
    void INSTAKILLTHEWHALE()
    {
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None; //Goodbye free willy!
        HOTJUMP();
    }

    //Have a nice flight WHALE!
    void HOTJUMP()
    {
        GetComponent<Rigidbody>().AddForce(force * Vector3.up);
    }

    void SLAP()
    {
        //Get random left or right direction based on 0 or 1 kiss method
        int rand = Random.Range(0, 1);

        //Slap the whale right
        if(rand > 0)
        {
            GetComponent<Rigidbody>().AddForce(force * Vector3.right);
        }else
        {
            GetComponent<Rigidbody>().AddForce(force * -Vector3.right);
        }
    }
}
