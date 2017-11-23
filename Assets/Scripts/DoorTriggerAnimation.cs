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




	void OnTriggerEnter (Collider col) {
		dooranim.SetFloat("direction", 1);
		dooranim.SetTrigger("OpenDoorTrigger");

	}

	void OnTriggerExit (Collider col) {
		dooranim.SetFloat("direction", -1);
		dooranim.SetTrigger("CloseDoorTrigger");

	}
		
}
