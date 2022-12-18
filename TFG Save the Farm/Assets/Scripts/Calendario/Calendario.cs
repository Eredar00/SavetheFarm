using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Calendario : MonoBehaviour, IPointerDownHandler{
    
    [SerializeField] private Text _TextoDia;
    [SerializeField] GameObject[] _Dias;
    private Sprite _Cruz;

    private void Start() {
        _Cruz = Resources.Load<Sprite>("Sprites/Calendario/Cruz");
        ActualizarTextoDia();
        if(EstadoJuego.EdJ._Dia == 1){
            _Dias[EstadoJuego.EdJ._Dia-1].GetComponentInChildren<Image>().color = new Color(0,255,0,255);
        }else{
            CargarCalendario();
        }
    }

    private void ActualizarTextoDia(){
        _TextoDia.text = transform.GetComponentInParent<TextosJuego>().GetTexto(1) + " " + EstadoJuego.EdJ._Dia.ToString();
    }

    public void SumarDia(){
        RevisarEstadoDias();
        if(EstadoJuego.EdJ.FinalJuego == ""){
            TacharDias();
            EstadoJuego.EdJ._Dia++;
            EstadoJuego.EdJ.Guardar();
            ActualizarTextoDia();
        }
    }

    private void CargarCalendario(){
        for (int i = 1; i < EstadoJuego.EdJ._Dia; i++){
            _Dias[i-1].GetComponentInChildren<Image>().sprite = _Cruz;
            _Dias[i-1].GetComponentInChildren<Image>().color = new Color(255,255,255,255);
            _Dias[i].GetComponentInChildren<Image>().color = new Color(0,255,0,255);
        }
    }

    private void TacharDias(){
        _Dias[EstadoJuego.EdJ._Dia-1].GetComponentInChildren<Image>().sprite = _Cruz;
        _Dias[EstadoJuego.EdJ._Dia-1].GetComponentInChildren<Image>().color = new Color(255,255,255,255);
        _Dias[EstadoJuego.EdJ._Dia].GetComponentInChildren<Image>().color = new Color(0,255,0,255);
    }

    private void RevisarEstadoDias(){
        if(EstadoJuego.EdJ._Dia == 14){
            if(Dinero.dinero.ObtenerDinero() >= 100){
                Dinero.dinero.VariarDinero(-100);
            }else{
                EstadoJuego.EdJ.FinalJuego = "Game Over";
                SceneManager.LoadScene("Final del Juego");
            }
        }else if(EstadoJuego.EdJ._Dia == 28){
            if(Dinero.dinero.ObtenerDinero() >= 200){
                Dinero.dinero.VariarDinero(-200);
                EstadoJuego.EdJ.FinalJuego = "Win";
                SceneManager.LoadScene("Final del Juego");
            }else{
                EstadoJuego.EdJ.FinalJuego = "Game Over";
                SceneManager.LoadScene("Final del Juego");
            }
        }
    }

    public void OnPointerDown(PointerEventData eventData){
        ControlBotones.controlBotones.verCalendario();
    }
}
