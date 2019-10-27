using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class enableRigbody : MonoBehaviour
{
    [SerializeField] private CameraShot Cam;
    GameObject Car;
    void Start(){
        SetKinematic(true);
        Car = GameObject.Find("Car");
    }
    void SetKinematic(bool newValue)
    {
	    Component[] components=GetComponentsInChildren(typeof(Rigidbody));
	    Component[] collider=GetComponentsInChildren(typeof(CapsuleCollider));

	    foreach (Component c in components)
	    {
		    (c as Rigidbody).isKinematic=newValue;
    	}
	    foreach (Component c in collider)
	    {
		    (c as CapsuleCollider).isTrigger=true;
    	}
    }
    void OnTriggerEnter(Collider collision)
    {
        string yourTag  = collision.gameObject.tag;
        if( yourTag == "Player" )
        {
            SetKinematic(false);
            Cam.CamShot();
		    this.GetComponent<Rigidbody>().AddForce(Car.GetComponent<Rigidbody>().velocity + new Vector3(0.0f,3.0f,0.0f));
        }
    }
}
