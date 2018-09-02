using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionToAttackOnTrigger : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        var obj = other.gameObject;
        // We're done here. 
        if(obj.tag != "Shark") return;

        Debug.Log("Found a shark: " + obj.name);

        // Attmpt to make the shark attack. 
        var animator = obj.GetComponentInChildren<Animator>();
        Debug.Log(animator);

        if(animator) {
            animator.SetBool("GotoAttack", true);
        }
        else {
            Debug.LogWarning("Shark doesn't have animator");
        }
    }
}
