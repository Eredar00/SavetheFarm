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

}


