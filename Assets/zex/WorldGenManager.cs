using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class WorldGenManager : MonoBehaviour
{
    public static WorldGenManager Instance{private set; get;}

    public GameObject boardMap;
    public GameObject originlPoint;
    public GameObject[] roomPrefabs;

    private GameObject lastGeneratedRoom;
    
    public string RandomSocket(){
        int rs = Random.Range(0,2);
        switch (rs){
            case 0:
                return "Sock_Up";
            case 1:
                return "Sock_Right";
            default:
                return null;
        }
    }

    void Start(){
        lastGeneratedRoom = Instantiate(roomPrefabs[0],originlPoint.transform.position,originlPoint.transform.rotation,originlPoint.transform);
        StartCoroutine(GenerateRooms(7,2f));
    }

    IEnumerator GenerateRooms(int rooms, float duration){

        for (int i = 0; i < rooms; i++)
        {
            Transform childTransform = lastGeneratedRoom.transform.Find(RandomSocket());
            lastGeneratedRoom = Instantiate(roomPrefabs[0],childTransform.position,childTransform.rotation,boardMap.transform);
            yield return new WaitForSeconds(duration);
        }

    }



    void Awake(){
        if (Instance == null){
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }else{
            Destroy(gameObject);
        }
    }
}
