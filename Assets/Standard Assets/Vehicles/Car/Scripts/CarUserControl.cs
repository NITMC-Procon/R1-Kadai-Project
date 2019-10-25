using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Vehicles.Car
{
    [RequireComponent(typeof (CarController))]
    public class CarUserControl : MonoBehaviour
    {
        private CarController m_Car; // the car controller we want to use
        public char Gear = 'd';
        private void Awake()
        {
            // get the car controller
            m_Car = GetComponent<CarController>();
        }

        float leave = 3.0f;
        private void FixedUpdate()
        {
            // pass the input to the car!

            float v = 0;
            float handbrake = 0.0f;
            if (Input.GetKey(KeyCode.R)) Gear = 'r';
            else if (Input.GetKey(KeyCode.D)) Gear = 'd';
            else if (Input.GetKey(KeyCode.B)) Gear = 'b';
            else if (Input.GetKey(KeyCode.N)) Gear = 'n';
            float h = CrossPlatformInputManager.GetAxis("Horizontal");
            if (Input.GetKey(KeyCode.UpArrow)) v = 1.0f; else v = 0.0f;
            if (Input.GetKey(KeyCode.Space)) handbrake = 1.0f; else handbrake = 0.0f;

            switch (Gear)
            {
                case 'r':
                    m_Car.Move(h, -v, -v, handbrake);
                    break;
                case 'd':
                    m_Car.Move(h, v, -handbrake, handbrake);
                    break;
                case 'b':
                    if (this.GetComponent<Rigidbody>().velocity.magnitude * 3.6 > 1)
                    m_Car.Move(h, v - this.GetComponent<Rigidbody>().velocity.magnitude * 3.6f / 200f, -handbrake, handbrake);
                    else m_Car.Move(h, v, -handbrake, handbrake);
                    break;
                case 'n':
                    m_Car.Move(h, 0, -handbrake, handbrake);
                    break;
            }
            
            if (Input.GetKey(KeyCode.J)) leave -= Time.deltaTime; else leave = 2.0f;
            if (leave <= 0 && leave >=-0.1f)
            {
                this.transform.position = new Vector3(-134.02f, 5.1f, -42.0f);
                this.transform.eulerAngles = new Vector3(0f,0f,0f);
                this.GetComponent<Rigidbody>().velocity = new Vector3(0f,0f,0f);
            }
            if(this.transform.position.y <= 3.0f)
            {
                this.transform.position = new Vector3(-134.02f, 5.1f, -42.0f);
                this.transform.eulerAngles = new Vector3(0f,0f,0f);
                this.GetComponent<Rigidbody>().velocity = new Vector3(0f,0f,0f);
            }
        }
    }
}
