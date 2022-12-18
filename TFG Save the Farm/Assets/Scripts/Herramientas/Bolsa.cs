using UnityEngine;

public class Bolsa : Herramienta{

    private void Start() {
         Inicializar();
    }

    public void Inicializar(){
        NumeroHerramienta = 2;
        TeclaHerramienta = KeyCode.Alpha2;

        ImagenesHerramienta = ImagenesHerramienta = ImagenesManager.iMan.GetImagenesBolsa();
        
        if(EstadoJuego.EdJ.Lang == "CAT"){
            NombreHerramienta = "Bossa de llavors";
            DescripcionHerramienta = "Es fa servir per guardar llavors i poder plantar-les.";
        }else if(EstadoJuego.EdJ.Lang == "ESP"){
            NombreHerramienta = "Bolsa de semillas";
            DescripcionHerramienta = "Se usa para guardar semillas y poder plantarlas.";
        }else if(EstadoJuego.EdJ.Lang == "ENG"){
            NombreHerramienta = "Seed bag";
            DescripcionHerramienta = "It is used to store seeds and be able to plant them.";
        }

        NivelHerramientaPE = EstadoJuego.EdJ._Herramientas[1, 0];
        MaxNivelHerramientaPE = 10;

        NivelHerramientaCasillas = EstadoJuego.EdJ._Herramientas[1, 1];
        MaxNivelHerramientaCasillas = 4;

        CosteBasePE = 11;
        ActualizarCosteAccionPE();
        CambiarImagen();
    }
}
