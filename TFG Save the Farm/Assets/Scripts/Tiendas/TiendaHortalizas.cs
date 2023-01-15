using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TiendaHortalizas : MonoBehaviour{
    
    [SerializeField] private GameObject Menu01;
    [SerializeField] private GameObject Menu02;

    private float precioSemillas, precioVegetal;
    private Cultivos cultivo;
    private string[] _Textos;

    private string[] _CAT_Text = {
        "Tens: ",
        "Preu unitat: ",
        "LLAVORS DE ",
        "# Percentatge de seguir regat al següent dia: ",
        "# Dies de creixement: ",
        "# Vegetals per collita: mín: ",
        " | màx: ",
        "# Un cop ha crescut, dóna collita cada ",
        " dies",
        "# Un cop ha crescut, NO torna a donar collita"
    };

    private string[] _ESP_Text = {
        "Tienes: ",
        "Precio unidad: ",
        "SEMILLAS DE ",
        "# Porcentaje de seguir regado al siguiente día: ",
        "# Días de crecimiento: ",
        "# Vegetales por cosecha: mín: ",
        " | máx: ",
        "# Una vez ha crecido, da cosecha cada ",
        " días",
        "# Una vez ha crecido, NO vuelve a dar cosecha"
    };

    private string[] _ENG_Text = {
        "You have: ",
        "Unit price: ",
        " SEEDS",
        "# Percentage still irrigated the next day: ",
        "# Grow days: ",
        "# Vegetables per crop: min: ",
        " | max: ",
        "# Once it has grown, it can be harvested every ",
        " days",
        "# Once it has grown, it can NOT be harvested again"
    };

    private void Awake() {
         GetTextosIdioma();
    }

    private void GetTextosIdioma(){
        if(EstadoJuego.EdJ.Lang == "CAT"){_Textos = _CAT_Text;}
        else if(EstadoJuego.EdJ.Lang == "ESP"){_Textos = _ESP_Text;}
        else if(EstadoJuego.EdJ.Lang == "ENG"){_Textos = _ENG_Text;}
    }

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
        go_Hortaliza.Find("Cantidad").GetComponent<Text>().text = _Textos[0] + vegetal.CantidadVegetal;
        go_Hortaliza.Find("Precio Venta").GetComponent<Text>().text = _Textos[1] + vegetal.PrecioVenta + " $";

        if(EstadoJuego.EdJ.Lang == "ENG"){
            go_Semilla.Find("Titulo Semilla").GetComponent<Text>().text = vegetal.Nombre.ToUpper() + _Textos[2];
        }else{
            go_Semilla.Find("Titulo Semilla").GetComponent<Text>().text = _Textos[2] + vegetal.Nombre.ToUpper();
        }
        
        go_Semilla.Find("Cantidad Semillas").GetComponent<Text>().text = _Textos[0] + vegetal.CantidadSemillas;
        go_Semilla.Find("Precio Semillas").GetComponent<Text>().text = _Textos[1] + vegetal.PrecioSemillas + " $";

        go_Caracteristicas.Find("Agua").GetComponent<Text>().text = _Textos[3] + vegetal.ProbabilidadSeguirRegada + "%";
        go_Caracteristicas.Find("Crecimiento").GetComponent<Text>().text = _Textos[4] + vegetal.PuntosParaCosecha;
        go_Caracteristicas.Find("Cantidad").GetComponent<Text>().text = _Textos[5] + vegetal.CantidadCosechaMin + _Textos[6] + vegetal.CantidadCosechaMax;
        if(vegetal.CosechaReiterativa){
            go_Caracteristicas.Find("Reiterativa").GetComponent<Text>().text = _Textos[7] + vegetal.TiempoCosechaReiterativa + _Textos[8];
        }else{
            go_Caracteristicas.Find("Reiterativa").GetComponent<Text>().text = _Textos[9];
        }
        
        precioSemillas = vegetal.PrecioSemillas;
        precioVegetal = vegetal.PrecioVenta;
        cultivo = vegetal;

        CambiarActives(Menu02, Menu01);
    }

    public void ComprarSemillas(int cantidad){
        if(Dinero.dinero.ObtenerDinero() >= cantidad * cultivo.PrecioSemillas){
            Dinero.dinero.VariarDinero(-(cantidad * cultivo.PrecioSemillas));

            cultivo.ComprarSemillas(cantidad);

            Menu02.transform.Find("Semilla").Find("Cantidad Semillas").GetComponent<Text>().text = _Textos[0] + cultivo.CantidadSemillas;

            cultivo.ActualizarTextoMenu01();
            Semillas.semillas.ActualizarTextoNumero();
        }
    }

    public void VenderHortalizas(int cantidad){
        if(cultivo.CantidadVegetal >= cantidad){
            Dinero.dinero.VariarDinero(cantidad * cultivo.PrecioVenta);
            cultivo.VenderVegetal(cantidad);
            Menu02.transform.Find("Hortaliza").Find("Cantidad").GetComponent<Text>().text = _Textos[0] + cultivo.CantidadVegetal;
            cultivo.ActualizarTextoMenu01();
        }else{
            Dinero.dinero.VariarDinero(cultivo.CantidadVegetal * cultivo.PrecioVenta);
            cultivo.VenderVegetal(cultivo.CantidadVegetal);
            Menu02.transform.Find("Hortaliza").Find("Cantidad").GetComponent<Text>().text = "Tienes: " + cultivo.CantidadVegetal;
            cultivo.ActualizarTextoMenu01();
        }
    }
}
