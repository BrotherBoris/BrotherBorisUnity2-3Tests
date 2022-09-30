using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPointer : MonoBehaviour
{
    public float units = 1;
    public Position position = new Position(0,0);
    public CoolDown movementCoolDown = new CoolDown(1f);
    
    [System.Serializable]
    public class CoolDown{
        public float coolDownTime =0;
        private bool isOnCoolDown = false;

        public bool IsOnCoolDown{get{return isOnCoolDown;} set{isOnCoolDown = value;}}

        public CoolDown(float coolSeconds){this.coolDownTime = coolSeconds;}

        public IEnumerator CoolIt(){
            yield return new WaitForSeconds(this.coolDownTime);
            this.isOnCoolDown = false;
        }
    }

    public void Move(Vector3 vector){
        if(movementCoolDown.IsOnCoolDown == false){

            movementCoolDown.IsOnCoolDown = true;
            transform.position += vector;
            StartCoroutine(movementCoolDown.CoolIt());
        }
    }

    public void MoveInGrid(int dir, Vector3 vector){
        if(movementCoolDown.IsOnCoolDown == false){
            if(getFowardPositin(dir)){
                movementCoolDown.IsOnCoolDown = true;
                transform.position += vector;
                UpdatePositin(dir);
                StartCoroutine(movementCoolDown.CoolIt());
            }
        }

    }
    bool getFowardPositin(int dir){
        switch (dir){
            case 2:
                var x = BoardManager.Instance.midOneGrid.matrix.Count;
                if(position.posX+1 >= x)
                    return false;
            break;
            case 0:
                var y = BoardManager.Instance.midOneGrid.matrix[0].Count;
                if(position.posY+1 >= y)
                    return false;
            break;
            case 1:
                if(position.posY-1 < 0)
                    return false;
            break;  
            case 3:
                if(position.posX-1 < 0)
                    return false;
            break;
        }
        return true;
    }
    void UpdatePositin(int dir){
        switch (dir){
            case 0:
                position.posY +=1;
            break;
            case 1:
                position.posY -=1;
            break;
            case 2:
                position.posX +=1;
            break;
            case 3:
                position.posX -=1;
            break;                    
        }    
    }

    void Update()
    {   
        if(Input.GetKey(KeyCode.D))
            MoveInGrid(2,new Vector3(units,0,0));
        if(Input.GetKey(KeyCode.A))
            MoveInGrid(3,new Vector3(units*-1,0,0));
        if(Input.GetKey(KeyCode.W))
            MoveInGrid(0,new Vector3(0,units,0));
        if(Input.GetKey(KeyCode.S))
            MoveInGrid(1,new Vector3(0,units*-1,0));
        if(Input.GetKeyDown(KeyCode.Space)){
            BoardManager.Instance.SpawnAt(position);
        }
    }
}
