using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlBotones : MonoBehaviour{

    public static ControlBotones controlBotones;
    
    [SerializeField] GameObject tiendaHortalizas;
    [SerializeField] GameObject tiendaAcciones; 
    [SerializeField] GameObject calendario; 

    private void Awake() {
        controlBotones = this;
    }

    private void Start() {
        LimpiarTodosLosActive();
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.H)) verTiendaHortalizas();
        if(Input.GetKeyDown(KeyCode.T)) verTiendaAcciones();
        if(Input.GetKeyDown(KeyCode.C)) verCalendario();
    }

    public void LimpiarTodosLosActive(){
        tiendaHortalizas.SetActive(false);
        tiendaAcciones.SetActive(false);
        calendario.SetActive(false);
    }

    public GameObject getTiendaHortalizas(){return tiendaHortalizas;}

    private void verTiendaHortalizas(){
        if(tiendaHortalizas.activeSelf){
            tiendaHortalizas.SetActive(false);
            GameManager.gameManager.CambiarFocusCanvas(false);
        }else{
            LimpiarTodosLosActive();
            tiendaHortalizas.SetActive(true);
            tiendaHortalizas.transform.Find("Menu 02").gameObject.SetActive(false);
            tiendaHortalizas.transform.Find("Menu 01").gameObject.SetActive(true);
            
        }
    }

    private void verTiendaAcciones(){  
        if(tiendaAcciones.activeSelf){
            tiendaAcciones.SetActive(false);
            GameManager.gameManager.CambiarFocusCanvas(false);
        }else{
            LimpiarTodosLosActive();
            tiendaAcciones.GetComponent<Tienda_Acciones>().ActualizarTextos(Acciones.acciones.getAccionActual());
            tiendaAcciones.SetActive(true);
        }
    }

    public void verCalendario(){
        if(calendario.activeSelf){
            calendario.SetActive(false);
            GameManager.gameManager.CambiarFocusCanvas(false);
        }else{
            LimpiarTodosLosActive();
            calendario.SetActive(true);
        }
    }
}
