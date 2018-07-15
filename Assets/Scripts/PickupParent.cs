using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(SteamVR_TrackedObject))]

public class PickupParent : MonoBehaviour {

    SteamVR_TrackedObject trackedObj;
    SteamVR_Controller.Device device;


    void Awake () {
        trackedObj = GetComponent<SteamVR_TrackedObject>();

	}
	
	void FixedUpdate () {
		device = SteamVR_Controller.Input ((int)trackedObj.index);
	}
	
	
	void OnTriggerStay (Collider col)
    {
		if (col.attachedRigidbody != null) {
			//Debug.Log("PickupParent - Your right controller have collided with " + col.name + " and activated OnTriggerStay");
			if (device.GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
			{
				//Debug.Log("PickupParent - Your right controller have collided with " + col.name + " while holding down trigger");
				//Debug.Log ("OnTriggerStay + triggerdown: col.attachedRigidbody " + col.attachedRigidbody);
				col.attachedRigidbody.isKinematic = true;
				col.gameObject.transform.SetParent(gameObject.transform);
			}
			if (device.GetPressUp(SteamVR_Controller.ButtonMask.Trigger))
			{
				//Debug.Log("PickupParent - Your right controller have released trigger while colliding with " + col.name);
				col.gameObject.transform.SetParent(null);
				//Debug.Log ("OnTriggerStay + triggerup: col.attachedRigidbody " + col.attachedRigidbody);
				col.attachedRigidbody.isKinematic = false;

				
			}
		}
    }
	


    
}
