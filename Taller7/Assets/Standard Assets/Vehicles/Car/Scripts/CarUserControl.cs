   
using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


namespace UnityStandardAssets.Vehicles.Car{
	
    [RequireComponent(typeof (CarController))]
    public class CarUserControl : MonoBehaviour{
		
		private CarController m_Car; // the car controller we want to use
        public GameObject s;
		public GameObject si;
		public GameObject sr;
		public GameObject si2;
		public GameObject sr2;
		
        private void Awake(){
            // get the car controller
            m_Car = GetComponent<CarController>();
        }

        private void FixedUpdate(){
            // pass the input to the car!
            float h = 0;//CrossPlatformInputManager.GetAxis("Horizontal");
            float v = 1;//CrossPlatformInputManager.GetAxis("Vertical");
			
			bool rigth = false;
			bool left = false;
			
			bool rigth2 = false;
			bool left2 = false;
			
			bool front = false;
            
			RaycastHit hit;
			
			if (Physics.Raycast(s.transform.position, s.transform.TransformDirection(Vector3.forward), out hit)){
			
				Debug.DrawRay(s.transform.position, s.transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
				Debug.Log("recto");
            
				if(hit.distance < 5.5f){
					front = true;
					v = 0.1f;
				}
			
				else{
					front = false;
					v = 0.1f;
				}
			}
			
			if (Physics.Raycast(si.transform.position, si.transform.TransformDirection(Vector3.forward), out hit)){
			
				Debug.DrawRay(si.transform.position, si.transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
				Debug.Log("Did Hit");
            
				if(hit.distance < 5.0f){
					left = true;
				}
				else{
					left = false;
				}
			}
			
			if (Physics.Raycast(sr.transform.position, sr.transform.TransformDirection(Vector3.forward), out hit)){
			
				Debug.DrawRay(sr.transform.position, sr.transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
				Debug.Log("Did Hit");
            
				if(hit.distance < 5.0f){
					rigth = true;
				}
				else{
					rigth = false;
				}
			}
			
			if (Physics.Raycast(si2.transform.position, si2.transform.TransformDirection(Vector3.forward), out hit)){
			
				Debug.DrawRay(si2.transform.position, si2.transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
				Debug.Log("Did Hit");
            
				if(hit.distance < 2.0f){
					left2 = true;
				}
				else{
					
					left2 = false;
				}
			}
			
			if (Physics.Raycast(sr2.transform.position, sr2.transform.TransformDirection(Vector3.forward), out hit)){
			
				Debug.DrawRay(sr2.transform.position, sr2.transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
				Debug.Log("Did Hit");
            
				if(hit.distance < 2.0f){
					rigth2 = true;
				}
				else{
					rigth2 = false;
				}
			}
			
			if((front == false)&&(rigth==true)&&(left==true)){
				h = 0;
			}
			
			else if(front == true){
				if((left == true)&&(rigth2 == false)){
					h = 1;
				}
				else if ((rigth == true)&&(left2==false)){
					h=-1;
				}
				else{
					h=0;
				}
			}
			
			else if((left == true) && (rigth2 == false)&&(front == false)){
				h = 1;
			}
			
			else if ((rigth == true) && (left2 == false)&&(front == false)){
				h = -1;
			}
			
			float handbrake = CrossPlatformInputManager.GetAxis("Jump");
			m_Car.Move(h, v, v, handbrake);

			m_Car.Move(h, v, v, 0f);

        }
    }
}
