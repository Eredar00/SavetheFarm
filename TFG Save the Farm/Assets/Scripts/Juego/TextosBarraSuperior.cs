using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextosBarraSuperior : MonoBehaviour{
    
    private string[] _CAT_Text = {
        "No tens suficients llavors d'aquest tipus.",
        "Has recollit ",
        " unitat/s"
    };

    private string[] _ESP_Text = {
        "No tienes suficientes semillas de ese tipo.",
        "Has cosechado ",
        " unidad/es"
    };

    private string[] _ENG_Text = {
        "You do not have enough seeds of this vegetable.",
        "You have collected ",
        " unit/s"
    };
    
    GameObject[] _ObjetosJuego = new GameObject[3];
    private string _Idioma;
    private string[] _Textos;
    
    private void Start() {
        GetTextosIdioma();
    }

    private void GetTextosIdioma(){
        _Idioma = EstadoJuego.EdJ.Lang;
        if(_Idioma == "CAT"){_Textos = _CAT_Text;}
        else if(_Idioma == "ESP"){_Textos = _ESP_Text;}
        else if(_Idioma == "ENG"){_Textos = _ENG_Text;}
    }

    public string GetTexto(int numero){
        return _Textos[numero];
    }
}
