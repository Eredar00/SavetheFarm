using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlBotones : MonoBehaviour{

    public static ControlBotones controlBotones;
    
    [SerializeField] GameObject tiendaHortalizas;
    [SerializeField] GameObject _TiendaHerramientas; 
    [SerializeField] GameObject calendario; 

    private void Awake() {
        controlBotones = this;
    }

    private void Start() {
        LimpiarTodosLosActive();
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.H)) verTiendaHortalizas();
        if(Input.GetKeyDown(KeyCode.T)) VerTiendaHerramientas();
        if(Input.GetKeyDown(KeyCode.C)) verCalendario();
        if(Input.GetKeyDown(KeyCode.R)) CasillasHerramienta.casillasHerramienta.SiguienteCasilla();
        if(Input.GetKeyDown(KeyCode.P)) Semillas.semillas.SiguienteSemilla();
        if(Input.GetKeyDown(KeyCode.Escape)) BotonEscape();
    }

    private void BotonEscape(){
        if(HayAlgunActivo()){
            LimpiarTodosLosActive();
        }else{
            EstadoJuego.EdJ.Guardar();
            SceneManager.LoadScene("Portada");
        }
    }

    private bool HayAlgunActivo(){
        if(tiendaHortalizas.activeSelf){return true;}
        if(_TiendaHerramientas.activeSelf){return true;}
        if(calendario.activeSelf){return true;}
        return false;
    }

    public void LimpiarTodosLosActive(){
        tiendaHortalizas.SetActive(false);
        _TiendaHerramientas.SetActive(false);
        calendario.SetActive(false);
        GameManager.gameManager.CambiarFocusCanvas(false);
    }

    public GameObject getTiendaHortalizas(){return tiendaHortalizas;}

    private void verTiendaHortalizas(){
        if(tiendaHortalizas.activeSelf){
            tiendaHortalizas.SetActive(false);
            GameManager.gameManager.CambiarFocusCanvas(false);
        }else{
            LimpiarTodosLosActive();
            tiendaHortalizas.SetActive(true);
            tiendaHortalizas.transform.Find("Menu 02").gameObject.SetActive(false);
            tiendaHortalizas.transform.Find("Menu 01").gameObject.SetActive(true);

            Cultivos[] _ListaCultivos = GameManager.gameManager.GetHortalizas().GetCultivos();
            foreach (Cultivos tipos in _ListaCultivos){
                tipos.ActualizarTextoMenu01();
            } 
        }
    }

    private void VerTiendaHerramientas(){  
        Taller taller = GameManager.gameManager.GetTaller();
        if(_TiendaHerramientas.activeSelf){
            _TiendaHerramientas.SetActive(false);
            GameManager.gameManager.CambiarFocusCanvas(false);
        }else{
            LimpiarTodosLosActive();
            _TiendaHerramientas.SetActive(true);
            _TiendaHerramientas.GetComponent<TiendaHerramientas>().ActualizarTextos(taller.GetHerramientaPorPosicion(taller.NumeroHerramientaActual - 1));
            
        }
    }

    public void verCalendario(){
        if(calendario.activeSelf){
            calendario.SetActive(false);
            GameManager.gameManager.CambiarFocusCanvas(false);
        }else{
            LimpiarTodosLosActive();
            calendario.SetActive(true);
        }
    }
}
