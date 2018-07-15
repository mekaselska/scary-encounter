using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveZombie : MonoBehaviour {

	public Transform player;
	public GameObject zombie;

	float speed = 2.0f;
	float forwardStepLength = 0.5f;
	
	private Vector3 targetDir;	
	private	RaycastHit hit;
	private	bool isLinecastBlocked;
	
	void Start()
	{
		Debug.Log("MoveZombie Start()");
		targetDir = player.position - transform.position;
		isLinecastBlocked = true;
		StartCoroutine(StepAndWait(2.5F));
	}
	
	void FixedUpdate()
	{
			//turning towards player
			
			targetDir = player.position - transform.position;
			targetDir.y = 0;
			float step = speed * Time.deltaTime;
			Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0F);
			transform.rotation = Quaternion.LookRotation(newDir);
	}

	private IEnumerator StepAndWait(float waitTime)
	{

		Debug.Log("StepAndWait1: Is Linecast blocked? " + Physics.Linecast(transform.position, player.position));
		
		while (zombie.activeInHierarchy)
		{
			Debug.Log("StepAndWait2: Is Linecast blocked? " + Physics.Linecast(transform.position, player.position));			
			//Debug.Log("Zombie active? " + zombie.activeInHierarchy);
			
			// IDEA:  if player in sight AND is not looking -> zombie raycast to player AND player field of view not include zombie
			//	move one step towards player with some time interval
			
			isLinecastBlocked = Physics.Linecast(transform.position, player.position, out hit);
			Debug.Log("StepAndWait2: isLinecastBlocked = " + isLinecastBlocked);
			if (hit.collider != null)
			{
				Debug.Log("Ray from zombie collided with " + hit.collider.name);
			} else {
				Debug.Log("Ray from zombie doesn't collide with anything");
			
				Debug.Log("MoveZombie StepAndWait() Zombie should take a step");
				Vector3 targetDirStep = Vector3.ClampMagnitude(targetDir, forwardStepLength);
				transform.position = transform.position + targetDirStep; 
				Debug.Log("MoveZombie StepAndWait() Zombie took a step");
			
			}
		yield return new WaitForSeconds(waitTime);
			
		}
		Debug.Log("Zombie active? " + zombie.activeInHierarchy);

	}
	

}
