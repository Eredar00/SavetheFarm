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
        NombreHerramienta = "Regadera";
        DescripcionHerramienta = "Se usa para regar las plantas.";

        NivelHerramientaPE = 1;
        MaxNivelHerramientaPE = 10;

        NivelHerramientaCasillas = 1;
        MaxNivelHerramientaCasillas = 4;

        CosteBasePE = 11;
        ActualizarCosteAccionPE();
    }
}
