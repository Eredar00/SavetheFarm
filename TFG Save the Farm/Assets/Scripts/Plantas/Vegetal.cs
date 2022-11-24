using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Vegetal : MonoBehaviour, IPointerClickHandler{

    [SerializeField] private Sprite imagen;
    [SerializeField] private int cantidadSemillas = 0;
    [SerializeField] private int cantidadVegetal = 0;
    [SerializeField] private string nombreVegetal;
    [SerializeField] private float porcentageDesaparicion = 0.0f;
    [SerializeField] private int precioSemillas = 1;
    [SerializeField] private int precioVenta = 5;

    public Sprite getImagen(){return imagen;}
    public string getNombreVegetal(){return nombreVegetal;}
    public int getCantidadSemillas(){return cantidadSemillas;} 
    public int getCantidadVegetal(){return cantidadVegetal;}
    public int getPrecioVenta(){return precioVenta;}
    public int getPrecioSemillas(){return precioSemillas;}

    public void VariarCantidadSemillas(int numero){
        cantidadSemillas = cantidadSemillas + numero;
        ControlBotones.controlBotones.getTiendaHortalizas().GetComponent<Tienda_Hortalizas>().ActualizarTextoMenu01();
    }

    public void VariarCantidadVegetal(int numero){
        cantidadVegetal = cantidadVegetal + numero;
        ControlBotones.controlBotones.getTiendaHortalizas().GetComponent<Tienda_Hortalizas>().ActualizarTextoMenu01();
    }


    public void OnPointerClick(PointerEventData eventData){
        ControlBotones.controlBotones.getTiendaHortalizas().GetComponent<Tienda_Hortalizas>().ActualizarTextoMenu02(this);
    }
}
