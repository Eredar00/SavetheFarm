using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pala : Herramienta{

    private void Start() {
         Inicializar();
    }

    public void Inicializar(){
        NumeroHerramienta = 1;
        TeclaHerramienta = KeyCode.Alpha1;

        ImagenesHerramienta = ImagenesManager.iMan.GetImagenesPala();
        NombreHerramienta = "Pala";
        DescripcionHerramienta = "Se usa para cavar.";

        NivelHerramientaPE = 1;
        MaxNivelHerramientaPE = 10;

        NivelHerramientaCasillas = 1;
        MaxNivelHerramientaCasillas = 4;

        CosteBasePE = 11;
        ActualizarCosteAccionPE();
        CambiarImagen();
    }
}
