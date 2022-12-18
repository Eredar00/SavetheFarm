using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextosFinJuego : MonoBehaviour{
    
    private string[] _CAT_Text = {
        "Felicitats!", 
        "Has aconseguit sobreviure econòmicament aquests 28 dies. Enhorabona! Properament una nova versió, amb més material, estarà disponible.", 
        "Portada",
        "Crèdits",
        "Sortir"
    };

    private string[] _ESP_Text = {
        "¡Felicidades!", 
        "Has conseguido sobrevivir económicamente estos 28 dias. ¡Enhorabuena! Próximamente una nueva versión, con más material, estará disponible.", 
        "Portada",
        "Créditos",
        "Salir"
    };

    private string[] _ENG_Text = {
        "Congratulations", 
        "You have managed to survive financially these 28 days. !! Congratulations!! Soon a new version, with more material, will be available.", 
        "Home page",
        "Credits",
        "Exit"
    };
    
    private GameObject[] _ObjetosJuego = new GameObject[5];
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
        _ObjetosJuego[0] = transform.Find("Ganador").Find("Titulo").gameObject;
        _ObjetosJuego[1] = transform.Find("Ganador").Find("Texto").gameObject;
        _ObjetosJuego[2] = transform.Find("Portada").gameObject;
        _ObjetosJuego[3] = transform.Find("Creditos").gameObject;
        _ObjetosJuego[4] = transform.Find("Salir").gameObject;
    }

    private void SetTextos(){
        for (int i = 0; i < _ObjetosJuego.Length; i++){
             _ObjetosJuego[i].GetComponentInChildren<Text>().text = _Textos[i];
        }
    }
}
