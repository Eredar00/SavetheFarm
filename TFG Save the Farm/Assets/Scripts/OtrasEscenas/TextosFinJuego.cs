using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextosFinJuego : MonoBehaviour{
    
    private string[] _CAT_Boton = {
        "Portada",
        "Crèdits",
        "Sortir"
    };

    private string[] _ESP_Boton = {
        "Portada",
        "Créditos",
        "Salir"
    };

    private string[] _ENG_Boton = {
        "Home page",
        "Credits",
        "Exit"
    };

    
    private GameObject[] _BotonesJuego = new GameObject[4];
    private string _Idioma;
    private string[] _Botones;

    private void Start() {
        GetTextosIdioma();
        CargarDatos();
        SetTextos();
    }

    private void GetTextosIdioma(){
        _Idioma = EstadoJuego.EdJ.Lang;
        if(_Idioma == "CAT"){ _Botones = _CAT_Boton;}
        else if(_Idioma == "ESP"){_Botones = _ESP_Boton;}
        else if(_Idioma == "ENG"){_Botones = _ENG_Boton;}
    }

    private void CargarDatos(){
        _BotonesJuego[0] = transform.Find("Portada").gameObject;
        _BotonesJuego[1] = transform.Find("Creditos").gameObject;
        _BotonesJuego[2] = transform.Find("Salir").gameObject;
    }

    private void SetTextos(){
        for (int i = 0; i < _BotonesJuego.Length; i++){
             _BotonesJuego[i].GetComponentInChildren<Text>().text = _Botones[i];
        }
    }

    public string GetTexto(int numero){
        return _Botones[numero];
    }
}
