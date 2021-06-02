using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GunShip.Movement{
    public class Movement : MonoBehaviour
    {  
        [SerializeField] private Camera _camera ; 
        
        Touch touch ;       
        public void Start(){
            gameObject.transform.localScale = new Vector3(1.5f,1.5f,1.5f) ;
        }
        public void Update(){
            ShipMovement();
            ShipRotation();        }

        private void ShipMovement(){
            if(Input.touchCount == 0){
                transform.Translate(Vector3.forward*1f*Time.deltaTime,Space.World);
                _camera.transform.Translate(Vector3.forward*1f*Time.deltaTime,Space.World);
                
            }
            else if(Input.touchCount>0){
                touch = Input.GetTouch(0);
                gameObject.transform.localScale = new Vector3(1f,1f,1f) ;
                

                switch(touch.phase){
                    
                    case TouchPhase.Stationary:
                    transform.Translate(Vector3.forward*3f*Time.deltaTime,Space.World);
                    _camera.transform.Translate(Vector3.forward*3f*Time.deltaTime,Space.World);                 
                    break;

                    case TouchPhase.Moved:
                    _camera.transform.Translate(Vector3.forward*1f*Time.deltaTime,Space.World);
                    transform.Translate(Vector3.forward*0.01f*Time.deltaTime,Space.World);
                    transform.position = new Vector3(transform.position.x + touch.deltaPosition.x*0.05f,
                    0,
                    transform.position.z + touch.deltaPosition.y*0.05f ) ;
                    break;
                    // case TouchPhase.Moved:
                    // transform.position=new Vector3(transform.position.x +touch.position.x*0.05f,0,transform.position.z +touch.position.y*0.05f);
                    // break;

                }

        }

    }

        private void ShipRotation()
        {
            if (transform.position.x > 0)
            {
                // Debug.Log("Spaceship turn left");
                transform.rotation = Quaternion.AngleAxis(-30*0.5f, Vector3.forward);
            }
            else if (transform.position.x < 0)
            {
                transform.rotation = Quaternion.AngleAxis(30*0.5f, Vector3.forward);
            }

        }

    } 
}
       
    


