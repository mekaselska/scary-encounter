using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ZombieDies : MonoBehaviour {
	

	public Transform tuikkaus;
	public GameObject ZombieDiesText;
	public GameObject zombie;
	
    void Awake () {
		ZombieDiesText.SetActive(false);
	}
	
	void OnTriggerEnter (Collider col)
    {
		//Debug.Log("ZombieDies - OnTriggerEnter - colliding with " + col.name);
		Transform tuikkausFound = col.transform.Find("tuikkaus");
		if (tuikkausFound) {
			Debug.Log("ZombieDies - found tuikkaus child");
			ExplodeZombie();
			Debug.Log("Zombie Exploded");
		}
    }
	

	
	void ExplodeZombie() {
        var exp = GetComponent<ParticleSystem>();
        exp.Play();
        zombie.SetActive(false);
		Debug.Log("Zombie Not Active");
		ZombieDiesText.SetActive(true);
    }
}
