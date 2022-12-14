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
    //[HideInInspector]
    private List<GameObject> generatedRooms = new List<GameObject>();
    
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
        StartGeneration(5,1f);
    }

    public void StartGeneration(int rooms, float interval){
        lastGeneratedRoom = Instantiate(roomPrefabs[0],originlPoint.transform.position,originlPoint.transform.rotation,originlPoint.transform);
        generatedRooms.Add(lastGeneratedRoom);
        //StartCoroutine(GenerateRooms(rooms,interval));
    }

    IEnumerator GenerateRooms(int rooms, float interval){
        yield return new WaitForSeconds(0.5f);
        for (int i = 0; i < rooms; i++)
        {
            Transform childTransform = lastGeneratedRoom.transform.Find(RandomSocket());
            lastGeneratedRoom = Instantiate(roomPrefabs[0],childTransform.position,childTransform.rotation,originlPoint.transform);
            generatedRooms.Add(lastGeneratedRoom);
            yield return new WaitForSeconds(interval);
        }
    }

    Vector3 ChooseDirection(){
        int rs = Random.Range(0,4);
        switch (rs){
            //up
            case 0:
                return new Vector3(0,1.5f,0);
            //right
            case 1:
                return new Vector3(1.5f,0,0);
            //down
            case 2:
                return new Vector3(0,-1.5f,0);
            //left
            case 3:
                return new Vector3(-1.5f,0,0);
            //default:right
            default:
                return new Vector3(1.5f,0,0);
        }
    }

    public void GenerateARoom(){
        Transform childTransform = lastGeneratedRoom.transform.Find(RandomSocket());
        lastGeneratedRoom = Instantiate(roomPrefabs[0],lastGeneratedRoom.transform.position+ChooseDirection(),lastGeneratedRoom.transform.rotation,originlPoint.transform);
        generatedRooms.Add(lastGeneratedRoom);
    }


    [UnityEditor.MenuItem("DebugTools/WorldGen/GenerateRooms")]
    public static void GenerateRooms(){
       WorldGenManager.Instance.StartGeneration(Random.Range(1,10),1f);
    }

    [UnityEditor.MenuItem("DebugTools/WorldGen/ResetBoard")]
    public static void ResetBoard(){
        for (int i = 0; i < WorldGenManager.Instance.generatedRooms.Count ; i++)
        {
            Destroy(WorldGenManager.Instance.generatedRooms[i]);
        }
        WorldGenManager.Instance.generatedRooms = new List<GameObject>();
        WorldGenManager.Instance.lastGeneratedRoom = null;
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
