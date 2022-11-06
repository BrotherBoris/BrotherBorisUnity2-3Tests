using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCast : MonoBehaviour
{
    public GameObject lastHit;
    public Vector3 collisions;

    public Camera mainCamera;

    void Update(){
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out RaycastHit raycastHit)){
            collisions = raycastHit.point;
            Debug.DrawLine(mainCamera.transform.position,raycastHit.point,Color.blue);
            if(Input.GetKeyUp(KeyCode.Mouse0)){
                var g = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                g.transform.position = raycastHit.point;
            }
        }
    }
    void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(collisions, 0.2f);
    }
}
/* public GameObject lastHit;
    public Vector3 collisions;

    public Camera mainCamera;

    void Update(){
        var ray = new Ray(origin:this.transform.position, direction:this.transform.forward);
        RaycastHit raycastHit;
        if (Physics.Raycast(ray, out raycastHit, maxDistance: 100)){
            lastHit = raycastHit.transform.gameObject;
            collisions = raycastHit.point;
            Debug.DrawLine(this.transform.position, raycastHit.point, Color.blue);
           
        }
    }

    void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(collisions, 0.2f);
    } */