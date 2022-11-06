using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCast : MonoBehaviour
{
    public Camera mainCamera;
    
    public GameObject currentGrid;
    public GameObject lastGrid;




    /*void Update(){
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out RaycastHit raycastHit)){
            currentGrid = raycastHit.collider.gameObject;
            currentGrid.GetComponent<SpriteRenderer>().color = new Color32(0,190,190,255);
            if(lastGrid != null && lastGrid != currentGrid){
                lastGrid.GetComponent<SpriteRenderer>().color = Color.white;
            }
            lastGrid = currentGrid;

            Debug.DrawLine(mainCamera.transform.position,raycastHit.point,Color.blue);
            if(Input.GetKeyUp(KeyCode.Mouse0)){
                //var g = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                //g.transform.position = raycastHit.point;
                raycastHit.collider.GetComponent<SpriteRenderer>().color = Color.blue;
            }
        }
    }*/
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