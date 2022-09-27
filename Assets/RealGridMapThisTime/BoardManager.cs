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

        matrixGrid = new Vector3[14,7];
    }

    public GameObject[] roomPrefabs;
    public GameObject boardMap;
    public List<Vector3> boardGrid = new List<Vector3>();
    public Vector3[,] matrixGrid;

    private void Start() {
        
        //FillList(5,5);
        //StartCoroutine(FillBoard());
        fillMatrix();
        StartCoroutine(yan());
    }

    IEnumerator yan(){
        for (int x = 0; x < matrixGrid.GetLength(0); x++)
        {
            Instantiate(roomPrefabs[1],matrixGrid[x,0],Quaternion.identity,boardMap.transform);
            Instantiate(roomPrefabs[1],matrixGrid[x,matrixGrid.GetLength(1)-1],Quaternion.identity,boardMap.transform);
        }
        for (int y = 1; y < matrixGrid.GetLength(1)-1; y++)
        {
            Instantiate(roomPrefabs[1],matrixGrid[0,y],Quaternion.identity,boardMap.transform);
            Instantiate(roomPrefabs[1],matrixGrid[matrixGrid.GetLength(0)-1,y],Quaternion.identity,boardMap.transform);
        }
        for (int x = 1; x < matrixGrid.GetLength(0)-1; x++)
        {
            for (int y = 1; y < matrixGrid.GetLength(1)-1; y++){
                Instantiate(roomPrefabs[2],matrixGrid[x,y],Quaternion.identity,boardMap.transform);
                yield return new WaitForSeconds(0.1f);
            }
        }
    }

    void fillMatrix(){
        for (int x = 0; x < matrixGrid.GetLength(0); x++)
        {
            for (int y = 0; y < matrixGrid.GetLength(1); y++)
            {
                matrixGrid[x,y] = new Vector3(x,y,0);
                
            }
        }
    }
    
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
    }




    
}
