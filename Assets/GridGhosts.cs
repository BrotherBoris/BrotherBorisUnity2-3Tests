using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGhosts : MonoBehaviour
{
    MeshRenderer meshRenderer;
    Color32 originalColor;
    [SerializeField]Color32 highLightColor;


    void changeColor(Color32 color){
        meshRenderer.material.color = color;
    }
    
    private void Awake() {
        meshRenderer = GetComponent<MeshRenderer>();
        originalColor = (Color32)meshRenderer.material.color;;
    }

    private void OnMouseEnter() {
        changeColor(highLightColor);  
          
    }

    private void OnMouseDrag() {
       Debug.Log(Input.mousePosition);
    }

    private void OnMouseExit() {
        meshRenderer.material.color = originalColor;
    }

    private void Start() {
    }
}
