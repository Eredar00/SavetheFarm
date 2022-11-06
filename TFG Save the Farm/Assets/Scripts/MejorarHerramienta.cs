using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MejorarHerramienta : MonoBehaviour, IPointerExitHandler, IPointerEnterHandler
{   
    private Image imagenBoton;

    private void Start() {
        imagenBoton = GetComponent<Image>();
    }
    
    public void MejorarHerramientaSeleccionada(){
        if(Dinero.dinero.ObtenerDinero() >= 20){
            if(Acciones.acciones.ObtenerConjuntoAcciones()[Acciones.acciones.ObtenerValorAccionActual()-1].GetComponent<Accion>().ObtenerNivel() <= 2){
                Acciones.acciones.ObtenerConjuntoAcciones()[Acciones.acciones.ObtenerValorAccionActual()-1].GetComponent<Accion>().SubirNivel();
                Acciones.acciones.ObtenerConjuntoAcciones()[Acciones.acciones.ObtenerValorAccionActual()-1].GetComponent<Accion>().VariarCosteEnergia(-2);
                Dinero.dinero.VariarDinero(-20);
                RevisarColorBoton();
            }
        }
    }

    public void OnPointerEnter(PointerEventData eventData){
        RevisarColorBoton();
    }

    public void OnPointerExit(PointerEventData eventData){
        imagenBoton.color = new Color(255,255,255,255);
    }

    private void RevisarColorBoton(){
        if((Dinero.dinero.ObtenerDinero() >= 20) && (Acciones.acciones.ObtenerConjuntoAcciones()[Acciones.acciones.ObtenerValorAccionActual()-1].GetComponent<Accion>().ObtenerNivel() <= 2)){
            imagenBoton.color = new Color(0,255,0,255);
        }else{
            imagenBoton.color = new Color(255,0,0,255);
        }
    }
}
