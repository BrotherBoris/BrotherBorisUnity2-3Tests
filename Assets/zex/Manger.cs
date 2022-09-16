using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manger : MonoBehaviour{
    public static Manger Instance {get; private set;}
    
    public int value;
    
    void Awake(){
        if (Instance == null){
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }else{
            Destroy(gameObject);
        }
    }
}
