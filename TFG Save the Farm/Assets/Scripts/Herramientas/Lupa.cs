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
        NombreHerramienta = "Lupa";
        DescripcionHerramienta = "Se usa para ver la información de una casilla.";

        NivelHerramientaPE = 1;
        MaxNivelHerramientaPE = 1;

        NivelHerramientaCasillas = 1;
        MaxNivelHerramientaCasillas = 1;

        CosteBasePE = 1;
        ActualizarCosteAccionPE();
    }
}
