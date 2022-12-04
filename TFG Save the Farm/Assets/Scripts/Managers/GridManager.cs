using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour{

    public static GridManager gridManager;

    [SerializeField] public int _Ancho, _Largo;
    [SerializeField] private Casilla _CasillaNormal, _CasillaCentral;
    [SerializeField] private BloqueCasillas _Bloqueador;

    [SerializeField] private Camera cam;

    private Dictionary<Vector2, Casilla> _Casillero;

    private void Awake() {
        gridManager = this;
    }

    public void GenerateGrid(){

        _Casillero = new Dictionary<Vector2, Casilla>();

        for (int x = 0; x < _Ancho; x++){
            for (int y = 0; y < _Largo; y++){
                if( (x == 6 && y == 3) || (x == 6 && y == 4) || (x == 6 && y == 5) || (x == 7 && y == 3) || (x == 7 && y == 4) || (x == 7 && y == 5) || (x == 8 && y == 3) || (x == 8 && y == 4) || (x == 8 && y == 5)){
                    _CasillaCentral.SetPosicionCasilla(x, y);
                    var spawnedcasillaCentral = Instantiate(_CasillaCentral, new Vector3(x,y), Quaternion.identity);
                    spawnedcasillaCentral.name = $"{x}|{y}";
                    _Casillero[new Vector2(x,y)] = spawnedcasillaCentral;
                }else{
                    _CasillaNormal.SetPosicionCasilla(x, y);
                    var spawnedTile = Instantiate(_CasillaNormal, new Vector3(x,y), Quaternion.identity);
                    spawnedTile.name = $"{x}|{y}";
                    
                    _Casillero[new Vector2(x,y)] = spawnedTile;
                }
            }
        }
        
        int[] precios = {40,30,40,20,10,20,5,5,20,10,20,40,30,40};

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
            var spawnedBloqueador = Instantiate(_Bloqueador, posiciones[e], Quaternion.identity);
            spawnedBloqueador.SetPosicion(((int)posiciones[e].x), (int)posiciones[e].y);
            spawnedBloqueador.name = $"{posiciones[e].x}|{posiciones[e].y}";
            spawnedBloqueador.SetPrecio(precios[e]);
        }

        
        Prueba();

        cam.transform.position = new Vector3((float)_Ancho/2 - 0.5f, (float)_Largo/2 - 0.5f, -10);
        GameManager.gameManager.ChangeState(GameManager.GameState.JuegoEnMarcha);
    }

    public Casilla GetTileAtPosition(Vector2 pos){
        if(_Casillero.TryGetValue(pos, out var tile)){
            return tile;
        }
        return null;
    }

    private void Prueba(){
        for (int x = 0; x < _Ancho; x++){
            for (int y = 0; y < _Largo; y++){
                var Tileee = GetTileAtPosition(new Vector2(x,y));
                Tileee.SetCasillasLados();
            }
        }


    }
    
}
