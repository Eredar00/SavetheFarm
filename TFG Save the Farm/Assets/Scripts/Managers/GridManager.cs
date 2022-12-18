using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour{

    public static GridManager gridManager;

    [SerializeField] public int _Ancho, _Largo;
    [SerializeField] private Casilla _CasillaNormal, _CasillaCentral;
    [SerializeField] private BloqueCasillas _Bloqueador;
    [SerializeField] private List<BloqueCasillas> _BloquesConjunto;
    [SerializeField] private Camera cam;

    private Dictionary<Vector2, Casilla> _CasilleroGM;

    private void Awake() {
        gridManager = this;
    }

    public void GenerateGrid(){

        _CasilleroGM = new Dictionary<Vector2, Casilla>();

        for (int x = 0; x < _Ancho; x++){
            for (int y = 0; y < _Largo; y++){
                _CasillaNormal.SetPosicionCasilla(x, y);
                var CasillaCreada = Instantiate(_CasillaNormal, new Vector3(x,y), Quaternion.identity);
                CasillaCreada.name = $"{x}|{y}";
                _CasilleroGM[new Vector2(x,y)] = CasillaCreada;
            }
        }
        
        CrearBloquesComprar();
        SetLadosCasillas();
        cam.transform.position = new Vector3((float)_Ancho/2 - 0.5f, (float)_Largo/2 - 0.5f, -10);

        if(EstadoJuego.EdJ._Bloques == null){
            EstadoJuego.EdJ._Bloques = new bool[15] {false, false, false, false, false, false, false, false, false, false, false, false,false, false, false};
            EstadoJuego.EdJ._Casillero = new int[_Ancho * _Largo, 3];
            PonerCasillas();
            GameManager.gameManager.ChangeState(GameManager.GameState.JuegoEnMarcha);
        }else{
            GameManager.gameManager.ChangeState(GameManager.GameState.CargarDatos);
        }        
    }

    public Casilla GetTileAtPosition(Vector2 pos){
        if(_CasilleroGM.TryGetValue(pos, out var tile)){
            return tile;
        }
        return null;
    }

    private void SetLadosCasillas(){
        for (int x = 0; x < _Ancho; x++){
            for (int y = 0; y < _Largo; y++){
                var Tileee = GetTileAtPosition(new Vector2(x,y));
                Tileee.SetCasillasLados();
            }
        }
    }

    private void PonerCasillas(){
        int cont = 0;
        for (int x = 0; x < _Ancho; x++){
            for (int y = 0; y < _Largo; y++){
                EstadoJuego.EdJ._Casillero[cont, 0] =  GetTileAtPosition(new Vector2(x,y)).GetTipoCasillaNumerico();
                EstadoJuego.EdJ._Casillero[cont, 1] =  0;
                EstadoJuego.EdJ._Casillero[cont, 2] =  0;
                cont++;
            }
        }
    }

    private void CrearBloquesComprar(){
        int contador = 0;
        int[] precios = {40,30,40,20,10,20,5,0,5,20,10,20,40,30,40};
        

        Vector3[] posiciones = {    new Vector3 { x = 1, y = 1, z = 0 } , 
                                    new Vector3 { x = 1, y = 4, z = 0 } , 
                                    new Vector3 { x = 1, y = 7, z = 0 } ,
                                    new Vector3 { x = 4, y = 1, z = 0 } ,
                                    new Vector3 { x = 4, y = 4, z = 0 } ,
                                    new Vector3 { x = 4, y = 7, z = 0 } ,
                                    new Vector3 { x = 7, y = 1, z = 0 } ,
                                    new Vector3 { x = 7, y = 4, z = 0 } ,
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
            spawnedBloqueador.ID = contador;
            contador++;
            spawnedBloqueador.SetPosicion(((int)posiciones[e].x), (int)posiciones[e].y);
            spawnedBloqueador.name = $"{posiciones[e].x}|{posiciones[e].y}";
            spawnedBloqueador.SetPrecio(precios[e]);
            _BloquesConjunto.Add(spawnedBloqueador);
        }
    }

    public void CargarBloquesCasillas(){
        for (int e = 0; e < _BloquesConjunto.Count; e++){
            if(EstadoJuego.EdJ._Bloques[e] == true){
                _BloquesConjunto[e].QuitarBloquesYaDesbloqueados();
            }
        }

        int cont = 0;
        for (int x = 0; x < _Ancho; x++){
            for (int y = 0; y < _Largo; y++){
                if(GetTileAtPosition(new Vector2(x,y)).GetTipoCasilla() != TipoCasilla.Bloqueado){
                    GetTileAtPosition(new Vector2(x,y)).SetTipoCasillaNumerico(EstadoJuego.EdJ._Casillero[cont, 0]);
                    //GetTileAtPosition(new Vector2(x,y)).GetPlanta().SetTipoVegetalNumerico(EstadoJuego.EdJ._Casillero[cont, 1]);
                    //GetTileAtPosition(new Vector2(x,y)).GetPlanta().SetCrecimientoNumerico(EstadoJuego.EdJ._Casillero[cont, 2]);
                }
                cont++;
            }
        }



    }
    
}
