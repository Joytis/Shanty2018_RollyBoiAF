/*
 * Spawn Manager by Thomas Baca for Whale roli poli
 * 
 * 
 * */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {

    //Public Variables
    public List<ObjectItem> objectList; //Our spawnable stuff we're going to have
    public List<Transform> spawnLocations; //Our spawn locations we can have
    public float spawnRate; //Our spawning rate of our game objects

    //Private variables
    private float timer = 0.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        //Increment our timer then when we reach over the spawn rate we randomly spawn our object

        timer += Time.deltaTime;

        if(timer > spawnRate)
        {
            //Spawn our object
            SpawnObject();
        }
	}

    void SpawnObject()
    {
        //Now we spawn a random object in a random spawn location
        int rand = Random.Range(0, objectList.Count - 1);
        int rand2 = Random.Range(0, spawnLocations.Count - 1);
        
        //Our object item class will handle how fast they move etc so we'll spawn our object
        //then apply the values we need
        GameObject go = (GameObject)Instantiate(objectList[rand].gamePrefab, spawnLocations[rand2].position, Quaternion.identity, null);

        //Now apply stuff
        go.GetComponent<Rigidbody>().velocity = Vector3.forward * objectList[rand].speed;
        Physics.IgnoreCollision(go.GetComponent<CapsuleCollider>(), GameObject.FindGameObjectWithTag("Paddle").GetComponent<BoxCollider>());
     timer = 0.0f;
    }
}

