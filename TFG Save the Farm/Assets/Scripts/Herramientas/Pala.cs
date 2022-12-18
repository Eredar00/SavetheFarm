using UnityEngine;

public class Pala : Herramienta{

    private void Start() {
         Inicializar();
    }

    public void Inicializar(){
        NumeroHerramienta = 1;
        TeclaHerramienta = KeyCode.Alpha1;

        ImagenesHerramienta = ImagenesManager.iMan.GetImagenesPala();
        
        if(EstadoJuego.EdJ.Lang == "CAT"){
            NombreHerramienta = "Pala";
            DescripcionHerramienta = "S'usa per llaurar la terra i poder plantar llavors.";
        }else if(EstadoJuego.EdJ.Lang == "ESP"){
            NombreHerramienta = "Pala";
            DescripcionHerramienta = "Se usa para arar la tierra y poder plantar semillas.";
        }else if(EstadoJuego.EdJ.Lang == "ENG"){
            NombreHerramienta = "Shovel";
            DescripcionHerramienta = "It is used to plow the land and be able to plant seeds.";
        }

        NivelHerramientaPE = EstadoJuego.EdJ._Herramientas[0, 0];
        MaxNivelHerramientaPE = 10;

        NivelHerramientaCasillas = EstadoJuego.EdJ._Herramientas[0, 1];
        MaxNivelHerramientaCasillas = 4;

        CosteBasePE = 11;
        ActualizarCosteAccionPE();
        CambiarImagen();
    }
}
