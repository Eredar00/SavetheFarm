using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextosCreditos : MonoBehaviour{
    
    private string[] _CAT_Text = {
        "Crèdits", 
        "PROGRAMADOR, DISSENYADOR y DIRECTOR \n \n Marc Martínez Egea \n \n \n \n \n LLICÈNCIA \n Reconeixement-NoComercial-SenseObraDerivada \n 3.0 Espanya (CC BY-NC-ND 3.0 ES)",
        "Portada",
        "Sortir"
    };

    private string[] _ESP_Text = {
        "Créditos", 
        "PROGRAMADOR, DISEÑADOR y DIRECTOR \n \n Marc Martínez Egea \n \n \n \n \n LICENCIA \n Reconocimiento-NoComercial-SinObraDerivada \n 3.0 España (CC BY-NC-ND 3.0 ES)",
        "Portada",
        "Salir"
    };

    private string[] _ENG_Text = {
        "Credits", 
        "PROGRAMMER, DESIGNER and DIRECTOR \n \n Marc Martínez Egea \n \n \n \n \n LICENSE \n Acknowledgment-NonCommercial-NoDerivative Work \n 3.0 SPAIN (CC BY-NC-ND 3.0 ES)",
        "Home page",
        "Exit"
    };
    
    GameObject[] _ObjetosJuego = new GameObject[4];
    private string _Idioma;
    private string[] _Textos;
    
    private void Start() {
        GetTextosIdioma();
        CargarDatos();
        SetTextos();
    }

    private void GetTextosIdioma(){
        _Idioma = EstadoJuego.EdJ.Lang;
        if(_Idioma == "CAT"){_Textos = _CAT_Text;}
        else if(_Idioma == "ESP"){_Textos = _ESP_Text;}
        else if(_Idioma == "ENG"){_Textos = _ENG_Text;}
    }

    private void CargarDatos(){
        _ObjetosJuego[0] = transform.Find("Titulo").gameObject;
        _ObjetosJuego[1] = transform.Find("Texto").gameObject;
        _ObjetosJuego[2] = transform.Find("Portada").gameObject;
        _ObjetosJuego[3] = transform.Find("Salir").gameObject;
    }

    private void SetTextos(){
        for (int i = 0; i < _ObjetosJuego.Length; i++){
             _ObjetosJuego[i].GetComponentInChildren<Text>().text = _Textos[i];
        }
    }
}
