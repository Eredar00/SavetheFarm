using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextosJuego : MonoBehaviour{
    
    private string[] _CAT_Text = {
        "Següent dia", 
        "Dia",
        "CALENDARI",
        "BOTIGA D'EINES",
        "VERDURES",
        "VENDRE",
        "COMPRAR LLAVORS",
        "Carascterístiques"
    };

    private string[] _ESP_Text = {
        "Siguiente día", 
        "Día",
        "CALENDARIO",
        "TIENDA DE HERRAMIENTAS",
        "HORTALIZAS",
        "VENDER",
        "COMPRAR SEMILLAS",
        "Cararcterísticas"
    };

    private string[] _ENG_Text = {
        "Next day", 
        "Day",
        "CALENDAR",
        "TOOLS STORE",
        "VEGETABLES",
        "SELL",
        "BUY SEEDS",
        "Features"
    };
    
    GameObject[] _ObjetosJuego = new GameObject[8];
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
        _ObjetosJuego[0] = transform.Find("Siguiente Dia").gameObject;
        _ObjetosJuego[1] = transform.Find("Dia").gameObject;
        _ObjetosJuego[2] = transform.Find("Calendario").Find("Mes").Find("Titulo").gameObject;
        _ObjetosJuego[3] = transform.Find("Tiendas").Find("Tienda Herramientas").Find("Titulo").gameObject;
        _ObjetosJuego[4] = transform.Find("Tiendas").Find("Tienda Hortalizas").Find("Titulo").gameObject;
        _ObjetosJuego[5] = transform.Find("Tiendas").Find("Tienda Hortalizas").Find("Menu 02").Find("Hortaliza").Find("Vender").gameObject;
        _ObjetosJuego[6] = transform.Find("Tiendas").Find("Tienda Hortalizas").Find("Menu 02").Find("Semilla").Find("Comprar").gameObject;
        _ObjetosJuego[7] = transform.Find("Tiendas").Find("Tienda Hortalizas").Find("Menu 02").Find("Caracteristicas").Find("Titulo Caracteristicas").gameObject;
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
