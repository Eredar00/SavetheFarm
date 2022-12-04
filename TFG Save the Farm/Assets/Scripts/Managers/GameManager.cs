using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour{

    // Clases públicas
    [Header("Public")]
    public static GameManager gameManager;
    public GameState estadoActual;
    private Hortalizas hortalizas;
    private Taller _TallerHerramientas;
    private Cultivos[] ListaCultivos;

    // Otras clases
    [SerializeField] private PuntosEnergia puntosEnergia;
    [SerializeField] public Boolean pausa;
    [SerializeField] public Boolean canvas;
    [SerializeField] private Calendario tiempo;
    [SerializeField] private Casilla _CasillaFocus;
    [SerializeField] private int _NumeroHerramienta;
    [SerializeField] private GameObject _InfoCasilla;

    public GameObject InfoCasilla { get => _InfoCasilla; set => _InfoCasilla = value; }
    public int NumeroHerramienta { get => _NumeroHerramienta; set => _NumeroHerramienta = value; }
    public Casilla CasillaFocus { get => _CasillaFocus; set => _CasillaFocus = value; }



    // Funcion Awake
    private void Awake() {
        gameManager = this;
        hortalizas = transform.GetComponent<Hortalizas>();
        _TallerHerramientas = transform.GetComponent<Taller>();
    }

    // Función Start
    private void Start() {
        ChangeState(GameState.GenerarMapa);
        InicializarVariables();
        
    }    

    private void InicializarVariables(){
        ListaCultivos = GameManager.gameManager.GetHortalizas().GetCultivos();
        ListaCultivos[0].GetComponent<Tomate>().Inicializar();
        ListaCultivos[1].GetComponent<Patata>().Inicializar();
        ListaCultivos[2].GetComponent<Zanahoria>().Inicializar();
    }

    public Hortalizas GetHortalizas(){return hortalizas;}
    public Taller GetTaller(){return _TallerHerramientas;}

    // --------------------------------------------------------------------------
    // public int ComprobarNivelAccion()
    // --------------------------------------------------------------------------
    // Funcion para el Script "Tile" que mira y devuelve el nivel de la acción
    // seleccionada en ese momento. Así mismo, actualiza la variable "numAccion".
    // --------------------------------------------------------------------------
    // Return: int --> Nivel de Acción.
    // --------------------------------------------------------------------------
    public int ComprobarNivelAccion(){
        NumeroHerramienta = _TallerHerramientas.NumeroHerramientaActual;
        return _TallerHerramientas.GetHerramientaPorPosicion(NumeroHerramienta-1).NivelHerramientaCasillas;
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
    public String ComprobarQueHighlightProcede(Casilla tile, TipoCasilla tipoTile){
        return _TallerHerramientas.ComprobarQueHighlightHerramienta(tile, tipoTile, NumeroHerramienta);
    }
    

    // --------------------------------------------------------------------------
    // public void CambiarTileFocused(Tile tileRecibido)
    // --------------------------------------------------------------------------
    // Funcion utilizada para actualizar el valor de la variable "tileFocused"
    // que indica cual es la casilla donde se encuentra el cursor.
    // --------------------------------------------------------------------------
    // Return: ---
    // --------------------------------------------------------------------------
    public void CambiarTileFocused(Casilla tileRecibido){
        CasillaFocus = tileRecibido;
    }


    // --------------------------------------------------------------------------
    // public Tile ObtenerTileFocused()
    // --------------------------------------------------------------------------
    // Funcion utilizada para devolver la casilla donde está el cursor, de cara a 
    // poder realizar operaciones sobre esta.
    // --------------------------------------------------------------------------
    // Return: Tile --> Casilla en la que está el cursor
    // --------------------------------------------------------------------------
    public Casilla ObtenerTileFocused(){
        return CasillaFocus;
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
        NumeroHerramienta = _TallerHerramientas.NumeroHerramientaActual;
        if(puntosEnergia.RevisarPE(-_TallerHerramientas.GetHerramientaPorPosicion(NumeroHerramienta-1).GetComponent<Herramienta>().CosteHerramientaPE)){
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
    public void EjecutarAccionSobreCasilla(Casilla tileRecibido){
        if(HaySuficientesPuntosEnergiaParaAccion()){
            _TallerHerramientas.ResultadoAccion(tileRecibido, NumeroHerramienta);
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

        for (int x = 0; x < GridManager.gridManager._Ancho; x++){
            for (int y = 0; y < GridManager.gridManager._Largo; y++){

                Casilla casilla = GridManager.gridManager.GetTileAtPosition(new Vector2(x,y));
                Planta planta = casilla.GetPlanta();

                if(casilla.GetTipoCasilla() == TipoCasilla.Arado_Seca || casilla.GetTipoCasilla() == TipoCasilla.Plantado_Seca || casilla.GetTipoCasilla() == TipoCasilla.Tierra_Mojada){
                    casilla.SetTipoCasilla(TipoCasilla.Tierra_Seca);

                }else if(casilla.GetTipoCasilla() == TipoCasilla.Arado_Mojado){
                    casilla.SetTipoCasilla(TipoCasilla.Arado_Seca);

                }else if(casilla.GetTipoCasilla() == TipoCasilla.Plantado_Mojado){
                    if(!casilla.GetPlanta().SigueRegada()){
                        casilla.SetTipoCasilla(TipoCasilla.Cultivado_Seca);
                        planta.SetImagenSprite(0);
                    }
                    planta.CrecerPlanta();
                }else if(casilla.GetTipoCasilla() == TipoCasilla.Cultivado_Mojado){
                    if(!casilla.GetPlanta().SigueRegada()){
                        casilla.SetTipoCasilla(TipoCasilla.Cultivado_Seca);
                    }
                    planta.CrecerPlanta();
                }else if(casilla.GetTipoCasilla() == TipoCasilla.Cultivado_Seca){
                    casilla.SetTipoCasilla(TipoCasilla.Tierra_Seca);
                    planta.EliminarPlanta();

                }
            }
        }
    }


    public void CambiarFocusCanvas(bool valor){
        canvas = valor;
    }



    // Enum con los nombres de los estados posibles que hay en el juego
    public enum GameState{
        GenerarMapa,
        CambiarDia,
        Pausa,
        JuegoEnMarcha
    }


    


}
