using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using System;

public class BoardController : MonoBehaviour
{
    [SerializeField]private int rows, columns;
    public Count countTest = new Count(0,0);
    
    [Serializable]//Shows instances on the edditor, must use "System"
    public class Count{
        public int minimum;
        public int maximum;

        public Count (int min, int max){
            minimum = min;
            maximum = max;
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
