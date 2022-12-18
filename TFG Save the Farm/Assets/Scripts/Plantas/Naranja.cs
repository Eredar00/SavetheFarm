using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Naranja : Cultivos{

    private void Start() {
         Inicializar();
    }

    
    public void Inicializar(){
        
        NombreClave = "Naranja";

        if(EstadoJuego.EdJ.Lang == "CAT"){
            Nombre = "Taronja";
        }else if(EstadoJuego.EdJ.Lang == "ESP"){
            Nombre = "Naranja";
        }else if(EstadoJuego.EdJ.Lang == "ENG"){
            Nombre = "Orange";
        }
        
        Imagen = ImagenesManager.iMan.GetImagenesCosecha()[4];
        NumeroCultivo = 4;
        
        PuntosCrecimiento = 0;
        PuntosParaCosecha = 8;
    
        ProbabilidadSeguirRegada = 20;

        CantidadCosechaMin = 0; 
        CantidadCosechaMax = 1;    
        CosechaReiterativa = true;
        TiempoCosechaReiterativa = 4;

        CantidadSemillas = EstadoJuego.EdJ._Vegetales[3, 0];
        CantidadVegetal = EstadoJuego.EdJ._Vegetales[3, 1];
        PrecioSemillas = 10.0f;
        PrecioVenta = 30f;

        ActualizarTextoMenu01();
    }
}
