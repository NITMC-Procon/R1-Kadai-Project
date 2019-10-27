using UnityEngine;
using System.Collections;
using UnityStandardAssets.Vehicles.Car;

public class CameraControll : MonoBehaviour
{

    public Transform target;

    private const float _distance = 6.2f;
    private Vector3 _offset = new Vector3(0f, 3.8f, -_distance);
    private Vector3 _lookDown = new Vector3(-10f, 0f, 0f);
    private const float _followRate = 0.3f;

    char Gear;
    void Start()
    {
        transform.position = target.TransformPoint(_offset);
        transform.LookAt(target, Vector3.up);
    }
    void FixedUpdate()
    {
        Gear = target.GetComponent<CarUserControl>().Gear;
        if (Gear != 'r') _offset = new Vector3(0f, 3.8f, -_distance);
        else _offset = new Vector3(0f, 3.8f, _distance);
        Vector3 desiredPosition = target.TransformPoint(_offset);
        Vector3 lerp = Vector3.Lerp(transform.position, desiredPosition, _followRate);
        Vector3 toTarget = target.position - lerp;
        toTarget.Normalize();
        toTarget *= _distance;
        transform.position = target.position - toTarget;
        transform.LookAt(target, Vector3.up);
        transform.Rotate(_lookDown);
    }
}