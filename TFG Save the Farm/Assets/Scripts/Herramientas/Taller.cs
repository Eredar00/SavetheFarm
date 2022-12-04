using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Taller : MonoBehaviour{

    [SerializeField] Herramienta[] _Herramientas;
    private int _NumeroHerramientaActual;

    public Herramienta GetHerramientaPorPosicion(int posicion){return _Herramientas[posicion];}
    public Herramienta[] GetHerramientas(){return _Herramientas;}

    private void Start() {
        SetHerramienta(1);
    }
    
    public void SetHerramienta(int numeroHerramientaNueva){
        if(numeroHerramientaNueva == 6){
            Lupaaaa(true);
        }else{
            Lupaaaa(false);
        }

        NumeroHerramientaActual = numeroHerramientaNueva;
        GameManager.gameManager.NumeroHerramienta = numeroHerramientaNueva;

        for (int i = 0; i < _Herramientas.Length; i++){
            _Herramientas[i].GetComponentInChildren<Text>().color = Color.white;
        }

        _Herramientas[numeroHerramientaNueva-1].GetComponentInChildren<Text>().color = Color.cyan;

        Casilla casilla = GameManager.gameManager.ObtenerTileFocused();

        if(casilla != null){
            casilla.QuitarTodosLosFocus();
            casilla.CambiarTodosLosFocus(casilla);
        } 

        Casillas.casillas.SetHerramientaActual(_Herramientas[numeroHerramientaNueva-1]);
    }

    public string ComprobarQueHighlightHerramienta(Casilla casilla, TipoCasilla tipoCasilla, int numHerramienta){
        if((numHerramienta == 1) && (tipoCasilla == TipoCasilla.Bloqueado || tipoCasilla == TipoCasilla.Arado_Seca || tipoCasilla == TipoCasilla.Arado_Mojado || tipoCasilla == TipoCasilla.Plantado_Seca || tipoCasilla == TipoCasilla.Plantado_Mojado || tipoCasilla == TipoCasilla.Cultivado_Seca || tipoCasilla == TipoCasilla.Cultivado_Mojado)){return "Roja";}
        if((numHerramienta == 2) && (tipoCasilla == TipoCasilla.Bloqueado || tipoCasilla == TipoCasilla.Tierra_Seca || tipoCasilla == TipoCasilla.Tierra_Mojada || tipoCasilla == TipoCasilla.Plantado_Seca || tipoCasilla == TipoCasilla.Plantado_Mojado || tipoCasilla == TipoCasilla.Cultivado_Seca || tipoCasilla == TipoCasilla.Cultivado_Mojado)){ return "Roja";}
        if((numHerramienta == 3) && (tipoCasilla == TipoCasilla.Bloqueado || tipoCasilla == TipoCasilla.Tierra_Mojada || tipoCasilla == TipoCasilla.Arado_Mojado|| tipoCasilla == TipoCasilla.Plantado_Mojado || tipoCasilla == TipoCasilla.Cultivado_Mojado)){ return "Roja";}
        if((numHerramienta == 4) && (tipoCasilla == TipoCasilla.Bloqueado || tipoCasilla == TipoCasilla.Tierra_Seca || tipoCasilla == TipoCasilla.Tierra_Mojada || tipoCasilla == TipoCasilla.Arado_Seca || tipoCasilla == TipoCasilla.Arado_Mojado || tipoCasilla == TipoCasilla.Plantado_Seca || tipoCasilla == TipoCasilla.Plantado_Mojado || tipoCasilla == TipoCasilla.Cultivado_Seca || tipoCasilla == TipoCasilla.Cultivado_Mojado)){ return "Roja";}
        if((numHerramienta == 5) && (tipoCasilla == TipoCasilla.Bloqueado || tipoCasilla == TipoCasilla.Tierra_Seca || tipoCasilla == TipoCasilla.Tierra_Mojada || tipoCasilla == TipoCasilla.Arado_Seca || tipoCasilla == TipoCasilla.Arado_Mojado)){ return "Roja";}
        if(!GameManager.gameManager.HaySuficientesPuntosEnergiaParaAccion()){return "Negra";}
        return "Seleccion";
    }

    public void ResultadoAccion(Casilla casillaRecibida, int numAccion){
        Planta plantaCasilla = casillaRecibida.GetPlanta();
        Cosecha cosechaCasilla = casillaRecibida.GetCosecha();

        int costeEnergia = GetHerramientaPorPosicion(_NumeroHerramientaActual-1).CosteHerramientaPE;

        if(numAccion == 1){

            if(casillaRecibida.GetTipoCasilla() == TipoCasilla.Tierra_Seca) {casillaRecibida.SetTipoCasilla(TipoCasilla.Arado_Seca); GameManager.gameManager.VariarPuntosEnergia(-costeEnergia); }
            else if(casillaRecibida.GetTipoCasilla() == TipoCasilla.Tierra_Mojada) {casillaRecibida.SetTipoCasilla(TipoCasilla.Arado_Mojado); GameManager.gameManager.VariarPuntosEnergia(-costeEnergia); }
            
        }else if(numAccion == 2){

            Sembrar(casillaRecibida);

        }else if(numAccion == 3){

            if(casillaRecibida.GetTipoCasilla() == TipoCasilla.Tierra_Seca) {casillaRecibida.SetTipoCasilla(TipoCasilla.Tierra_Mojada); GameManager.gameManager.VariarPuntosEnergia(-costeEnergia); }
            else if(casillaRecibida.GetTipoCasilla() == TipoCasilla.Arado_Seca) {casillaRecibida.SetTipoCasilla(TipoCasilla.Arado_Mojado); GameManager.gameManager.VariarPuntosEnergia(-costeEnergia); }
            else if(casillaRecibida.GetTipoCasilla() == TipoCasilla.Plantado_Seca) {casillaRecibida.SetTipoCasilla(TipoCasilla.Plantado_Mojado); GameManager.gameManager.VariarPuntosEnergia(-costeEnergia); }
            else if(casillaRecibida.GetTipoCasilla() == TipoCasilla.Cultivado_Seca) {casillaRecibida.SetTipoCasilla(TipoCasilla.Cultivado_Mojado); GameManager.gameManager.VariarPuntosEnergia(-costeEnergia); }
        
        }else if(numAccion == 4){

            Cosechar(casillaRecibida, plantaCasilla, cosechaCasilla);
        
        }else if(numAccion == 5){

            if(casillaRecibida.GetTipoCasilla() == TipoCasilla.Plantado_Seca) {casillaRecibida.SetTipoCasilla(TipoCasilla.Arado_Seca); GameManager.gameManager.VariarPuntosEnergia(-costeEnergia); }
            else if(casillaRecibida.GetTipoCasilla() == TipoCasilla.Plantado_Mojado) {casillaRecibida.SetTipoCasilla(TipoCasilla.Arado_Mojado); GameManager.gameManager.VariarPuntosEnergia(-costeEnergia); }
            else if(casillaRecibida.GetTipoCasilla() == TipoCasilla.Cultivado_Seca) {casillaRecibida.SetTipoCasilla(TipoCasilla.Tierra_Seca); plantaCasilla.EliminarPlanta(); GameManager.gameManager.VariarPuntosEnergia(-costeEnergia); }
            else if(casillaRecibida.GetTipoCasilla() == TipoCasilla.Cultivado_Mojado) {casillaRecibida.SetTipoCasilla(TipoCasilla.Tierra_Mojada); plantaCasilla.EliminarPlanta(); GameManager.gameManager.VariarPuntosEnergia(-costeEnergia); }
        
        }else if(numAccion == 6){}
    }

    private void Sembrar(Casilla casillaRecibida){
        int costeEnergia = GetHerramientaPorPosicion(_NumeroHerramientaActual).CosteHerramientaPE;

        if(casillaRecibida.GetTipoCasilla() == TipoCasilla.Arado_Seca || casillaRecibida.GetTipoCasilla() == TipoCasilla.Arado_Mojado) {
            Cultivos vegetalPlantar = Semillas.semillas.GetVegetalPlantar();

            if(vegetalPlantar.CantidadSemillas == 0){
                Debug.Log("No hay suficientes semillas.");
            }else{
                GameManager.gameManager.VariarPuntosEnergia(-costeEnergia);
                casillaRecibida.GetPlanta().SetTipoVegetal(vegetalPlantar);
                vegetalPlantar.CantidadSemillas = vegetalPlantar.CantidadSemillas - 1;
                Semillas.semillas.ActualizarTextoNumero();
                
                if(casillaRecibida.GetTipoCasilla() == TipoCasilla.Arado_Seca){
                    casillaRecibida.SetTipoCasilla(TipoCasilla.Plantado_Seca);
                }else if(casillaRecibida.GetTipoCasilla() == TipoCasilla.Arado_Mojado){
                    casillaRecibida.SetTipoCasilla(TipoCasilla.Plantado_Mojado);
                }
                
            }
        }
    }

    private void Cosechar(Casilla casillaRecibida, Planta plantaCasilla, Cosecha cosechaCasilla){
        int costeEnergia = GetHerramientaPorPosicion(_NumeroHerramientaActual).CosteHerramientaPE;

        if(casillaRecibida.GetTipoCasilla() == TipoCasilla.Cosecha_Seca || casillaRecibida.GetTipoCasilla() == TipoCasilla.Cosecha_Mojado){
            cosechaCasilla.RecolectarCosecha(plantaCasilla.GetTipoVegetal(), plantaCasilla.CantidadCosecha); 
            GameManager.gameManager.VariarPuntosEnergia(-costeEnergia); 
            if(plantaCasilla.CosechaReiterativa){
                plantaCasilla.PuntosCosechaReiterativa = 0;
            }else{
                plantaCasilla.EliminarPlanta(); 
            }
            if(casillaRecibida.GetTipoCasilla() == TipoCasilla.Cosecha_Seca){casillaRecibida.SetTipoCasilla(TipoCasilla.Cultivado_Seca);}
            if(casillaRecibida.GetTipoCasilla() == TipoCasilla.Cosecha_Mojado) {casillaRecibida.SetTipoCasilla(TipoCasilla.Cultivado_Mojado); }
        }
    }
    
    public int NumeroHerramientaActual { get => _NumeroHerramientaActual; set => _NumeroHerramientaActual = value; }

    public void Lupaaaa(bool valor){
        if(valor){
            GameManager.gameManager.InfoCasilla.SetActive(true);
            if(GameManager.gameManager.CasillaFocus != null){
                GameManager.gameManager.InfoCasilla.transform.Find("Tipo").GetComponent<Text>().text = GameManager.gameManager.CasillaFocus.GetTipoCasilla().ToString();
            }else{
                GameManager.gameManager.InfoCasilla.transform.Find("Tipo").GetComponent<Text>().text = "Sin casilla";
            }
            
        }else{
            GameManager.gameManager.InfoCasilla.SetActive(false);
        }
    }

}