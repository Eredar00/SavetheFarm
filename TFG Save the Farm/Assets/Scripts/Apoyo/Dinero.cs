using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dinero : MonoBehaviour{

    public static Dinero dinero;

    [SerializeField] private GameObject DineroCanvas;

    private void Awake() {
        dinero = this;
    }

    private void Start() {
        ActualizarTextoDinero();
    }

    public float ObtenerDinero(){
        return EstadoJuego.EdJ._Dinero;
    }

    public void VariarDinero(float variacion){
        EstadoJuego.EdJ._Dinero = EstadoJuego.EdJ._Dinero + variacion;
        ActualizarTextoDinero();
    }

    public void ActualizarTextoDinero(){
        DineroCanvas.GetComponentInChildren<Text>().text = EstadoJuego.EdJ._Dinero.ToString() + " $";
    } 
}
