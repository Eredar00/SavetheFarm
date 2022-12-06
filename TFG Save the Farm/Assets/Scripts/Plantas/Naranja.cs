using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Naranja : Cultivos{

    private void Start() {
         Inicializar();
    }

    
    public void Inicializar(){
        
        Nombre = "Naranja";
        Imagen = ImagenesManager.iMan.GetImagenesCosecha()[4];

        PuntosCrecimiento = 0;
        PuntosParaCosecha = 8;
    
        ProbabilidadSeguirRegada = 20;

        CantidadCosechaMin = 0; 
        CantidadCosechaMax = 1;    
        CosechaReiterativa = true;
        TiempoCosechaReiterativa = 4;

        CantidadSemillas = 0;
        CantidadVegetal = 0;
        PrecioSemillas = 10.0f;
        PrecioVenta = 30f;

        ActualizarTextoMenu01();
    }
}
