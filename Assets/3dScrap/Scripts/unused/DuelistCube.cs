using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuelistCube : MonoBehaviour
{
    public int luckyNumeber, duelcount =0;
    
    private bool isOnduel = false;

    void drawNumber(){
        luckyNumeber = Random.Range(0,2);
    }

    void duel(Collision other){
        DuelistCube otherCube = other.gameObject.GetComponent<DuelistCube>();
        drawNumber();

        if(luckyNumeber < otherCube.luckyNumeber){
            //gameObject.SetActive(false);
            Destroy(this.gameObject);
            //Debug.Log(gameObject.name+" lost");
        }else if(luckyNumeber == otherCube.luckyNumeber){
            //Debug.Log("drawn");
        }

        //Debug.Log("Name: "+gameObject.name+" Number:"+luckyNumeber);
        isOnduel = false;
        duelcount+=1;
    }

    private void OnCollisionEnter(Collision other) {
        if(isOnduel ==  false){
            isOnduel = true;
            duel(other);
        }
    }

    void Awake(){
        if (gameObject.GetComponent<Rigidbody>() == null)
        {
            gameObject.AddComponent<Rigidbody>();            
        }
        if (gameObject.GetComponent<BoxCollider>() == null)
        {
            gameObject.AddComponent<BoxCollider>();
        }

        Rigidbody rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeAll;
    }

    void Update(){
        
    }

}
