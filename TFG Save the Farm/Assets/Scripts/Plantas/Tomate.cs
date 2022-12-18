using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tomate : Cultivos{

    private void Start() {
         Inicializar();
    }

    public void Inicializar(){

        NombreClave = "Tomate";

        if(EstadoJuego.EdJ.Lang == "CAT"){
            Nombre = "Tomàquet";
        }else if(EstadoJuego.EdJ.Lang == "ESP"){
            Nombre = "Tomate";
        }else if(EstadoJuego.EdJ.Lang == "ENG"){
            Nombre = "Tomato";
        }

        Imagen = ImagenesManager.iMan.GetImagenesCosecha()[1];
        NumeroCultivo = 1;
        
        PuntosCrecimiento = 0;
        PuntosParaCosecha = 7;
    
        ProbabilidadSeguirRegada = 5;

        CantidadCosechaMin = 1; 
        CantidadCosechaMax = 2;    
        CosechaReiterativa = true;
        TiempoCosechaReiterativa = 4;

        CantidadSemillas = EstadoJuego.EdJ._Vegetales[0, 0];
        CantidadVegetal = EstadoJuego.EdJ._Vegetales[0, 1];
        PrecioSemillas = 1.0f;
        PrecioVenta = 3.0f;
        
        ActualizarTextoMenu01();
    }
}
