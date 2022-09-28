using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ListMatrix<T>{
    public List<List<T>> matrix = new List<List<T>>();
    
    public ListMatrix(int rows, int columns){
        for (int x = 0; x < rows; x++){
            matrix.Add(new List<T>());
        }
    }
}

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


    public List<List<string>> matrix = new List<List<string>>();

    private void Start() {
        matrix.Add(new List<string>());
        matrix.Add(new List<string>());
        matrix.Add(new List<string>());
        matrix.Add(new List<string>());
        matrix[0].Add("00");
        matrix[0].Add("01");
        matrix[1].Add("10");
        matrix[1].Add("11");
        matrix[1].Add("12");
        matrix[2].Add("20");
        matrix[2].Add("21");
        matrix[3].Add("30");
        matrix[3].Add("31");
        matrix[3].Add("32");
        matrix[3].Add("33");

        Debug.Log(matrix.Count);
        Debug.Log(matrix[0].Count);
        Debug.Log(matrix[1].Count);
        Debug.Log(matrix[2].Count);
        Debug.Log(matrix[3].Count);
        for (int x = 0; x < matrix.Count; x++)
        {
            for (int y = 0; y < matrix[x].Count; y++)
            {
                Debug.Log(matrix[x][y]);
            }
        }



       // Instantiate(roomPrefabs[1],new Vector3(0,0,0),Quaternion.identity,boardMap.transform);
        //var a = Instantiate(roomPrefabs[1],boardMap.transform.position + matrixGrid[0,0],Quaternion.identity,boardMap.transform);
        //a.transform.localPosition = new Vector3(1,0,0);
        //Debug.Log(a.transform.position);
        // Debug.Log(a.transform.localPosition);
        //FillList(5,5);
        //StartCoroutine(FillBoard());
        //fillMatrix();
        //StartCoroutine(yan());
    }

    IEnumerator yan(){
        var lp = boardMap.transform.position;
        for (int x = 0; x < matrixGrid.GetLength(0); x++)
        {
            Instantiate(roomPrefabs[1],lp + matrixGrid[x,0],Quaternion.identity,boardMap.transform);
            Instantiate(roomPrefabs[1],lp + matrixGrid[x,matrixGrid.GetLength(1)-1],Quaternion.identity,boardMap.transform);
        }
        for (int y = 1; y < matrixGrid.GetLength(1)-1; y++)
        {
            Instantiate(roomPrefabs[1],lp + matrixGrid[0,y],Quaternion.identity,boardMap.transform);
            Instantiate(roomPrefabs[1],lp + matrixGrid[matrixGrid.GetLength(0)-1,y],Quaternion.identity,boardMap.transform);
        }
        for (int x = 1; x < matrixGrid.GetLength(0)-1; x++)
        {
            for (int y = 1; y < matrixGrid.GetLength(1)-1; y++){
                Instantiate(roomPrefabs[2],lp + matrixGrid[x,y],Quaternion.identity,boardMap.transform);
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
