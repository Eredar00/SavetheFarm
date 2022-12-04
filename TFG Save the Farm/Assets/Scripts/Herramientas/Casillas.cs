using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Casillas : MonoBehaviour, IPointerDownHandler{

    public static Casillas casillas;

    [SerializeField] private Sprite[] imagenes;
    [SerializeField] private int numero = 0;
    [SerializeField] private Herramienta _HerramientaActual;

    private void Awake() {
        casillas = this;
    }

    private void Start() {
        CambiarImagen();
    }

    public int getNumero(){return numero;}

    public void CambiarImagen(){
        transform.Find("Imagen").GetComponent<Image>().sprite = imagenes[numero];
    }

    public void SetHerramientaActual(Herramienta herramienta){
        _HerramientaActual = herramienta;
        numero = 0;
        CambiarImagen();
    }

    public void SiguienteCasilla(){
        int nivel = _HerramientaActual.NivelHerramientaCasillas;

        if(nivel == 1){numero = 0;}else if(nivel == numero){numero = 0;}else{numero++;}
        
        CambiarImagen();
    }

    public void OnPointerDown(PointerEventData eventData){
        SiguienteCasilla();
    }


}
