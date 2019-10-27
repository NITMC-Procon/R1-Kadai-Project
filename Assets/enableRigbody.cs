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
	    Component[] joints=GetComponentsInChildren(typeof(CharacterJoint));

	    foreach (Component c in components)
	    {
		    (c as Rigidbody).isKinematic=newValue;
    	}
        foreach (Component c in joints)
	    {
            SoftJointLimit HighLimit = (c as CharacterJoint).highTwistLimit;
            HighLimit.limit = 0.0f;
            (c as CharacterJoint).highTwistLimit = HighLimit;
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
