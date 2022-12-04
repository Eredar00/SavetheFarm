using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tienda_Herramientas : MonoBehaviour{

    [SerializeField] private GameObject _GOTop, _GOPuntosEnergia, _GOCasillas;

    [SerializeField] Image comprarMejoraPE;
    [SerializeField] Image comprarMejoraCasillas;

    [SerializeField] Herramienta _HerramientaUsada;

    private void Start() {
        Inicializar();
    }

    private void Inicializar(){
        _GOTop = transform.Find("Herramienta").Find("Top").gameObject;
        _GOPuntosEnergia = transform.Find("Herramienta").Find("Puntos Energia").gameObject;
        _GOCasillas = transform.Find("Herramienta").Find("Casillas").gameObject;
    }

    public void ActualizarTextos(Herramienta herramientaActual){
        Inicializar();

        _HerramientaUsada = herramientaActual;

        _GOTop.transform.Find("Imagen").Find("Sprite").GetComponent<Image>().sprite = herramientaActual.ImagenesHerramienta[herramientaActual.NivelHerramientaCasillas-1];
        _GOTop.transform.Find("Nombre").GetComponent<Text>().text = herramientaActual.NombreHerramienta;
        _GOTop.transform.Find("Descripcion").GetComponent<Text>().text = herramientaActual.DescripcionHerramienta;

        _GOPuntosEnergia.transform.Find("Nivel").GetComponent<Text>().text = "Nivel " + herramientaActual.NivelHerramientaPE + " > > > Nivel " + (herramientaActual.NivelHerramientaPE + 1);
        _GOPuntosEnergia.transform.Find("PE").GetComponent<Text>().text = "PE: " + herramientaActual.CosteHerramientaPE + " > > > PE: " + (herramientaActual.CosteHerramientaPE - 1) ;
        _GOPuntosEnergia.transform.Find("Coste").GetComponent<Text>().text = getPrecioMejorarPE() + "$";
        
        if(Dinero.dinero.ObtenerDinero() >= getPrecioMejorarPE()){ comprarMejoraPE.color = Color.white; }else{ comprarMejoraPE.color = Color.red; }

        if(herramientaActual.NivelHerramientaPE == herramientaActual.MaxNivelHerramientaPE){
            _GOPuntosEnergia.transform.Find("Nivel").GetComponent<Text>().text = "Nivel: " + herramientaActual.NivelHerramientaPE;
            _GOPuntosEnergia.transform.Find("PE").GetComponent<Text>().text = "PE: " + herramientaActual.CosteHerramientaPE;
            _GOPuntosEnergia.transform.Find("Coste").GetComponent<Text>().text = "Nv máx";
            comprarMejoraPE.color = Color.red;
        }

        _GOCasillas.transform.Find("Nivel").GetComponent<Text>().text = "Nivel " + herramientaActual.NivelHerramientaCasillas + " > > > Nivel " + (herramientaActual.NivelHerramientaCasillas + 1);
        _GOCasillas.transform.Find("Casillas").GetComponent<Text>().text = "Casillas: " + getNumeroCasillas(herramientaActual.NivelHerramientaCasillas) + " > > > Casillas: " + getNumeroCasillas(herramientaActual.NivelHerramientaCasillas + 1);
        _GOCasillas.transform.Find("Coste").GetComponent<Text>().text = getPrecioMejorarCasillas() + "$";    

        if(Dinero.dinero.ObtenerDinero() >= getPrecioMejorarCasillas()){ comprarMejoraCasillas.color = Color.white; }else{ comprarMejoraCasillas.color = Color.red; }   

        if(herramientaActual.NivelHerramientaCasillas == herramientaActual.MaxNivelHerramientaCasillas){
            _GOCasillas.transform.Find("Nivel").GetComponent<Text>().text = "Nivel: " + herramientaActual.NivelHerramientaCasillas;
            _GOCasillas.transform.Find("Casillas").GetComponent<Text>().text = "Casillas: " + getNumeroCasillas(herramientaActual.NivelHerramientaCasillas);
            _GOCasillas.transform.Find("Coste").GetComponent<Text>().text = "Nv máx";
            comprarMejoraCasillas.color = Color.red;
        } 
    }

    private int getPrecioMejorarPE(){
        return (_HerramientaUsada.NivelHerramientaPE * 10);
    }
    
    private int getPrecioMejorarCasillas(){
        return (_HerramientaUsada.NivelHerramientaCasillas * 25);
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
        if((Dinero.dinero.ObtenerDinero() >= getPrecioMejorarPE())&&(_HerramientaUsada.NivelHerramientaPE < _HerramientaUsada.MaxNivelHerramientaPE)){
            Dinero.dinero.VariarDinero(-getPrecioMejorarPE());
            _HerramientaUsada.NivelHerramientaPE = _HerramientaUsada.NivelHerramientaPE + 1;
            _HerramientaUsada.ActualizarCosteAccionPE();
            ActualizarTextos(_HerramientaUsada);
        }
    }

    public void ComprarMejoraCasillas(){
        if((Dinero.dinero.ObtenerDinero() >= getPrecioMejorarCasillas())&&(_HerramientaUsada.NivelHerramientaCasillas < _HerramientaUsada.MaxNivelHerramientaCasillas)){
            Dinero.dinero.VariarDinero(-getPrecioMejorarPE());
            _HerramientaUsada.NivelHerramientaCasillas = _HerramientaUsada.NivelHerramientaCasillas + 1;
            _HerramientaUsada.CambiarImagen();
            ActualizarTextos(_HerramientaUsada);
        }
    }

    public void SiguienteHerramienta(){
        if(_HerramientaUsada.NumeroHerramienta == 6){
            ActualizarTextos(GameManager.gameManager.GetTaller().GetHerramientaPorPosicion(0));
        }else{
            ActualizarTextos(GameManager.gameManager.GetTaller().GetHerramientaPorPosicion(_HerramientaUsada.NumeroHerramienta));
        }
    }

    public void AnteriorHerramienta(){
        if(_HerramientaUsada.NumeroHerramienta == 1){
            ActualizarTextos(GameManager.gameManager.GetTaller().GetHerramientaPorPosicion(5));
        }else{
            ActualizarTextos(GameManager.gameManager.GetTaller().GetHerramientaPorPosicion(_HerramientaUsada.NumeroHerramienta - 2));
        }
    }
}
