using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed : MonoBehaviour
{
    [SerializeField]
    private GameObject score_object = null;
    [SerializeField]
    private Manager Manager_Obj;
    private GameObject car_object;
    void Start()
    {
        car_object = Manager_Obj.Car;
    }

    void Update()
    {
        Text score_text = score_object.GetComponent<Text>();
        float speed = car_object.GetComponent<Rigidbody>().velocity.magnitude * 3.6f;
        score_text.text = "スピード:" + Mathf.Floor(speed) + "km/h";
    }
}