using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextosJuego : MonoBehaviour{
    
    private string[] _CAT_Text = {
        "SEGÜENT DIA", 
        "Dia",
        "Mes",
        "Any",
        "BOTIGA D'EINES",
        "VERDURES",
        "VENDRE",
        "COMPRAR LLAVORS",
        "Característiques",
        "CALENDARI",
        "BOTIGA D'EINES",
        "BOTIGA DE VERDURES",
        "Sense missatges...",
        "DINERS"
    };

    private string[] _ESP_Text = {
        "SIGUIENTE DÍA", 
        "Día",
        "Mes",
        "Año",
        "TIENDA DE HERRAMIENTAS",
        "HORTALIZAS",
        "VENDER",
        "COMPRAR SEMILLAS",
        "Características",
        "CALENDARIO",
        "TIENDA DE HERRAMIENTAS",
        "TIENDA DE HORTALIZAS",
        "Sin mensajes...",
        "DINERO"
    };

    private string[] _ENG_Text = {
        "NEXT DAY", 
        "Day",
        "Month",
        "Year",
        "TOOL STORE",
        "VEGETABLES",
        "SELL",
        "BUY SEEDS",
        "Features",
        "CALENDAR",
        "TOOL STORE",
        "VEGETABLE STORE",
        "No messages yet...",
        "MONEY"
    };
    
    GameObject[] _ObjetosJuego = new GameObject[14];
    private string _Idioma;
    private string[] _Textos;
    
    private void Start() {
        GetTextosIdioma();
        CargarDatos();
        CargarTextos();
    }

    private void GetTextosIdioma(){
        _Idioma = EstadoJuego.EdJ.Lang;
        if(_Idioma == "CAT"){_Textos = _CAT_Text;}
        else if(_Idioma == "ESP"){_Textos = _ESP_Text;}
        else if(_Idioma == "ENG"){_Textos = _ENG_Text;}
    }

    private void CargarDatos(){
        _ObjetosJuego[0] = transform.Find("BotonesInfDer").Find("Siguiente Dia").gameObject;
        _ObjetosJuego[1] = transform.Find("BotonesSupDer").Find("Fecha").Find("Day").gameObject;
        _ObjetosJuego[2] = transform.Find("BotonesSupDer").Find("Fecha").Find("Month").gameObject;
        _ObjetosJuego[3] = transform.Find("BotonesSupDer").Find("Fecha").Find("Year").gameObject;
        _ObjetosJuego[4] = transform.Find("Tiendas").Find("Tienda Herramientas").Find("Titulo").gameObject;
        _ObjetosJuego[5] = transform.Find("Tiendas").Find("Tienda Hortalizas").Find("Titulo").gameObject;
        _ObjetosJuego[6] = transform.Find("Tiendas").Find("Tienda Hortalizas").Find("Menu 02").Find("Hortaliza").Find("Vender").gameObject;
        _ObjetosJuego[7] = transform.Find("Tiendas").Find("Tienda Hortalizas").Find("Menu 02").Find("Semilla").Find("Comprar").gameObject;
        _ObjetosJuego[8] = transform.Find("Tiendas").Find("Tienda Hortalizas").Find("Menu 02").Find("Caracteristicas").Find("Titulo Caracteristicas").gameObject;
        _ObjetosJuego[9] = transform.Find("BotonesSupDer").Find("Calendario").gameObject;
        _ObjetosJuego[10] = transform.Find("BotonesInfDer").Find("TiendaHerramientas").gameObject;
        _ObjetosJuego[11] = transform.Find("BotonesInfDer").Find("TiendaVerduras").gameObject;
        _ObjetosJuego[12] = transform.Find("BotonesSupCen").Find("Texto").gameObject;
        _ObjetosJuego[13] = transform.Find("MenuDinero").Find("Titulo").Find("Texto").gameObject;
    }

    private void CargarTextos(){
        for (int i = 0; i < _ObjetosJuego.Length; i++){
             _ObjetosJuego[i].GetComponentInChildren<Text>().text = _Textos[i];
        }
    }

    public string GetTexto(int numero){
        return _Textos[numero];
    }
}
