using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Textos : MonoBehaviour{

    private string[] _CAT_Text = {
        "Jugar", 
        "Instruccions", 
        "Sortir",
        "Versió"
    };

    private string[] _ESP_Text = {
        "Jugar", 
        "Instrucciones", 
        "Salir",
        "Version"
    };

    private string[] _ENG_Text = {
        "Play", 
        "Instructions", 
        "Exit",
        "Version"
    };


    public string[] GetText(string idioma){
        if(idioma == "CAT") { return _CAT_Text; }
        else if(idioma == "ESP") { return _ESP_Text; }
        else { return _ENG_Text; }
    }

}
