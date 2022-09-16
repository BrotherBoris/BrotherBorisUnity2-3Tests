using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomColor : MonoBehaviour{
    Coroutine invuFlash;
    MeshRenderer meshRenderer;

    [SerializeField]private float seconds = 0.1f;

    IEnumerator invulnerableFlash(float secs){
        for (int i = 0; i < 7; i++){
            yield return new WaitForSeconds(secs);
            changeColor(new Color32((byte)Random.Range(0,256),(byte)Random.Range(0,256),(byte)Random.Range(0,256),255));
        }
        invuFlash = null;
    }

    void changeColor(Color32 color){
        meshRenderer.material.color = color;
    }

    void Awake(){
        meshRenderer = GetComponent<MeshRenderer>();
    }

    void Update(){
        if (Input.GetKeyDown(KeyCode.Space)){
            if (invuFlash == null){
                invuFlash = StartCoroutine(invulnerableFlash(seconds));
            }else{
                StopCoroutine(invuFlash);
                invuFlash = null;
            }
        }
    }
}
