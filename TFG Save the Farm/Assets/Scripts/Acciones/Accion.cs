using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Accion : MonoBehaviour, IPointerDownHandler
{
    
    [SerializeField] private int nivelHerramienta;
    [SerializeField] private int nivelHerramientaMax;
    [SerializeField] private int costeEnergia;
    [SerializeField] private int numAccion;
    [SerializeField] private KeyCode tecla;
    [SerializeField] private Sprite[] imagenes;

    private void Start() {
        transform.Find("Imagen").GetComponent<Image>().sprite = imagenes[0];
        nivelHerramienta = 1;
        costeEnergia = 5;
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

    public void SubirNivel(){
        nivelHerramienta ++;
        transform.Find("Imagen").GetComponent<Image>().sprite = imagenes[nivelHerramienta-1];
    }

    public void VariarCosteEnergia(int variacion){
        costeEnergia = costeEnergia + variacion;
    }

    public int ObtenerNivel(){
        return nivelHerramienta;
    }

    public int ObtenerNivelMax(){
        return nivelHerramientaMax;
    }

    public int ObtenerCosteEnergia(){
        return costeEnergia;
    }
}
