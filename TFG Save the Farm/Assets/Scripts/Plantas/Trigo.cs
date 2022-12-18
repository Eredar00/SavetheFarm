using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigo : Cultivos{

    private void Start() {
         Inicializar();
    }

    
    public void Inicializar(){
        
        NombreClave = "Trigo";

        if(EstadoJuego.EdJ.Lang == "CAT"){
            Nombre = "Blat";
        }else if(EstadoJuego.EdJ.Lang == "ESP"){
            Nombre = "Trigo";
        }else if(EstadoJuego.EdJ.Lang == "ENG"){
            Nombre = "Wheat";
        }

        Imagen = ImagenesManager.iMan.GetImagenesCosecha()[6];
        NumeroCultivo = 6;
        
        PuntosCrecimiento = 0;
        PuntosParaCosecha = 6;
    
        ProbabilidadSeguirRegada = 1;

        CantidadCosechaMin = 1; 
        CantidadCosechaMax = 2;    
        CosechaReiterativa = false;
        TiempoCosechaReiterativa = 0;

        CantidadSemillas = EstadoJuego.EdJ._Vegetales[5, 0];
        CantidadVegetal = EstadoJuego.EdJ._Vegetales[5, 1];
        PrecioSemillas = 2.0f;
        PrecioVenta = 6.5f;

        ActualizarTextoMenu01();
    }
}
