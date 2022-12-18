using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.SceneManagement;

public class EstadoJuego : MonoBehaviour{

    public static EstadoJuego EdJ;
    private string _RutaArchivo;
    
    public string _Lang = "ESP";
    public string _Version = "v.0.4.0";
    
    public string _FinalJuego;
    public float _Dinero;
    public int _Dia;
    public int _PuntosEnergia;
    public int[,] _Herramientas;
    public int[,] _Vegetales;
    public bool[] _Bloques;
    public int[,] _Casillero;
    

    public string Lang { get => _Lang; set => _Lang = value; }
    public string Version { get => _Version; set => _Version = value; }
    public string FinalJuego { get => _FinalJuego; set => _FinalJuego = value; }

    private void Awake(){
        _RutaArchivo = Application.persistentDataPath + "/datos.dat";
        if (EdJ == null){
            EdJ = this;
            DontDestroyOnLoad(gameObject);
        }else if(EdJ != this){
            Destroy(gameObject);
        }
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Z)) Debug.Log(_Casillero[1,0]);
    }

    public void Nuevo_Juego(){
        _FinalJuego = "";
        _Dinero = 20.0f;
        _PuntosEnergia = 100;
        _Dia = 1;
        _Herramientas = new int[6, 2] { { 1, 1 }, { 1, 1 }, { 1, 1 }, { 1, 1 }, { 1, 1 }, { 1, 1 } };
        _Vegetales = new int[6, 2] { { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 } };
        _Bloques = null;
        _Casillero = null;

        SceneManager.LoadScene("Juego");
    }

    public void Guardar(){
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(_RutaArchivo);
        DatosAGuardar datos = new DatosAGuardar(_FinalJuego, _Dinero, _Dia, _Herramientas, _Vegetales, _PuntosEnergia, _Bloques, _Casillero);
        
        bf.Serialize(file, datos);
        file.Close();
    }

    public void Cargar(){
        if (File.Exists(_RutaArchivo)){

            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(_RutaArchivo, FileMode.Open);
            DatosAGuardar datos = (DatosAGuardar)bf.Deserialize(file);
            
            _FinalJuego = datos.FinalJuego;
            _Dinero = datos.Dinero;
            _Dia = datos.Dia;
            _Herramientas = datos.Herramientas;
            _Vegetales = datos.Vegetales;
            _PuntosEnergia = datos.PuntosEnergia;
            _Bloques = datos.Bloques;
            _Casillero = datos.Casillero;
            

            file.Close();
            if(_FinalJuego != ""){
                SceneManager.LoadScene("Final del Juego");
            }else{
                SceneManager.LoadScene("Juego");
            }
        }
        else{
            Nuevo_Juego();
        }
    }

    public void Instrucciones(){
        SceneManager.LoadScene("Instrucciones");
    }

    public void Idioma(){
        SceneManager.LoadScene("Idioma");
    }

    [Serializable]
    class DatosAGuardar{
        public string FinalJuego;
        public float Dinero;
        public int Dia;
        public int PuntosEnergia;
        public int[,] Herramientas;
        public int[,] Vegetales;
        public bool[] Bloques;
        public int[,] Casillero;

        public DatosAGuardar(string finalJuego, float dinero, int dia, int[,] herramientas, int[,] vegetales, int puntosEnergia, bool[] bloques, int[,] casillero){
            this.FinalJuego = finalJuego;
            this.Dinero = dinero;
            this.Dia = dia;
            this.Herramientas = herramientas;
            this.Vegetales = vegetales;
            this.PuntosEnergia = puntosEnergia;
            this.Bloques = bloques;
            this.Casillero = casillero;
        }
    }
}