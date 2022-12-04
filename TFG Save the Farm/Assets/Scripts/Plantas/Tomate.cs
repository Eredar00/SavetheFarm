using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tomate : Cultivos{

    private void Start() {
         Inicializar();
    }

    
    public void Inicializar(){
        Nombre = "Tomate";
        Imagen = ImagenesManager.iMan.GetImagenesCosecha()[1];

        PuntosCrecimiento = 0;
        PuntosParaCosecha = 7;
    
        ProbabilidadSeguirRegada = 10;

        CantidadCosechaMin = 1; 
        CantidadCosechaMax = 2;    
        CosechaReiterativa = true;
        TiempoCosechaReiterativa = 4;

        CantidadSemillas = 0;
        CantidadVegetal = 0;
        PrecioSemillas = 1.0f;
        PrecioVenta = 2.5f;
        
        ActualizarTextoMenu01();
    }
}
