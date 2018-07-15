using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTriggerAnimation : MonoBehaviour {

	Animator dooranim;
	public Transform door;
	public float direction;

	void Awake () {
		dooranim = door.GetComponent<Animator>();
	}

	void OnCollisionEnter (Collision col) {
		Debug.Log("DoorTriggerAnimation - OnCollisionEnter");
	}
	
	void OnCollisionExit (Collision col) {
		Debug.Log("DoorTriggerAnimation - OnCollisionExit");
	}


	void OnTriggerEnter (Collider col) {
		Debug.Log("DoorTriggerAnimation - DoorOpener has started colliding with " + col.name + " and activated OnTriggerEnter");
		//Debug.Log("col.gameObject.tag == " + col.gameObject.tag);
		if(col.gameObject.tag == "Player") {
			dooranim.SetFloat("direction", 1);
			dooranim.SetTrigger("OpenDoorTrigger");
			Debug.Log("DoorTriggerAnimation - You have set OpenDoorTrigger");
		}

	}

	void OnTriggerExit (Collider col) {
		Debug.Log("DoorTriggerAnimation - DoorOpener has stopped colliding with " + col.name + " and activated OnTriggerExit");
		//Debug.Log("col.gameObject.tag == " + col.gameObject.tag);
		if(col.gameObject.tag == "Player") {
			dooranim.SetFloat("direction", -1);
			dooranim.SetTrigger("CloseDoorTrigger");
			Debug.Log("DoorTriggerAnimation - You have set CloseDoorTrigger");
		}

	}
		
}
