using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortadaManager : MonoBehaviour{

    private String _RutaArchivo;
    public GameObject _Continuar;

    private void Awake(){
        
        _RutaArchivo = Application.persistentDataPath + "/datos.dat";

        if (File.Exists(_RutaArchivo)){
            _Continuar.SetActive(true);
        }else{
            _Continuar.SetActive(false);
        }
    }

    public void Nuevo_Juego(){
        EstadoJuego.EdJ.Nuevo_Juego();
    }

    public void Cargar(){
        EstadoJuego.EdJ.Cargar();
    }

    public void Instrucciones(){
        EstadoJuego.EdJ.Instrucciones();
    }

    public void Idioma(){
        EstadoJuego.EdJ.Idioma();
    }

    public void Salir(){
        Application.Quit();
    }
}
