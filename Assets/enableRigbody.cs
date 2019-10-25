using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enableRigbody : MonoBehaviour
{
    void Start()
    {
        this.GetComponent<Rigidbody>().velocity = Vector3.zero;
    }
}
