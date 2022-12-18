using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patata : Cultivos{

   private void Start() {
         Inicializar();
    }

    
    public void Inicializar(){
        
        NombreClave = "Patata";

        if(EstadoJuego.EdJ.Lang == "CAT"){
            Nombre = "Patata";
        }else if(EstadoJuego.EdJ.Lang == "ESP"){
            Nombre = "Patata";
        }else if(EstadoJuego.EdJ.Lang == "ENG"){
            Nombre = "Potato";
        }

        Imagen = ImagenesManager.iMan.GetImagenesCosecha()[2];
        NumeroCultivo = 2;
        
        PuntosCrecimiento = 0;
        PuntosParaCosecha = 4;
    
        ProbabilidadSeguirRegada = 10;

        CantidadCosechaMin = 1; 
        CantidadCosechaMax = 5;   
        CosechaReiterativa = true;
        TiempoCosechaReiterativa = 3;

        CantidadSemillas = EstadoJuego.EdJ._Vegetales[1, 0];
        CantidadVegetal = EstadoJuego.EdJ._Vegetales[1, 1];
        PrecioSemillas = 1.0f;
        PrecioVenta = 1.5f;

        ActualizarTextoMenu01();
    }
}
