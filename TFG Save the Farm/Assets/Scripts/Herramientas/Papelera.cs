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
        NombreHerramienta = "Papelera";
        DescripcionHerramienta = "Se usa para destruir una planta.";

        NivelHerramientaPE = 1;
        MaxNivelHerramientaPE = 10;

        NivelHerramientaCasillas = 1;
        MaxNivelHerramientaCasillas = 1;

        CosteBasePE = 20;
        ActualizarCosteAccionPE();
    }
}

