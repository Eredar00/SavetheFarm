using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Papelera : Herramienta{

    private void Start() {
         Inicializar();
    }

    public void Inicializar(){
        NumeroHerramienta = 5;
        TeclaHerramienta = KeyCode.Alpha5;

        ImagenesHerramienta = ImagenesHerramienta = ImagenesManager.iMan.GetImagenesPapelera();;
        
        if(EstadoJuego.EdJ.Lang == "CAT"){
            NombreHerramienta = "Paperera";
            DescripcionHerramienta = "S'usa per destruir una plantació a la casella seleccionada.";
        }else if(EstadoJuego.EdJ.Lang == "ESP"){
            NombreHerramienta = "Papelera";
            DescripcionHerramienta = "Se usa para destruir una plantación en la casilla seleccionada.";
        }else if(EstadoJuego.EdJ.Lang == "ENG"){
            NombreHerramienta = "Bin";
            DescripcionHerramienta = "Used to destroy a plantation on the selected tile.";
        }

        NivelHerramientaPE = EstadoJuego.EdJ._Herramientas[4, 0];
        MaxNivelHerramientaPE = 10;

        NivelHerramientaCasillas = EstadoJuego.EdJ._Herramientas[4, 1];
        MaxNivelHerramientaCasillas = 1;

        CosteBasePE = 20;
        ActualizarCosteAccionPE();
        CambiarImagen();
    }
}

