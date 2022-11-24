using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Accion : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private int numAccion;
    [SerializeField] private KeyCode tecla;
    [SerializeField] private Sprite[] imagenes;

    [SerializeField] private int nivelPE = 1;
    [SerializeField] private int nivelCasillas = 1;
    [SerializeField] private int costePE;
    [SerializeField] private String nombreHerramienta;
    [SerializeField] private String descripcionHerramienta;

    private void Start() {
        CambiarImagen();
        CalcularCostePE();
    }

    private void Update() {
        if(Input.GetKeyDown(tecla)){
            if(GameManager.gameManager.pausa == true) return;
            Acciones.acciones.CambiarAccion(numAccion); 
        }  
    }

    public void OnPointerDown(PointerEventData eventData){
        if(GameManager.gameManager.pausa == true) return;
        Acciones.acciones.CambiarAccion(numAccion); 
    }

    private void CambiarImagen(){
        transform.Find("Imagen").GetComponent<Image>().sprite = imagenes[nivelCasillas-1];
    }

    private void CalcularCostePE(){
        costePE = 12 - nivelPE;
    }

    public void SubirNivelPE(){
        nivelPE ++;
        CalcularCostePE();
    }

    public void SubirNivelCasillas(){
        nivelCasillas ++;
        CambiarImagen();
    }

    public String getNombreHerramienta(){
        return nombreHerramienta;
    }

    public String getDescripcionHerramienta(){
        return descripcionHerramienta;
    }

    public int getNivelPE(){
        return nivelPE;
    }

    public int getNivelCasillas(){
        return nivelCasillas;
    }

    public int getCostePE(){
        return costePE;
    }

    public Sprite getImagen(){
        return imagenes[nivelCasillas-1];
    }

    public int getNumAccion(){
        return numAccion;
    }
}
