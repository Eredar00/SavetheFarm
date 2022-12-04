using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zanahoria : Cultivos{

    private void Start() {
         Inicializar();
    }

    
    public void Inicializar(){
        
        Nombre = "Zanahoria";
        Imagen = ImagenesManager.iMan.GetImagenesCosecha()[3];

        PuntosCrecimiento = 0;
        PuntosParaCosecha = 5;
    
        ProbabilidadSeguirRegada = 10;

        CantidadCosechaMin = 1; 
        CantidadCosechaMax = 3;    
        CosechaReiterativa = false;
        TiempoCosechaReiterativa = 0;

        CantidadSemillas = 0;
        CantidadVegetal = 0;
        PrecioSemillas = 1.0f;
        PrecioVenta = 2.5f;

        ActualizarTextoMenu01();
    }
}
