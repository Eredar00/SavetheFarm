using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CargarTextos : MonoBehaviour{
    
    [SerializeField] GameObject[] objetos;
    private string lang;
    private string[] langText;
    

    private void Start() {
        lang = Opciones.opciones.Idioma;
        langText = Opciones.opciones.Prr.GetText(lang);

        objetos[0].GetComponentInChildren<Text>().text = langText[0];
    }
}
