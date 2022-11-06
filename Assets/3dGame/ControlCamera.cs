using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCamera : MonoBehaviour
{
    public float units = 20;

    public void Move(Vector3 vector){
        transform.position += vector* Time.deltaTime;
    }

    void Update(){
        if(Input.GetKey(KeyCode.D)){
            Move(new Vector3(units,0,0));
        }
        if(Input.GetKey(KeyCode.A)){
            Move(new Vector3(units*-1,0,0));
        }
        if(Input.GetKey(KeyCode.W)){
            Move(new Vector3(0,0,units));
        }
        if(Input.GetKey(KeyCode.S)){
            Move(new Vector3(0,0,units*-1));
        }        
    }
}
