using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameWinLossController : MonoBehaviour {

    //Public Variables
    public float resetLevelTimer; //Our Timer to reload the level
    public Scene sceneToLoad; //Our level we need to load when we lose
    public ScoreManager scoreManager;
    public Transform whaleTrans; //Where are whale is
    public Transform floorTrans; //Where is the floor so if the whale hits the floor we lose
    public string lossMessage; //Poor poor player lost now we must inform him of his loss

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
        //If our whale's y pos is below our floor obviously we're lost to davey jones locker and have lost the game.
        if(whaleTrans.position.y < floorTrans.position.y)
        {
            //We've lost now we must stop the scoring screen
            //Flip our bool for game restart
            //Increment our restart timer
            //Then reload this current scene
        }
	}
}
