using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cesta : Herramienta{

    private void Start() {
         Inicializar();
    }

    public void Inicializar(){
        NumeroHerramienta = 4;
        TeclaHerramienta = KeyCode.Alpha4;

        ImagenesHerramienta = ImagenesHerramienta = ImagenesManager.iMan.GetImagenesCesta();
        
        if(EstadoJuego.EdJ.Lang == "CAT"){
            NombreHerramienta = "Cistella";
            DescripcionHerramienta = "Es fa servir per recollir la collita d'un cultiu.";
        }else if(EstadoJuego.EdJ.Lang == "ESP"){
            NombreHerramienta = "Cesta";
            DescripcionHerramienta = "Se usa para recoger la cosecha de un cultivo.";
        }else if(EstadoJuego.EdJ.Lang == "ENG"){
            NombreHerramienta = "Basket";
            DescripcionHerramienta = "It is used to collect the harvest of a crop.";
        }

        NivelHerramientaPE = EstadoJuego.EdJ._Herramientas[3, 0];
        MaxNivelHerramientaPE = 10;

        NivelHerramientaCasillas = EstadoJuego.EdJ._Herramientas[3, 1];
        MaxNivelHerramientaCasillas = 4;

        CosteBasePE = 11;
        ActualizarCosteAccionPE();
        CambiarImagen();
    }
}

