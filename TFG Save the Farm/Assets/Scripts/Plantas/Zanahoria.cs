using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zanahoria : Cultivos{

    private void Start() {
         Inicializar();
    }

    
    public void Inicializar(){
        
        NombreClave = "Zanahoria";

        if(EstadoJuego.EdJ.Lang == "CAT"){
            Nombre = "Pastanaga";
        }else if(EstadoJuego.EdJ.Lang == "ESP"){
            Nombre = "Zanahoria";
        }else if(EstadoJuego.EdJ.Lang == "ENG"){
            Nombre = "Carrot";
        }

        Imagen = ImagenesManager.iMan.GetImagenesCosecha()[3];
        NumeroCultivo = 3;
        
        PuntosCrecimiento = 0;
        PuntosParaCosecha = 5;
    
        ProbabilidadSeguirRegada = 5;

        CantidadCosechaMin = 1; 
        CantidadCosechaMax = 3;    
        CosechaReiterativa = false;
        TiempoCosechaReiterativa = 0;

        CantidadSemillas = EstadoJuego.EdJ._Vegetales[2, 0];
        CantidadVegetal = EstadoJuego.EdJ._Vegetales[2, 1];
        PrecioSemillas = 1.0f;
        PrecioVenta = 3.0f;

        ActualizarTextoMenu01();
    }
}
