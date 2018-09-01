using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour {

    public Transform followObject;
    public float heightOffset; //our height offset if we need to change it in the script for whatever reason
    public Vector3 offSet;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


        //Just follow the game objects X pos with offset

        transform.position = new Vector3(followObject.position.x + offSet.x, heightOffset, followObject.position.z + +offSet.z);
	}
}
