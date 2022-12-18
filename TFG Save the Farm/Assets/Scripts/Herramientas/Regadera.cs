using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Regadera : Herramienta{

    private void Start() {
         Inicializar();
    }

    public void Inicializar(){
        NumeroHerramienta = 3;
        TeclaHerramienta = KeyCode.Alpha3;

        ImagenesHerramienta = ImagenesHerramienta = ImagenesManager.iMan.GetImagenesRegadera();
        
        if(EstadoJuego.EdJ.Lang == "CAT"){
            NombreHerramienta = "Regadora";
            DescripcionHerramienta = "Es fa servir per regar les plantes o caselles.";
        }else if(EstadoJuego.EdJ.Lang == "ESP"){
            NombreHerramienta = "Regadera";
            DescripcionHerramienta = "Se usa para regar las plantas o casillas.";
        }else if(EstadoJuego.EdJ.Lang == "ENG"){
            NombreHerramienta = "Watering can";
            DescripcionHerramienta = "It is used to water the plants or tiles.";
        }

       NivelHerramientaPE = EstadoJuego.EdJ._Herramientas[2, 0];
        MaxNivelHerramientaPE = 10;

        NivelHerramientaCasillas = EstadoJuego.EdJ._Herramientas[2, 1];
        MaxNivelHerramientaCasillas = 4;

        CosteBasePE = 11;
        ActualizarCosteAccionPE();
        CambiarImagen();
    }
}
