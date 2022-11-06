using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Local3DGame;

public class GridObject : MonoBehaviour
{
   public Local3DGame.Position position;

    void OnMouseEnter() {
        if(GridManager.Instance.EnemyGgrid.matrix[position.posX][position.posZ].isValid == false){
            this.GetComponent<SpriteRenderer>().enabled = true;
            this.GetComponent<SpriteRenderer>().color = Color.red;
        }else{
            this.GetComponent<SpriteRenderer>().enabled = true;
            this.GetComponent<SpriteRenderer>().color = new Color32(0,190,190,255);
        }
        activateAround();
    }

    void OnMouseExit() {
        this.GetComponent<SpriteRenderer>().color = Color.white;
        this.GetComponent<SpriteRenderer>().enabled = false;
        deActivateAround();
    }

    private void OnMouseDown() {
        if(this.GetComponent<SpriteRenderer>().enabled == true){
            Debug.Log(this.name);
            var g = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            g.transform.position = GridManager.Instance.EnemyGgrid.matrix[position.posX][position.posZ].vector3+GridManager.Instance.boardMap.transform.position;
            g.transform.localScale = new Vector3(0.5f,0.5f,0.5f);
            GridManager.Instance.EnemyGgrid.matrix[position.posX][position.posZ].gameObject = g;
            GridManager.Instance.EnemyGgrid.matrix[position.posX][position.posZ].isValid = false;
        }
    }

    void activateAround(){
        if (position.posX > 0){
            if(GridManager.Instance.baseGrid.matrix[position.posX - 1][(position.posZ)].isValid == false){
                GridManager.Instance.baseGrid.matrix[position.posX - 1][(position.posZ)].gameObject.GetComponent<SpriteRenderer>().color = Color.red;  
            }
            GridManager.Instance.baseGrid.matrix[position.posX - 1][(position.posZ)].gameObject.GetComponent<SpriteRenderer>().enabled = true;        
        }
        if (position.posX < (GridManager.Instance.baseGrid.matrix.Count-1)){
            if(GridManager.Instance.baseGrid.matrix[position.posX + 1][(position.posZ)].isValid == false){
                GridManager.Instance.baseGrid.matrix[position.posX + 1][(position.posZ)].gameObject.GetComponent<SpriteRenderer>().color = Color.red;  
            }
            GridManager.Instance.baseGrid.matrix[position.posX + 1][(position.posZ)].gameObject.GetComponent<SpriteRenderer>().enabled = true;
        }
        if (position.posZ > 0){
            if(GridManager.Instance.baseGrid.matrix[position.posX][(position.posZ - 1)].isValid == false){
                GridManager.Instance.baseGrid.matrix[position.posX][(position.posZ - 1)].gameObject.GetComponent<SpriteRenderer>().color = Color.red;  
            }
            GridManager.Instance.baseGrid.matrix[position.posX][(position.posZ - 1)].gameObject.GetComponent<SpriteRenderer>().enabled = true;
        }
        if (position.posZ < (GridManager.Instance.baseGrid.matrix[0].Count-1)){
            if(GridManager.Instance.baseGrid.matrix[position.posX][(position.posZ + 1)].isValid == false){
                GridManager.Instance.baseGrid.matrix[position.posX][(position.posZ + 1)].gameObject.GetComponent<SpriteRenderer>().color = Color.red;  
            }
            GridManager.Instance.baseGrid.matrix[position.posX][(position.posZ + 1)].gameObject.GetComponent<SpriteRenderer>().enabled = true;
        }    
    }
    void deActivateAround(){
        if (position.posX > 0){
            GridManager.Instance.baseGrid.matrix[position.posX - 1][(position.posZ)].gameObject.GetComponent<SpriteRenderer>().enabled = false;        
        }
        if (position.posX < (GridManager.Instance.baseGrid.matrix.Count-1)){
            GridManager.Instance.baseGrid.matrix[position.posX + 1][(position.posZ)].gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
        if (position.posZ > 0){
            GridManager.Instance.baseGrid.matrix[position.posX][(position.posZ - 1)].gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
        if (position.posZ < (GridManager.Instance.baseGrid.matrix[0].Count-1)){
            GridManager.Instance.baseGrid.matrix[position.posX][(position.posZ + 1)].gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }    
    }
}
