using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour{
    public static BoardManager Instance {get; private set;}
    
    void Awake(){
        if (Instance == null){
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }else{
            Destroy(gameObject);
        }
    }

    public GameObject[] roomPrefabs;
    public GameObject boardMap;
    public GameObject selector;

    public ListMatrix baseGrid = new ListMatrix(7,7,true);
    public ListMatrix midOneGrid = new ListMatrix(7,7,true);

    
    private void Start() {
        //baseGrid.PrintAll();

        baseGrid.fillTiles(roomPrefabs[0], boardMap.transform,0.1f);
    }


    public void SpawnAt(Position selecPos){
        midOneGrid.matrix[selecPos.posX][selecPos.posY].gameObject = Instantiate(roomPrefabs[1],baseGrid.matrix[selecPos.posX][selecPos.posY].vector3+boardMap.transform.localPosition,Quaternion.identity ,boardMap.transform);    
    }

    ////boardWithNormalList////////boardWithNormalList////
        //FillList(5,5);
        //StartCoroutine(FillBoard());
    /* public List<Vector3> boardGrid = new List<Vector3>();

    void FillList(int X, int Y){
        for (int x = 0; x < X; x++)
        {
            for (int y = 0; y < Y; y++)
            {
                boardGrid.Add(new Vector3(x,y,0f));
            }
        }
    }

    IEnumerator FillBoard(){
        int bgt = boardGrid.Count;
        for (int i = 0; i < bgt; i++)
        {
            int rp = Random.Range(0,boardGrid.Count);
            Instantiate(roomPrefabs[2],boardGrid[rp],Quaternion.identity,boardMap.transform);
            boardGrid.RemoveAt(rp);
            yield return new WaitForSeconds(0.1f);
        }
    } */

    ////boardWithNormalList////////boardWithNormalList////

}
