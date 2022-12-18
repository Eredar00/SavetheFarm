using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lupa : Herramienta{

    private void Start() {
         Inicializar();
    }

    public void Inicializar(){
        NumeroHerramienta = 6;
        TeclaHerramienta = KeyCode.Alpha6;

        ImagenesHerramienta = ImagenesHerramienta = ImagenesManager.iMan.GetImagenesLupa();

        if(EstadoJuego.EdJ.Lang == "CAT"){
            NombreHerramienta = "Lupa";
            DescripcionHerramienta = "S'usa per veure la informació d'una casella.";
        }else if(EstadoJuego.EdJ.Lang == "ESP"){
            NombreHerramienta = "Lupa";
            DescripcionHerramienta = "Se usa para ver la información de una casilla.";
        }else if(EstadoJuego.EdJ.Lang == "ENG"){
            NombreHerramienta = "Magnifying glass";
            DescripcionHerramienta = "Used to see the information of a tile.";
        }
        
        NivelHerramientaPE = EstadoJuego.EdJ._Herramientas[5, 0];
        MaxNivelHerramientaPE = 1;

        NivelHerramientaCasillas = EstadoJuego.EdJ._Herramientas[5, 1];
        MaxNivelHerramientaCasillas = 1;

        CosteBasePE = 1;
        ActualizarCosteAccionPE();
        CambiarImagen();
    }
}
