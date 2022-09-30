using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPointer : MonoBehaviour
{
    public Vector3 position = new Vector3(0,0,0);
    public float units = 1;
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

    public void MoveInGrid(string dir, Vector3 vect){
        

    }

    void Update()
    {
        if(Input.GetKey(KeyCode.D))
            Move(new Vector3(units,0,0));
        if(Input.GetKey(KeyCode.A))
            Move(new Vector3(units*-1,0,0));
        if(Input.GetKey(KeyCode.W))
            Move(new Vector3(0,units,0));
        if(Input.GetKey(KeyCode.S))
            Move(new Vector3(0,units*-1,0));
        if(Input.GetKeyDown(KeyCode.Space)){
            BoardManager.Instance.SpawnAt();
        }
    }
}
