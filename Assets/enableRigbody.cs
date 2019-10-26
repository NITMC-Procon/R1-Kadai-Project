using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class enableRigbody : MonoBehaviour
{
    Animator anim;
    void Start(){
        anim = this.GetComponent<Animator>();
        SetKinematic(true);
    }
    void SetKinematic(bool newValue)
    {
	    Component[] components=GetComponentsInChildren(typeof(Rigidbody));

	    foreach (Component c in components)
	    {
		    (c as Rigidbody).isKinematic=newValue;
    	}
    }

    void OnTriggerEnter(Collider collision)
    {
        string yourTag  = collision.gameObject.tag;
            if( yourTag == "Player" )
            {
                SetKinematic(false);
            }
    }
}
