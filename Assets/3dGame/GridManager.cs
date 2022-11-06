using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Local3DGame;

public class GridManager : MonoBehaviour{
    public static GridManager Instance {get; private set;}
    void Awake(){
        if (Instance == null){
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }else{
            Destroy(gameObject);
        }
    }

    public GameObject gridObj;
    public GameObject boardMap;

    public GridSystem3D baseGrid = new GridSystem3D(10,10,true);
    public GridSystem3D EnemyGgrid = new GridSystem3D(10,10,true);
    
    private void Start() {
        baseGrid.fillTiles(gridObj, boardMap.transform);    
    }
}

namespace Local3DGame{
    
    public class GridSystem3D{
        public List<List<GridEntity>> matrix = new List<List<GridEntity>>();
        
        public GridSystem3D(int rows, int columns){
            for (int x = 0; x < rows; x++){
                matrix.Add(new List<GridEntity>());
                for (int z = 0; z < columns; z++)
                {
                    matrix[x].Add(new GridEntity());
                }
            }
        }
        public GridSystem3D(int rows, int columns, bool fillVector){
            for (int x = 0; x < rows; x++){
                matrix.Add(new List<GridEntity>());
                for (int z = 0; z < columns; z++)
                {
                    matrix[x].Add(new GridEntity(new Vector3(x,0,z),new Position(x,z)));
                }
            }
        }
        public void FillVector(){
            int r = matrix.Count;
            for (int x = 0; x < r; x++){
                int c = matrix[x].Count;
                for (int z = 0; z < c; z++)
                {
                    matrix[x][z].vector3 = new Vector3(x,z,0);
                    matrix[x][z].position = new Position(x,z);
                }
            }
        }
        public void fillTiles(GameObject prefab, Transform parent){
            for (int x = 0; x < matrix.Count; x++){
                for (int z = 0; z < matrix[x].Count; z++){
                    matrix[x][z].gameObject = GridManager.Instantiate(prefab ,(parent.localPosition + matrix[x][z].vector3), prefab.transform.rotation, parent);
                    matrix[x][z].gameObject.name = "gridobjx"+x+"z"+z;
                    matrix[x][z].gameObject.GetComponent<SpriteRenderer>().enabled = false;
                    matrix[x][z].gameObject.GetComponent<GridObject>().position = new Position(x,z);
                }
            }
        }
        public void fillTiles(GameObject prefab, Transform parent, float offSet){
            for (int x = 0; x < matrix.Count; x++){
                for (int z = 0; z < matrix[x].Count; z++)
                {
                    if (x == 0 && z == 0)
                        matrix[x][z].gameObject = BoardManager.Instantiate(prefab ,(parent.localPosition + matrix[x][z].vector3), Quaternion.identity, parent);
                    else if(x == 0){
                        matrix[x][z].gameObject = BoardManager.Instantiate(prefab ,(parent.localPosition + matrix[x][z].vector3)+new Vector3(0,offSet*z,0), Quaternion.identity, parent);
                        matrix[x][z].vector3 = (matrix[x][z].vector3)+new Vector3(0,offSet*z,0);
                    }
                    else if(z == 0){
                        matrix[x][z].gameObject = BoardManager.Instantiate(prefab ,(parent.localPosition + matrix[x][z].vector3)+new Vector3(offSet*x,0,0), Quaternion.identity, parent);
                        matrix[x][z].vector3 = (matrix[x][z].vector3)+new Vector3(offSet*x,0,0);
                    }
                    else{
                        matrix[x][z].gameObject = BoardManager.Instantiate(prefab ,(parent.localPosition + matrix[x][z].vector3)+new Vector3(offSet*x,offSet*z,0), Quaternion.identity, parent);
                        matrix[x][z].vector3 = (matrix[x][z].vector3)+new Vector3(offSet*x,offSet*z,0);
                    }
                }
            }
        }
    }

    [System.Serializable]
    public class Position{
        public int posX;
        public int posZ;

        public Position(int x, int z){
            this.posX = x;
            this.posZ = z;
        }

    }

    public class GridEntity{
        public GameObject gameObject;
        public Vector3 vector3;
        public Position position;
        public bool isValid;

        public GridEntity(){

        }

        public GridEntity(Vector3 v3, Position position){
            this.vector3= v3;
            this.position = position;
            this.isValid = true;
        }
    }
}