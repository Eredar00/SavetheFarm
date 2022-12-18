using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CasillasHerramienta : MonoBehaviour, IPointerDownHandler{

    public static CasillasHerramienta casillasHerramienta;

    [SerializeField] private Sprite[] imagenes;
    [SerializeField] private int numeroR = 0;
    [SerializeField] private Herramienta _HerramientaActual;

    private void Awake() {
        casillasHerramienta = this;
    }

    private void Start() {
        CambiarImagen();
    }

    public int getNumero(){return numeroR;}

    public void CambiarImagen(){
        transform.Find("Imagen").GetComponent<Image>().sprite = imagenes[numeroR];
    }

    public void SetHerramientaActual(Herramienta herramienta){
        _HerramientaActual = herramienta;

        if(CalcularNumeroMax() < numeroR){
            numeroR = CalcularNumeroMax();
        }
        
        CambiarImagen();
    }

    public void SiguienteCasilla(){
        CalcularNumero();
        CambiarImagen();

        Casilla casilla = GameManager.gameManager.ObtenerTileFocused();

        if(casilla != null){
            casilla.QuitarTodosLosFocus();
            casilla.CambiarTodosLosFocus(casilla);
        } 
    }

    public void OnPointerDown(PointerEventData eventData){
        SiguienteCasilla();
    }

    private void CalcularNumero(){
        int nivel = _HerramientaActual.NivelHerramientaCasillas;

        if(nivel == 1){
            numeroR = 0;
        }else if(nivel == numeroR){
            numeroR = 0;
        }else{
            numeroR++;
        }
    }

    private int CalcularNumeroMax(){
        int nivel = _HerramientaActual.NivelHerramientaCasillas;

        if(nivel == 1){
            return 0;
        }else{
            return nivel;
        }
    }


}
