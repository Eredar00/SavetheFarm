using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dinero : MonoBehaviour
{
    public static Dinero dinero;

    [SerializeField] private float cantidad;
    [SerializeField] private GameObject DineroCanvas;

    private void Awake() {
        dinero = this;
    }

    private void Start() {
        cantidad = 50f;
        ActualizarTextoDinero();
    }

    public float ObtenerDinero(){
        return cantidad;
    }

    public void VariarDinero(float variacion){
        cantidad = cantidad + variacion;
        ActualizarTextoDinero();
    }

    public void ActualizarTextoDinero(){
        DineroCanvas.GetComponentInChildren<Text>().text = cantidad.ToString() + " $";
    } 
}
