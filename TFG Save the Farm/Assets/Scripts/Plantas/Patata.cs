using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patata : Cultivos{

   private void Start() {
         Inicializar();
    }

    
    public void Inicializar(){
        
        Nombre = "Patata";
        Imagen = ImagenesManager.iMan.GetImagenesCosecha()[2];

        PuntosCrecimiento = 0;
        PuntosParaCosecha = 5;
    
        ProbabilidadSeguirRegada = 10;

        CantidadCosechaMin = 1; 
        CantidadCosechaMax = 5;   
        CosechaReiterativa = true;
        TiempoCosechaReiterativa = 3;

        CantidadSemillas = 0;
        CantidadVegetal = 0;
        PrecioSemillas = 1.0f;
        PrecioVenta = 2.5f;

        ActualizarTextoMenu01();
    }
}
