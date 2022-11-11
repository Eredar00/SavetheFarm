using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Acciones : MonoBehaviour{   

    public static Acciones acciones;

    [SerializeField] private int numeroAccionActual;
    [SerializeField] private GameObject[] conjuntoAcciones;

    private void Awake() {
        acciones = this;
    }

    private void Start() {
        CambiarAccion(1);
    }

    public void CambiarAccion(int numeroAccionNueva){
        numeroAccionActual = numeroAccionNueva;

        for (int i = 0; i < conjuntoAcciones.Length; i++){
            conjuntoAcciones[i].GetComponentInChildren<Text>().color = Color.white;
        }

        conjuntoAcciones[numeroAccionNueva-1].GetComponentInChildren<Text>().color = Color.red;

        Tile tileF = GameManager.gameManager.ObtenerTileFocused();

        if(tileF != null){
            tileF.ConjuntoQuitarHighlight();
            tileF.ConjuntoCambiarHighlight(tileF);
        } 
    }

    public int ObtenerValorAccionActual(){
        return numeroAccionActual;
    }

    public GameObject[] ObtenerConjuntoAcciones(){
        return conjuntoAcciones;
    }

    public void ResultadoAccion(Tile tileRecibido, int numAccion){
        int costeEnergia = Acciones.acciones.ObtenerConjuntoAcciones()[numAccion-1].GetComponent<Accion>().ObtenerCosteEnergia();
            
            if(numAccion == 1){

                if(tileRecibido.ObtenerTipoTile() == TileState.Tierra_Seca) {tileRecibido.ChangeTileState(TileState.Arado_Seca); GameManager.gameManager.VariarPuntosEnergia(-costeEnergia); }
                else if(tileRecibido.ObtenerTipoTile() == TileState.Tierra_Mojada) {tileRecibido.ChangeTileState(TileState.Arado_Mojado); GameManager.gameManager.VariarPuntosEnergia(-costeEnergia); }
                
            
            }else if(numAccion == 2){

                if(tileRecibido.ObtenerTipoTile() == TileState.Arado_Seca) {tileRecibido.ChangeTileState(TileState.Plantado_Seca); GameManager.gameManager.VariarPuntosEnergia(-costeEnergia); }
                else if(tileRecibido.ObtenerTipoTile() == TileState.Arado_Mojado) {tileRecibido.ChangeTileState(TileState.Plantado_Mojado); GameManager.gameManager.VariarPuntosEnergia(-costeEnergia); }
            
            }else if(numAccion == 3){

                if(tileRecibido.ObtenerTipoTile() == TileState.Tierra_Seca) {tileRecibido.ChangeTileState(TileState.Tierra_Mojada); GameManager.gameManager.VariarPuntosEnergia(-costeEnergia); }
                else if(tileRecibido.ObtenerTipoTile() == TileState.Arado_Seca) {tileRecibido.ChangeTileState(TileState.Arado_Mojado); GameManager.gameManager.VariarPuntosEnergia(-costeEnergia); }
                else if(tileRecibido.ObtenerTipoTile() == TileState.Plantado_Seca) {tileRecibido.ChangeTileState(TileState.Plantado_Mojado); GameManager.gameManager.VariarPuntosEnergia(-costeEnergia); }
                else if(tileRecibido.ObtenerTipoTile() == TileState.Cultivado_Seca) {tileRecibido.ChangeTileState(TileState.Cultivado_Mojado); GameManager.gameManager.VariarPuntosEnergia(-costeEnergia); }
            
            }else if(numAccion == 4){

                if(tileRecibido.ObtenerTipoTile() == TileState.Cosecha_Seca) {tileRecibido.ChangeTileState(TileState.Tierra_Seca); tileRecibido.QuitarCosecha(); tileRecibido.EliminarPlanta(); GameManager.gameManager.VariarPuntosEnergia(-costeEnergia); }
                if(tileRecibido.ObtenerTipoTile() == TileState.COsecha_Mojado) {tileRecibido.ChangeTileState(TileState.Tierra_Mojada); tileRecibido.QuitarCosecha(); tileRecibido.EliminarPlanta(); GameManager.gameManager.VariarPuntosEnergia(-costeEnergia); }
           
            }else if(numAccion == 5){

                if(tileRecibido.ObtenerTipoTile() == TileState.Plantado_Seca) {tileRecibido.ChangeTileState(TileState.Arado_Seca); GameManager.gameManager.VariarPuntosEnergia(-costeEnergia); }
                else if(tileRecibido.ObtenerTipoTile() == TileState.Plantado_Mojado) {tileRecibido.ChangeTileState(TileState.Arado_Mojado); GameManager.gameManager.VariarPuntosEnergia(-costeEnergia); }
                else if(tileRecibido.ObtenerTipoTile() == TileState.Cultivado_Seca) {tileRecibido.ChangeTileState(TileState.Tierra_Seca); tileRecibido.EliminarPlanta(); GameManager.gameManager.VariarPuntosEnergia(-costeEnergia); }
                else if(tileRecibido.ObtenerTipoTile() == TileState.Cultivado_Mojado) {tileRecibido.ChangeTileState(TileState.Tierra_Mojada); tileRecibido.EliminarPlanta(); GameManager.gameManager.VariarPuntosEnergia(-costeEnergia); }
            
            }
    }

    public String ComprobarQueHighlightAccion(Tile tile, TileState tipoTile, int numAccion){
        if((numAccion == 1) && (tipoTile == TileState.Bloqueado || tipoTile == TileState.Arado_Seca || tipoTile == TileState.Arado_Mojado || tipoTile == TileState.Plantado_Seca || tipoTile == TileState.Plantado_Mojado || tipoTile == TileState.Cultivado_Seca || tipoTile == TileState.Cultivado_Mojado)){return "Roja";}
        if((numAccion == 2) && (tipoTile == TileState.Bloqueado || tipoTile == TileState.Tierra_Seca || tipoTile == TileState.Tierra_Mojada || tipoTile == TileState.Plantado_Seca || tipoTile == TileState.Plantado_Mojado || tipoTile == TileState.Cultivado_Seca || tipoTile == TileState.Cultivado_Mojado)){ return "Roja";}
        if((numAccion == 3) && (tipoTile == TileState.Bloqueado || tipoTile == TileState.Tierra_Mojada || tipoTile == TileState.Arado_Mojado|| tipoTile == TileState.Plantado_Mojado || tipoTile == TileState.Cultivado_Mojado)){ return "Roja";}
        if((numAccion == 4) && (tipoTile == TileState.Bloqueado || tipoTile == TileState.Tierra_Seca || tipoTile == TileState.Tierra_Mojada || tipoTile == TileState.Arado_Seca || tipoTile == TileState.Arado_Mojado || tipoTile == TileState.Plantado_Seca || tipoTile == TileState.Plantado_Mojado || tipoTile == TileState.Cultivado_Seca || tipoTile == TileState.Cultivado_Mojado)){ return "Roja";}
        if((numAccion == 5) && (tipoTile == TileState.Bloqueado || tipoTile == TileState.Tierra_Seca || tipoTile == TileState.Tierra_Mojada || tipoTile == TileState.Arado_Seca || tipoTile == TileState.Arado_Mojado)){ return "Roja";}
        if(!GameManager.gameManager.HaySuficientesPuntosEnergiaParaAccion()){return "Negra";}
        return "Seleccion";
    }

}


