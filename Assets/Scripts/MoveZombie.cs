using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveZombie : MonoBehaviour {

	public Transform player;
	//Quaternion z_rotation;
	float speed = 2.0f;

	void Update()
	{
		Vector3 targetDir = player.position - transform.position;
		targetDir.y = 0;
		float step = speed * Time.deltaTime;
		Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0F);
		Debug.DrawRay(transform.position, newDir, Color.red);
		transform.rotation = Quaternion.LookRotation(newDir);

	}
}
