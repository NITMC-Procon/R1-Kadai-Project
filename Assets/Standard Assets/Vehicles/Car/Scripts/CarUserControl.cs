using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Vehicles.Car
{
    [RequireComponent(typeof (CarController))]
    public class CarUserControl : MonoBehaviour
    {
        bool Controllers = false;
        private CarController m_Car; // the car controller we want to use
        public char Gear = 'd';
        float h = 0f;
        float v = 0f;
        float handbrake = 0f;
        private void Awake()
        {
            // get the car controller
            m_Car = GetComponent<CarController>();
            
            this.transform.position = new Vector3(-134.02f, 5.5f, -42.0f);
            this.transform.eulerAngles = new Vector3(0f,0f,0f);
            this.GetComponent<Rigidbody>().velocity = new Vector3(0f,0f,0f);
            var controllerNames = Input.GetJoystickNames();
            if( controllerNames[0] != "" ) Controllers = true;
        }

        float leave = 3.0f;
        private void FixedUpdate()
        {
                if(Controllers == true) Debug.Log(CrossPlatformInputManager.GetAxis("Handle"));
                
            if(Controllers == true){
                h = CrossPlatformInputManager.GetAxis("Handle");
                v = CrossPlatformInputManager.GetAxis("Accel")+1;
                Debug.Log((float)CrossPlatformInputManager.GetAxis("Handle"));
                handbrake = CrossPlatformInputManager.GetAxis("Brake")+1;
            }else{
                if (CrossPlatformInputManager.GetAxis("GearR") == 1) Gear = 'r';
                else if (CrossPlatformInputManager.GetAxis("GearD") == 1) Gear = 'd';
                else if (CrossPlatformInputManager.GetAxis("GearB") == 1) Gear = 'b';
                else if (CrossPlatformInputManager.GetAxis("GearN") == 1) Gear = 'n';
                if (Input.GetKey(KeyCode.R)) Gear = 'r';
                else if (Input.GetKey(KeyCode.D)) Gear = 'd';
                else if (Input.GetKey(KeyCode.B)) Gear = 'b';
                else if (Input.GetKey(KeyCode.N)) Gear = 'n';
                h = CrossPlatformInputManager.GetAxis("Horizontal");
                v = CrossPlatformInputManager.GetAxis("Vertical");
                if (Input.GetKey(KeyCode.Space)) handbrake = 1;
                else handbrake = 0;
            }
            

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
                this.transform.position = new Vector3(-134.02f, 5.5f, -42.0f);
                this.transform.eulerAngles = new Vector3(0f,0f,0f);
                this.GetComponent<Rigidbody>().velocity = new Vector3(0f,0f,0f);
            }
            if(this.transform.position.y <= 3.0f)
            {
                this.transform.position = new Vector3(-134.02f, 5.5f, -42.0f);
                this.transform.eulerAngles = new Vector3(0f,0f,0f);
                this.GetComponent<Rigidbody>().velocity = new Vector3(0f,0f,0f);
            }
        }
    }
}
