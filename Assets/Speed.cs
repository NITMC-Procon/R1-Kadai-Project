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
    private GameObject car_object = null;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Text score_text = score_object.GetComponent<Text>();
        float speed = car_object.GetComponent<Rigidbody>().velocity.magnitude * 3.6f;
        score_text.text = "Speed:" + Mathf.Floor(speed);
    }
}