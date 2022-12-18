using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arroz : Cultivos{

    private void Start() {
         Inicializar();
    }

    
    public void Inicializar(){
        
        NombreClave = "Arroz";

        if(EstadoJuego.EdJ.Lang == "CAT"){
            Nombre = "Arròs";
        }else if(EstadoJuego.EdJ.Lang == "ESP"){
            Nombre = "Arroz";
        }else if(EstadoJuego.EdJ.Lang == "ENG"){
            Nombre = "Rice";
        }

        Imagen = ImagenesManager.iMan.GetImagenesCosecha()[5];
        NumeroCultivo = 5;
        
        PuntosCrecimiento = 0;
        PuntosParaCosecha = 3;
    
        ProbabilidadSeguirRegada = 33;

        CantidadCosechaMin = 1; 
        CantidadCosechaMax = 3;    
        CosechaReiterativa = false;
        TiempoCosechaReiterativa = 0;

        CantidadSemillas = EstadoJuego.EdJ._Vegetales[4, 0];
        CantidadVegetal = EstadoJuego.EdJ._Vegetales[4, 1];
        PrecioSemillas = 0.5f;
        PrecioVenta = 1.0f;

        ActualizarTextoMenu01();
    }
}
