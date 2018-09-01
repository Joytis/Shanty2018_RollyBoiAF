using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//For whatever reason unity is not serializing this class as it normally does
[System.Serializable]
public class ObjectItem  {

    //Public Variables
    public enum ObjectType {OBSTACLE, POWERUP, OTHER};

    public ObjectType objectType;

    public GameObject gamePrefab;

    public float speed;
    
}
