using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VerStats : MonoBehaviour{
    
    [SerializeField] Transform _Stats;
    
    private GameObject[] _ObjetosJuego = new GameObject[6];
    private string _Idioma;
    private string[] _Textos;

    private void Start() {
        GetTextosIdioma();
        CargarDatos();
        SetTextos();
    }

    private void GetTextosIdioma(){

        string[] _CAT_Text = {
            "Estadístiques d'aquesta partida:", 
            "| | |  Has aconseguit sobreviure econòmicament un total de: " + (((EstadoJuego.EdJ._Year - 1) * 12 * 28) + ((EstadoJuego.EdJ._Month - 1) * 28) + EstadoJuego.EdJ._Day).ToString() + " dies.",
            "| | |  Has recol·lectat un total de " + EstadoJuego.EdJ._Stats[0] + " vegetals.",
            "| | |  Has plantat " + EstadoJuego.EdJ._Stats[1] + " llavors.",
            "| | |  Has regat un total de " + EstadoJuego.EdJ._Stats[2] + " caselles.",
            "| | |  Has fet servir la paperera un total de " + EstadoJuego.EdJ._Stats[3] + " vegades."
        };

        string[] _ESP_Text = {
            "Estadísticas de esta partida:", 
            "| | |  Has conseguido sobrevivir económicamente un total de: " + (((EstadoJuego.EdJ._Year - 1) * 12 * 28) + ((EstadoJuego.EdJ._Month - 1) * 28) + EstadoJuego.EdJ._Day).ToString() + " días.",
            "| | |  Has recolectado un total de " + EstadoJuego.EdJ._Stats[0] + " vegetales.",
            "| | |  Has plantado " + EstadoJuego.EdJ._Stats[1] + " semillas.",
            "| | |  Has regado un total de " + EstadoJuego.EdJ._Stats[2] + " casillas.",
            "| | |  Has usado la papelera un total de " + EstadoJuego.EdJ._Stats[3] + " veces."
        };

        string[] _ENG_Text = {
            "Stats of this game:", 
            "| | |  You have managed to survive financially for a total of: " + (((EstadoJuego.EdJ._Year - 1) * 12 * 28) + ((EstadoJuego.EdJ._Month - 1) * 28) + EstadoJuego.EdJ._Day).ToString() + " days.",
            "| | |  You have collected a total of " + EstadoJuego.EdJ._Stats[0] + " vegetables.",
            "| | |  You have planted " + EstadoJuego.EdJ._Stats[1] + " seeds.",
            "| | |  You have watered a total of " + EstadoJuego.EdJ._Stats[2] + " tiles.",
            "| | |  You have trashed a total of " + EstadoJuego.EdJ._Stats[3] + " times."
        };

        _Idioma = EstadoJuego.EdJ.Lang;
        
        if(_Idioma == "CAT"){_Textos = _CAT_Text; }
        else if(_Idioma == "ESP"){_Textos = _ESP_Text; }
        else if(_Idioma == "ENG"){_Textos = _ENG_Text; }
    }

    private void CargarDatos(){       
        _ObjetosJuego[0] = _Stats.Find("Titulo").gameObject;
        _ObjetosJuego[1] = _Stats.Find("Textos").Find("Texto01").gameObject;
        _ObjetosJuego[2] = _Stats.Find("Textos").Find("Texto02").gameObject;
        _ObjetosJuego[3] = _Stats.Find("Textos").Find("Texto03").gameObject;
        _ObjetosJuego[4] = _Stats.Find("Textos").Find("Texto04").gameObject;
        _ObjetosJuego[5] = _Stats.Find("Textos").Find("Texto05").gameObject;
    }

    private void SetTextos(){
        for (int i = 0; i < _ObjetosJuego.Length; i++){
             _ObjetosJuego[i].GetComponentInChildren<Text>().text = _Textos[i];
        }
    }

    public string GetTexto(int numero){
        return _Textos[numero];
    }
}
