using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bolsa : Herramienta{

    private void Start() {
         Inicializar();
    }

    public void Inicializar(){
        NumeroHerramienta = 2;
        TeclaHerramienta = KeyCode.Alpha2;

        ImagenesHerramienta = ImagenesHerramienta = ImagenesManager.iMan.GetImagenesBolsa();
        NombreHerramienta = "Bolsa";
        DescripcionHerramienta = "Se usa para plantar semillas.";

        NivelHerramientaPE = 1;
        MaxNivelHerramientaPE = 10;

        NivelHerramientaCasillas = 1;
        MaxNivelHerramientaCasillas = 4;

        CosteBasePE = 11;
        ActualizarCosteAccionPE();
    }
}
