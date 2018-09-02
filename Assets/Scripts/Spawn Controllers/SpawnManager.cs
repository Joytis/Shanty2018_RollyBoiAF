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
    public Transform spawnLocationParentTrans; //Where are our spawn points in the world?

    public float initialSpawnRate = 1.0f;
    public float timeToMaxSpawnRate = 60f;
    public float maxSpawnRate = 0.1f;
    float accumulatedTime = 0f;

    //Private variables
    private float timer = 0.0f;

	// Use this for initialization
	void Start () {
		
        //Lets populate our list
        for(int i = 0; i < spawnLocationParentTrans.childCount; i++)
        {
            //Add to our list of spawn locations
            spawnLocations.Add(spawnLocationParentTrans.GetChild(i));
        }
	}
	
	// Update is called once per frame
	void Update () {

        //Increment our timer then when we reach over the spawn rate we randomly spawn our object

        timer += Time.deltaTime;
        accumulatedTime += Time.deltaTime;

        spawnRate = Mathf.SmoothStep(initialSpawnRate, maxSpawnRate, accumulatedTime / timeToMaxSpawnRate);

        if(timer > spawnRate)
        {
            //Spawn our object
            SpawnObject();
        }
	}

    void SpawnObject()
    {
        int totalWeight = 0;
        foreach(var obj in objectList)
            totalWeight += obj.weight;

        // Choose object based on weight. 
        int rand = Random.Range(0, totalWeight);
        ObjectItem item = objectList[0];
        foreach(var obj in objectList) {
            item = obj;
            rand -= obj.weight;
            if(rand < 0 )
                break;
        }


        //Now we spawn a random object in a random spawn location
        int rand2 = Random.Range(0, spawnLocations.Count);
        
        //Our object item class will handle how fast they move etc so we'll spawn our object
        //then apply the values we need
        GameObject go = (GameObject)Instantiate(item.gamePrefab, spawnLocations[rand2].position, Quaternion.identity, null);

        //Now apply stuff
        go.GetComponent<Rigidbody>().velocity = Vector3.forward * item.speed;
        var coll = go.GetComponent<Collider>();
        var paddle = GameObject.FindGameObjectWithTag("Paddle");
        var paddleColl = paddle.GetComponent<Collider>();
        Physics.IgnoreCollision(coll, paddleColl);
        timer = 0.0f;
    }
}

