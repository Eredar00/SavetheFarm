using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigo : Cultivos{

    private void Start() {
         Inicializar();
    }

    
    public void Inicializar(){
        
        Nombre = "Trigo";
        Imagen = ImagenesManager.iMan.GetImagenesCosecha()[6];

        PuntosCrecimiento = 0;
        PuntosParaCosecha = 6;
    
        ProbabilidadSeguirRegada = 1;

        CantidadCosechaMin = 1; 
        CantidadCosechaMax = 2;    
        CosechaReiterativa = false;
        TiempoCosechaReiterativa = 0;

        CantidadSemillas = 0;
        CantidadVegetal = 0;
        PrecioSemillas = 2.0f;
        PrecioVenta = 6.5f;

        ActualizarTextoMenu01();
    }
}
