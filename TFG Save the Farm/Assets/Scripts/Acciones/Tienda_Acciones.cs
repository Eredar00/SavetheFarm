using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tienda_Acciones : MonoBehaviour
{
    [SerializeField] Text nombreHerramienta;
    [SerializeField] Text descripcionHerramienta;
    [SerializeField] Image imagenHerramienta;
    [SerializeField] Text nivelPEText;
    [SerializeField] Text nivelCasillasText;
    [SerializeField] Text costePEText;
    [SerializeField] Text casillasText;
    [SerializeField] Text precioMejorarPE;
    [SerializeField] Text precioMejorarCasillas;
    [SerializeField] Image comprarMejoraPE;
    [SerializeField] Image comprarMejoraCasillas;

    [SerializeField] Accion accionUsada;

    public void ActualizarTextos(Accion accionActual){
        accionUsada = accionActual;

        imagenHerramienta.sprite = accionActual.getImagen();
        nombreHerramienta.text = accionActual.getNombreHerramienta();
        descripcionHerramienta.text = accionActual.getDescripcionHerramienta();
        nivelPEText.text = "Nivel " + accionActual.getNivelPE() + " > > > Nivel " + (accionActual.getNivelPE() + 1);
        nivelCasillasText.text = "Nivel " + accionActual.getNivelCasillas() + " > > > Nivel " + (accionActual.getNivelCasillas() + 1);
        costePEText.text = "PE: " + accionActual.getCostePE() + " > > > PE: " + (accionActual.getCostePE() - 1) ;
        casillasText.text = "Casillas: " + getNumeroCasillas(accionActual.getNivelCasillas()) + " > > > Casillas: " + getNumeroCasillas(accionActual.getNivelCasillas() + 1);
        precioMejorarPE.text = getPrecioMejorarPE() + "$";
        precioMejorarCasillas.text = getPrecioMejorarCasillas() + "$";

        if(Dinero.dinero.ObtenerDinero() >= getPrecioMejorarPE()){ comprarMejoraPE.color = Color.white; }else{ comprarMejoraPE.color = Color.red; }
        if(Dinero.dinero.ObtenerDinero() >= getPrecioMejorarCasillas()){ comprarMejoraCasillas.color = Color.white; }else{ comprarMejoraCasillas.color = Color.red; }

        if(accionActual.getNivelPE() == 10){
             nivelPEText.text = "Nivel: " + accionActual.getNivelPE();
             costePEText.text = "PE: " + accionActual.getCostePE();
             precioMejorarPE.text = "Nv máx";
             comprarMejoraPE.color = Color.red;
        }

        if(accionActual.getNivelCasillas() == 4){
            nivelCasillasText.text = "Nivel: " + accionActual.getNivelCasillas();
            casillasText.text = "Casillas: " + getNumeroCasillas(accionActual.getNivelCasillas());
            precioMejorarCasillas.text = "Nv máx";
            comprarMejoraCasillas.color = Color.red;
        }        
    }

    private int getPrecioMejorarPE(){
        return (Acciones.acciones.getAccionActual().getNivelPE() * 10);
    }
    
    private int getPrecioMejorarCasillas(){
        return (Acciones.acciones.getAccionActual().getNivelCasillas() * 25);
    }

    private int getNumeroCasillas(int numero){
        if(numero == 1){
            return 1;
        }else if(numero == 2){
            return 3;
        }else if(numero == 3){
            return 5;
        }else{
            return 9;
        }
    }

    public void ComprarMejoraPE(){
        if((Dinero.dinero.ObtenerDinero() >= getPrecioMejorarPE())&&(Acciones.acciones.getAccionActual().getNivelPE() < 10)){
            Dinero.dinero.VariarDinero(-getPrecioMejorarPE());
            Acciones.acciones.getAccionActual().SubirNivelPE();
            ActualizarTextos(accionUsada);
        }
    }

    public void ComprarMejoraCasillas(){
        if((Dinero.dinero.ObtenerDinero() >= getPrecioMejorarCasillas())&&(Acciones.acciones.getAccionActual().getNivelCasillas() < 4)){
            Dinero.dinero.VariarDinero(-getPrecioMejorarCasillas());
            Acciones.acciones.getAccionActual().SubirNivelCasillas();
            ActualizarTextos(accionUsada);
        }
    }

    public void SiguienteHerramienta(){
        if(accionUsada.getNumAccion() == 5){
            ActualizarTextos(Acciones.acciones.getAccionConcrecta(1));
        }else{
            ActualizarTextos(Acciones.acciones.getAccionConcrecta(accionUsada.getNumAccion() + 1));
        }
    }

    public void AnteriorHerramienta(){
        if(accionUsada.getNumAccion() == 1){
            ActualizarTextos(Acciones.acciones.getAccionConcrecta(5));
        }else{
            ActualizarTextos(Acciones.acciones.getAccionConcrecta(accionUsada.getNumAccion() - 1));
        }
    }
}
