using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListMatrix{
    public List<List<GridEntity>> matrix = new List<List<GridEntity>>();
    
    public ListMatrix(int rows, int columns){
        for (int x = 0; x < rows; x++){
            matrix.Add(new List<GridEntity>());
            for (int y = 0; y < columns; y++)
            {
                matrix[x].Add(new GridEntity());
            }
        }
    }
    public ListMatrix(int rows, int columns, bool fillVector){
        for (int x = 0; x < rows; x++){
            matrix.Add(new List<GridEntity>());
            for (int y = 0; y < columns; y++)
            {
                matrix[x].Add(new GridEntity(new Vector3(x,y,0),new Position(x,y)));
            }
        }
    }
    public void FillVector(){
        int r = matrix.Count;
        for (int x = 0; x < r; x++){
            int c = matrix[x].Count;
            for (int y = 0; y < c; y++)
            {
                matrix[x][y].vector3 = new Vector3(x,y,0);
                matrix[x][y].position = new Position(x,y);
            }
        }
    }
    public void fillTiles(GameObject prefab, Transform parent){
        for (int x = 0; x < matrix.Count; x++){
            for (int y = 0; y < matrix[x].Count; y++)
            {
                matrix[x][y].gameObject = BoardManager.Instantiate(prefab ,(parent.localPosition + matrix[x][y].vector3), Quaternion.identity, parent);
            }
        }
    }
    public void fillTiles(GameObject prefab, Transform parent, float offSet){
        for (int x = 0; x < matrix.Count; x++){
            for (int y = 0; y < matrix[x].Count; y++)
            {
                if (x == 0 && y == 0)
                    matrix[x][y].gameObject = BoardManager.Instantiate(prefab ,(parent.localPosition + matrix[x][y].vector3), Quaternion.identity, parent);
                else if(x == 0)
                    matrix[x][y].gameObject = BoardManager.Instantiate(prefab ,(parent.localPosition + matrix[x][y].vector3)+new Vector3(0,offSet*y,0), Quaternion.identity, parent);
                else if(y == 0)
                     matrix[x][y].gameObject = BoardManager.Instantiate(prefab ,(parent.localPosition + matrix[x][y].vector3)+new Vector3(offSet*x,0,0), Quaternion.identity, parent);
                else
                    matrix[x][y].gameObject = BoardManager.Instantiate(prefab ,(parent.localPosition + matrix[x][y].vector3)+new Vector3(offSet*x,offSet*y,0), Quaternion.identity, parent);
            }
        }
    }

    public void PrintAll(){
        for (int x = 0; x < matrix.Count; x++)
        {
            for (int y = 0; y < matrix[x].Count; y++)
            {
                Debug.Log(matrix[x][y].vector3);
                Debug.Log("X "+matrix[x][y].position.posX+" Y "+matrix[x][y].position.posY);
            }
        }
    }
}

public class Position{
    public int posX;
    public int posY;

    public Position(int x, int y){
        this.posX = x;
        this.posY = y;
    }

}

public class GridEntity{
    public GameObject gameObject;
    public Vector3 vector3;
    public Position position;

    public GridEntity(){

    }

    public GridEntity(Vector3 v3){
        this.vector3= v3;
    }

    public GridEntity(Vector3 v3, Position position){
        this.vector3= v3;
        this.position = position;
    }
}