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
        NombreHerramienta = "Cesta";
        DescripcionHerramienta = "Se usa para cosechar.";

        NivelHerramientaPE = 1;
        MaxNivelHerramientaPE = 10;

        NivelHerramientaCasillas = 1;
        MaxNivelHerramientaCasillas = 4;

        CosteBasePE = 11;
        ActualizarCosteAccionPE();
    }
}

