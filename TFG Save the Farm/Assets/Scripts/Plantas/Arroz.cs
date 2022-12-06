using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arroz : Cultivos{

    private void Start() {
         Inicializar();
    }

    
    public void Inicializar(){
        
        Nombre = "Arroz";
        Imagen = ImagenesManager.iMan.GetImagenesCosecha()[5];

        PuntosCrecimiento = 0;
        PuntosParaCosecha = 3;
    
        ProbabilidadSeguirRegada = 33;

        CantidadCosechaMin = 1; 
        CantidadCosechaMax = 3;    
        CosechaReiterativa = false;
        TiempoCosechaReiterativa = 0;

        CantidadSemillas = 0;
        CantidadVegetal = 0;
        PrecioSemillas = 0.5f;
        PrecioVenta = 1.0f;

        ActualizarTextoMenu01();
    }
}
