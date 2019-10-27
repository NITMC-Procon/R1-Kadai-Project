using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapCamera : MonoBehaviour
{
    private Camera cam;
    private uint count;
    // Start is called before the first frame update
    void Start()
    {
        cam = this.GetComponent<Camera>();
        count = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(count%5 == 0){
            count = 1;
            cam.enabled = true;
            Debug.Log("TEST");
        }else{
            cam.enabled = false;
            count ++;
        }
    }
}
