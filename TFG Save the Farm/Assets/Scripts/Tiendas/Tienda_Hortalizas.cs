using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tienda_Hortalizas : MonoBehaviour{
    
    [SerializeField] private GameObject Menu01;
    [SerializeField] private GameObject Menu02;

    private float precioSemillas, precioVegetal;
    private Cultivos cultivo;

    private void CambiarActives(GameObject activar, GameObject desactivar){
        activar.SetActive(true);
        desactivar.SetActive(false);
    }
    
    public void ActualizarTextoMenu02(Cultivos vegetal){
        Transform go_Hortaliza, go_Semilla, go_Caracteristicas;
        go_Hortaliza = Menu02.transform.Find("Hortaliza");
        go_Semilla = Menu02.transform.Find("Semilla");
        go_Caracteristicas =  Menu02.transform.Find("Caracteristicas").Find("Textos");

        go_Hortaliza.Find("Imagen Hortaliza").Find("Sprite").GetComponent<Image>().sprite = vegetal.Imagen;
        go_Hortaliza.Find("Titulo Hortaliza").GetComponent<Text>().text = vegetal.Nombre.ToUpper();
        go_Hortaliza.Find("Cantidad").GetComponent<Text>().text = "Tienes: " + vegetal.CantidadVegetal;
        go_Hortaliza.Find("Precio Venta").GetComponent<Text>().text = "Precio unidad:" + vegetal.PrecioVenta + " $";

        go_Semilla.Find("Titulo Semilla").GetComponent<Text>().text = "SEMILLAS DE " + vegetal.Nombre.ToUpper();
        go_Semilla.Find("Cantidad Semillas").GetComponent<Text>().text = "Tienes: " + vegetal.CantidadSemillas;
        go_Semilla.Find("Precio Semillas").GetComponent<Text>().text = "Precio unidad:" + vegetal.PrecioSemillas + " $";

        go_Caracteristicas.Find("Agua").GetComponent<Text>().text = "# Porcentaje de seguir regado al siguiente día: " + vegetal.ProbabilidadSeguirRegada + "%";
        go_Caracteristicas.Find("Crecimiento").GetComponent<Text>().text = "# Días de crecimiento: " + vegetal.PuntosParaCosecha;
        go_Caracteristicas.Find("Cantidad").GetComponent<Text>().text = "# Vegetales por cosecha: mín: " + vegetal.CantidadCosechaMin + " | máx: " + vegetal.CantidadCosechaMax;
        if(vegetal.CosechaReiterativa){
            go_Caracteristicas.Find("Reiterativa").GetComponent<Text>().text = "# Una vez ha crecido, da cosecha cada " + vegetal.TiempoCosechaReiterativa + " días";
        }else{
            go_Caracteristicas.Find("Reiterativa").GetComponent<Text>().text = "# Una vez ha crecido, NO vuelve a dar cosecha";
        }
        
        precioSemillas = vegetal.PrecioSemillas;
        precioVegetal = vegetal.PrecioVenta;
        cultivo = vegetal;

        CambiarActives(Menu02, Menu01);
    }

    public void ComprarSemillas(int cantidad){
        if(Dinero.dinero.ObtenerDinero() >= cantidad * cultivo.PrecioSemillas){
            Dinero.dinero.VariarDinero(-(cantidad * cultivo.PrecioSemillas));
            cultivo.CantidadSemillas = cultivo.CantidadSemillas + cantidad;
            Menu02.transform.Find("Semilla").Find("Cantidad Semillas").GetComponent<Text>().text = "Tienes: " + cultivo.CantidadSemillas;
            cultivo.ActualizarTextoMenu01();
        }
    }

    public void VenderHortalizas(int cantidad){
        if(cultivo.CantidadVegetal >= cantidad){
            Dinero.dinero.VariarDinero(cantidad * cultivo.PrecioVenta);
            cultivo.CantidadVegetal = cultivo.CantidadVegetal - cantidad;
            Menu02.transform.Find("Hortaliza").Find("Cantidad").GetComponent<Text>().text = "Tienes: " + cultivo.CantidadVegetal;
            cultivo.ActualizarTextoMenu01();
        }else{
            Dinero.dinero.VariarDinero(cultivo.CantidadVegetal * cultivo.PrecioVenta);
            cultivo.CantidadVegetal = 0;
            Menu02.transform.Find("Hortaliza").Find("Cantidad").GetComponent<Text>().text = "Tienes: " + cultivo.CantidadVegetal;
            cultivo.ActualizarTextoMenu01();
        }
    }
}
