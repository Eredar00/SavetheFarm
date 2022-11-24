using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tienda_Hortalizas : MonoBehaviour
{
    [SerializeField] private GameObject Menu01;
    [SerializeField] private GameObject Menu02;
    [SerializeField] private Component[] tiposVegetales;

    private int precioSemillas, precioVegetal;
    private Vegetal hortaliza;

    private void Start() {
        ActualizarTextoMenu01();
    }

    private void CambiarActives(GameObject activar, GameObject desactivar){
        activar.SetActive(true);
        desactivar.SetActive(false);
    }

    public void ActualizarTextoMenu01(){
        tiposVegetales = Menu01.transform.Find("Casillero").GetComponentsInChildren<Vegetal>();

        foreach (Vegetal tipos in tiposVegetales){
            tipos.transform.Find("Sprite").GetComponent<Image>().sprite = tipos.getImagen();
            tipos.transform.Find("Semillas").GetComponent<Text>().text = tipos.getCantidadSemillas().ToString();
            tipos.transform.Find("Cantidad").GetComponent<Text>().text = tipos.getCantidadVegetal().ToString();
            tipos.transform.Find("Nombre").GetComponent<Text>().text = tipos.getNombreVegetal();
        }
    }
    
    public void ActualizarTextoMenu02(Vegetal vegetal){
        Menu02.transform.Find("Hortaliza").Find("Imagen Hortaliza").Find("Sprite").GetComponent<Image>().sprite = vegetal.getImagen();
        Menu02.transform.Find("Hortaliza").Find("Titulo Hortaliza").GetComponent<Text>().text = vegetal.getNombreVegetal();
        Menu02.transform.Find("Hortaliza").Find("Cantidad").GetComponent<Text>().text = "Tienes: " + vegetal.getCantidadVegetal();
        Menu02.transform.Find("Hortaliza").Find("Precio Venta").GetComponent<Text>().text = "Precio unidad:" + vegetal.getPrecioVenta() + " $";

        Menu02.transform.Find("Semilla").Find("Titulo Semilla").GetComponent<Text>().text = "SEMILLAS DE " + vegetal.getNombreVegetal();
        Menu02.transform.Find("Semilla").Find("Cantidad Semillas").GetComponent<Text>().text = "Tienes: " + vegetal.getCantidadSemillas();
        Menu02.transform.Find("Semilla").Find("Precio Semillas").GetComponent<Text>().text = "Precio unidad:" + vegetal.getPrecioSemillas() + " $";

        precioSemillas = vegetal.getPrecioSemillas();
        precioVegetal = vegetal.getPrecioVenta();
        hortaliza = vegetal;

        CambiarActives(Menu02, Menu01);
    }

    public void ComprarSemillas(int cantidad){
        if(Dinero.dinero.ObtenerDinero() >= cantidad * hortaliza.getPrecioSemillas()){
            Dinero.dinero.VariarDinero(-(cantidad * hortaliza.getPrecioSemillas()));
            hortaliza.VariarCantidadSemillas(cantidad);
            Menu02.transform.Find("Semilla").Find("Cantidad Semillas").GetComponent<Text>().text = "Tienes: " + hortaliza.getCantidadSemillas();
        }
    }

    public void VenderHortalizas(int cantidad){
        if(hortaliza.getCantidadVegetal() >= cantidad){
            Dinero.dinero.VariarDinero((cantidad * hortaliza.getPrecioVenta()));
            hortaliza.VariarCantidadVegetal(-cantidad);
            Menu02.transform.Find("Hortaliza").Find("Cantidad").GetComponent<Text>().text = "Tienes: " + hortaliza.getCantidadVegetal();
        }
    }
}
