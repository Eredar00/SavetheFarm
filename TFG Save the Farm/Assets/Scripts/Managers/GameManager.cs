using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour{

    // Clases públicas
    public static GameManager gameManager;
    public GameState estadoActual;

    // Otras clases
    [SerializeField] private Acciones acciones;
    [SerializeField] private PuntosEnergia puntosEnergia;
    [SerializeField] public Boolean pausa;
    [SerializeField] public Boolean canvas;
    [SerializeField] private Calendario tiempo;
    [SerializeField] private Tile tileFocused;


    [SerializeField] private int numAccion;

    [SerializeField] public bool valorR;

    // Funcion Awake
    private void Awake() {
        gameManager = this;
        acciones = GetComponent<Acciones>();
    }

    // Función Start
    private void Start() {
        valorR = false;
        ChangeState(GameState.GenerarMapa);
        //numAccion = ObtenerAccion();
    }

    // Función Update
    private void Update() {
        if(Input.GetKeyDown(KeyCode.R)) valorR = !valorR;
    }
    

    // --------------------------------------------------------------------------
    // public int ComprobarNivelAccion()
    // --------------------------------------------------------------------------
    // Funcion para el Script "Tile" que mira y devuelve el nivel de la acción
    // seleccionada en ese momento. Así mismo, actualiza la variable "numAccion".
    // --------------------------------------------------------------------------
    // Return: int --> Nivel de Acción.
    // --------------------------------------------------------------------------
    public int ComprobarNivelAccion(){
        numAccion = Acciones.acciones.ObtenerValorAccionActual();
        return Acciones.acciones.ObtenerConjuntoAcciones()[numAccion-1].GetComponent<Accion>().ObtenerNivel();
    }

    // --------------------------------------------------------------------------
    // public String ComprobarQueHighlightProcede(Tile tile, TileState tipoTile)
    // --------------------------------------------------------------------------
    // Funcion utilizada para comprobar que tipo de "Highlight" debe mostrarse en 
    // una casilla cuando pasemos el cursor por encima, dependiendo de la casilla,
    // el tipo de esta, y la acción seleccionada en ese momento.
    // --------------------------------------------------------------------------
    // Return: String --> Tipo de Highlight.
    // --------------------------------------------------------------------------
    public String ComprobarQueHighlightProcede(Tile tile, TileState tipoTile){
        return acciones.ComprobarQueHighlightAccion(tile, tipoTile, numAccion);
    }
    

    // --------------------------------------------------------------------------
    // public void CambiarTileFocused(Tile tileRecibido)
    // --------------------------------------------------------------------------
    // Funcion utilizada para actualizar el valor de la variable "tileFocused"
    // que indica cual es la casilla donde se encuentra el cursor.
    // --------------------------------------------------------------------------
    // Return: ---
    // --------------------------------------------------------------------------
    public void CambiarTileFocused(Tile tileRecibido){
        tileFocused = tileRecibido;
    }


    // --------------------------------------------------------------------------
    // public Tile ObtenerTileFocused()
    // --------------------------------------------------------------------------
    // Funcion utilizada para devolver la casilla donde está el cursor, de cara a 
    // poder realizar operaciones sobre esta.
    // --------------------------------------------------------------------------
    // Return: Tile --> Casilla en la que está el cursor
    // --------------------------------------------------------------------------
    public Tile ObtenerTileFocused(){
        return tileFocused;
    }

    // --------------------------------------------------------------------------
    // public bool HaySuficientesPEParaAccion()
    // --------------------------------------------------------------------------
    // Funcion que comprueba si el jugador tiene suficientes Puntos de Energía
    // para poder realizar la acción seleccionada, devolviendo el resultado de 
    // la comprobación en formato Boleano.
    // También actualiza el valor de la variable "numAccion".
    // --------------------------------------------------------------------------
    // Return: Bool --> Resultado de comprobación de si hay suficientes PE
    // --------------------------------------------------------------------------
    public bool HaySuficientesPuntosEnergiaParaAccion(){
        numAccion = Acciones.acciones.ObtenerValorAccionActual();
        if(puntosEnergia.RevisarPE(-Acciones.acciones.ObtenerConjuntoAcciones()[numAccion-1].GetComponent<Accion>().ObtenerCosteEnergia())){
            return true;
        }else{
            return false;
        }
    }


    // --------------------------------------------------------------------------
    // public void VariarPuntosEnergia(int puntosQueVarian)
    // --------------------------------------------------------------------------
    // Funcion que varia los Puntos de Energía del jugador según el valor recibido.
    // --------------------------------------------------------------------------
    // Return: ---
    // --------------------------------------------------------------------------
    public void VariarPuntosEnergia(int puntosQueVarian){
        puntosEnergia.VariarPE(puntosQueVarian);
    }


    // --------------------------------------------------------------------------
    // public void EjecutarAccionSobreCasilla(Tile tileRecibido)
    // --------------------------------------------------------------------------
    // Funcion que, en caso de poder, ejecuta la acción seleccionada sobre la 
    // casilla seleccionada, transformandola y restando los Puntos de Energía que
    // correspondan.
    // --------------------------------------------------------------------------
    // Return: ---
    // --------------------------------------------------------------------------
    public void EjecutarAccionSobreCasilla(Tile tileRecibido){
        if(HaySuficientesPuntosEnergiaParaAccion()){
            acciones.ResultadoAccion(tileRecibido, numAccion);
        }
    }


    

    // -------------------------------------------------------------------
    // Función para cambiar de estado del juego
    // -------------------------------------------------------------------
    public void ChangeState(GameState nuevoEstado){
        estadoActual = nuevoEstado;

        switch (nuevoEstado) {
            case GameState.GenerarMapa:
                pausa = true;
                GridManager.gridManager.GenerateGrid();
                break;
            case GameState.CambiarDia:
                pausa = true;
                puntosEnergia.LlenarPE();
                ActualizarTiles();
                tiempo.SumarDia();
                ChangeState(GameManager.GameState.JuegoEnMarcha);
                break;
            case GameState.Pausa:
                pausa = true;
                break;
            case GameState.JuegoEnMarcha:
                pausa = false;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(nuevoEstado), nuevoEstado, null);
        }
        
        
    }

    // Otras funciones

    public void ActualizarTiles(){

        for (int x = 0; x < GridManager.gridManager.width; x++){
            for (int y = 0; y < GridManager.gridManager.height; y++){
                Tile Tileee = GridManager.gridManager.GetTileAtPosition(new Vector2(x,y));

                if(Tileee.ObtenerTipoTile() == TileState.Arado_Seca || Tileee.ObtenerTipoTile() == TileState.Plantado_Seca || Tileee.ObtenerTipoTile() == TileState.Tierra_Mojada){Tileee.ChangeTileState(TileState.Tierra_Seca);
                }else if(Tileee.ObtenerTipoTile() == TileState.Arado_Mojado){Tileee.ChangeTileState(TileState.Arado_Seca);
                }else if(Tileee.ObtenerTipoTile() == TileState.Plantado_Mojado || Tileee.ObtenerTipoTile() == TileState.Cultivado_Mojado){
                    Tileee.ChangeTileState(TileState.Cultivado_Seca);
                    Tileee.PlantarPlanta();
                    Tileee.CrecerPlanta(1);
                }else if(Tileee.ObtenerTipoTile() == TileState.Cultivado_Seca){
                    Tileee.ChangeTileState(TileState.Tierra_Seca);
                    Tileee.EliminarPlanta();
                }
            }
        }
    }

    


    public int ObtenerAccion(){
        //accion = acciones.ObtenerValorAccion();
        return acciones.ObtenerValorAccionActual();;
    }


    

    // Enum con los nombres de los estados posibles que hay en el juego
    public enum GameState{
        GenerarMapa,
        CambiarDia,
        Pausa,
        JuegoEnMarcha
    }


    


}
