using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour{

    public static GridManager gridManager;

    [SerializeField] public int width, height;

    [SerializeField] private Tile casilla, casillaCentral;
    [SerializeField] private BloqueCasillas bloqueador;

    [SerializeField] private Camera cam;

    private Dictionary<Vector2, Tile> tiles;

    private void Awake() {
        gridManager = this;
    }

    public void GenerateGrid(){

        tiles = new Dictionary<Vector2, Tile>();
        for (int x = 0; x < width; x++){
            for (int y = 0; y < height; y++){
                if( (x == 6 && y == 3) || (x == 6 && y == 4) || (x == 6 && y == 5) || (x == 7 && y == 3) || (x == 7 && y == 4) || (x == 7 && y == 5) || (x == 8 && y == 3) || (x == 8 && y == 4) || (x == 8 && y == 5)){
                    casillaCentral.DarPosicion(x, y);
                    var spawnedcasillaCentral = Instantiate(casillaCentral, new Vector3(x,y), Quaternion.identity);
                    spawnedcasillaCentral.name = $"{x}|{y}";
                    tiles[new Vector2(x,y)] = spawnedcasillaCentral;
                }else{
                    casilla.DarPosicion(x, y);
                    var spawnedTile = Instantiate(casilla, new Vector3(x,y), Quaternion.identity);
                    
                    spawnedTile.name = $"{x}|{y}";
                    tiles[new Vector2(x,y)] = spawnedTile;
                }
            }
        }
        
        

        int[] precios = {1,2,3,4,5,6,7,8,9,10,11,12,13,14,15};

        Vector3[] posiciones = {    new Vector3 { x = 1, y = 1, z = 0 } , 
                                    new Vector3 { x = 1, y = 4, z = 0 } , 
                                    new Vector3 { x = 1, y = 7, z = 0 } ,
                                    new Vector3 { x = 4, y = 1, z = 0 } ,
                                    new Vector3 { x = 4, y = 4, z = 0 } ,
                                    new Vector3 { x = 4, y = 7, z = 0 } ,
                                    new Vector3 { x = 7, y = 1, z = 0 } ,
                                    new Vector3 { x = 7, y = 7, z = 0 } ,
                                    new Vector3 { x = 10, y = 1, z = 0 } ,
                                    new Vector3 { x = 10, y = 4, z = 0 } ,
                                    new Vector3 { x = 10, y = 7, z = 0 } ,
                                    new Vector3 { x = 13, y = 1, z = 0 } ,
                                    new Vector3 { x = 13, y = 4, z = 0 } ,
                                    new Vector3 { x = 13, y = 7, z = 0 } 
                                };

        for (int e = 0; e < posiciones.Length; e++){
            var spawnedBloqueador = Instantiate(bloqueador, posiciones[e], Quaternion.identity);
            spawnedBloqueador.DarPosicion(((int)posiciones[e].x), (int)posiciones[e].y);
            spawnedBloqueador.PonerPrecio(precios[e]);
        }

        
        Prueba();

        cam.transform.position = new Vector3((float)width/2 - 0.5f, (float)height/2 - 0.5f, -10);
        GameManager.gameManager.ChangeState(GameManager.GameState.JuegoEnMarcha);
    }

    public Tile GetTileAtPosition(Vector2 pos){
        if(tiles.TryGetValue(pos, out var tile)){
            return tile;
        }
        return null;
    }

    private void Prueba(){
        for (int x = 0; x < width; x++){
            for (int y = 0; y < height; y++){
                var Tileee = GetTileAtPosition(new Vector2(x,y));
                Tileee.getTileSides();
            }
        }
    }
    
}
