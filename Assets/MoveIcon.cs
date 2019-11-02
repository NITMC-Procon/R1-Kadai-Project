using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveIcon : MonoBehaviour
{
    Transform Car;
    public Manager Manager_Obj;
    // Start is called before the first frame update
    void Start()
    {
        Car = Manager_Obj.Car.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = (Car.position + new Vector3(0.0f,50.0f,0.0f));
    }
}
