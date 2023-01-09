using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextosPortada : MonoBehaviour{
    
    private string[] _CAT_Text = {
        "Nou joc", 
        "Instruccions", 
        "Sortir",
        "Versió",
        "Continuar partida",
        "Idioma"
    };

    private string[] _ESP_Text = {
        "Juego nuevo", 
        "Instrucciones", 
        "Salir",
        "Version",
        "Continuar partida",
        "Idioma"
    };

    private string[] _ENG_Text = {
        "New game", 
        "Instructions", 
        "Exit",
        "Version",
        "Continue game",
        "Language"
    };
    
    GameObject[] _ObjetosJuego = new GameObject[6];
    private string _Idioma;
    private string[] _Textos;
    
    private void Start() {
        GetTextosIdioma();
        CargarDatos();
        _Textos[3] = _Textos[3] + " " + EstadoJuego.EdJ.Version;
        SetTextos();
    }

    private void GetTextosIdioma(){
        _Idioma = EstadoJuego.EdJ.Lang;
        if(_Idioma == "CAT"){_Textos = _CAT_Text;}
        else if(_Idioma == "ESP"){_Textos = _ESP_Text;}
        else if(_Idioma == "ENG"){_Textos = _ENG_Text;}
    }

    private void CargarDatos(){
        _ObjetosJuego[0] = transform.Find("Menus").Find("Nuevo Juego").gameObject;
        _ObjetosJuego[1] = transform.Find("Menus").Find("Instrucciones").gameObject;
        _ObjetosJuego[2] = transform.Find("Menus").Find("Salir").gameObject;
        _ObjetosJuego[3] = transform.Find("Version").gameObject;
        _ObjetosJuego[4] = transform.Find("Menus").Find("Continuar").gameObject;
        _ObjetosJuego[5] = transform.Find("Menus").Find("Idioma").gameObject;
    }

    private void SetTextos(){
        for (int i = 0; i < _ObjetosJuego.Length; i++){
             _ObjetosJuego[i].GetComponentInChildren<Text>().text = _Textos[i];
        }
    }
}
