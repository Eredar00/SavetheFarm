using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Calendario : MonoBehaviour, IPointerDownHandler{
    
    [SerializeField] GameObject[] _Dias;
    private Sprite _Cruz;
    private Sprite _Dia;

    private int coste1, coste2, coste3, coste4;

    private void Awake() {
        _Dia = Resources.Load<Sprite>("Sprites/Calendario/Dia");
        _Cruz = Resources.Load<Sprite>("Sprites/Calendario/Cruz");
    }

    private void Start() {
        CalcularCostes();
        ActualizarTextoDia();

        if(EstadoJuego.EdJ._Day == 1 && EstadoJuego.EdJ._Month == 1 && EstadoJuego.EdJ._Year == 1){
            _Dias[EstadoJuego.EdJ._Day-1].GetComponentInChildren<Image>().color = new Color(0,255,0,255);
        }else{
            CargarCalendario();
        }
    }

    private void ActualizarTextoDia(){
        transform.Find("Fecha").Find("Day").GetComponentInChildren<Text>().text = transform.GetComponentInParent<TextosJuego>().GetTexto(1) + " " + EstadoJuego.EdJ._Day.ToString();
        transform.Find("Fecha").Find("Month").GetComponentInChildren<Text>().text = transform.GetComponentInParent<TextosJuego>().GetTexto(2) + " " + EstadoJuego.EdJ._Month.ToString();
        transform.Find("Fecha").Find("Year").GetComponentInChildren<Text>().text = transform.GetComponentInParent<TextosJuego>().GetTexto(3) + " " + EstadoJuego.EdJ._Year.ToString();
        transform.parent.Find("Calendario").Find("Titulo").Find("Month").GetComponent<Text>().text = transform.GetComponentInParent<TextosJuego>().GetTexto(2) + " " + EstadoJuego.EdJ._Month.ToString();
        transform.parent.Find("Calendario").Find("Titulo").Find("Year").GetComponent<Text>().text = transform.GetComponentInParent<TextosJuego>().GetTexto(3) + " " + EstadoJuego.EdJ._Year.ToString();
        transform.parent.Find("Calendario").Find("Pagos").Find("Pago01").GetComponent<Text>().text = coste1.ToString() + " $";
        transform.parent.Find("Calendario").Find("Pagos").Find("Pago02").GetComponent<Text>().text = coste2.ToString() + " $";
        transform.parent.Find("Calendario").Find("Pagos").Find("Pago03").GetComponent<Text>().text = coste3.ToString() + " $";
        transform.parent.Find("Calendario").Find("Pagos").Find("Pago04").GetComponent<Text>().text = coste4.ToString() + " $";
    }

    private void CargarCalendario(){
        for (int i = 1; i < EstadoJuego.EdJ._Day; i++){
            _Dias[i-1].GetComponentInChildren<Image>().sprite = _Cruz;
            _Dias[i-1].GetComponentInChildren<Image>().color = new Color(255,255,255,255);
            _Dias[i].GetComponentInChildren<Image>().color = new Color(0,255,0,255);
        }
    }

    public void SumarDia(){
        if(RevisarEstadoDias()){
            if(EstadoJuego.EdJ._Day == 28){
                if(EstadoJuego.EdJ._Month == 12){
                    EstadoJuego.EdJ._Year++;
                    EstadoJuego.EdJ._Month = 1;
                    EstadoJuego.EdJ._Day = 1;
                }else{
                    EstadoJuego.EdJ._Month++;
                    EstadoJuego.EdJ._Day = 1;
                }
                    for (int i = 0; i < 28; i++){
                        _Dias[i].GetComponentInChildren<Image>().sprite = _Dia;
                        _Dias[i].GetComponentInChildren<Image>().color = new Color(255,255,255,255);
                    }
                    _Dias[0].GetComponentInChildren<Image>().color = new Color(0,255,0,255);
            }else{
                TacharDias();
                EstadoJuego.EdJ._Day++;
            }
            CalcularCostes();
            ActualizarTextoDia();
            EstadoJuego.EdJ.Guardar();
        }else{
            EstadoJuego.EdJ.FinalJuego = "Game Over";
            SceneManager.LoadScene("Final del Juego");
        }
    }

    private void TacharDias(){
        _Dias[EstadoJuego.EdJ._Day-1].GetComponentInChildren<Image>().sprite = _Cruz;
        _Dias[EstadoJuego.EdJ._Day-1].GetComponentInChildren<Image>().color = new Color(255,255,255,255);
        _Dias[EstadoJuego.EdJ._Day].GetComponentInChildren<Image>().color = new Color(0,255,0,255);
    }

    private bool RevisarEstadoDias(){
        if(EstadoJuego.EdJ._Day == 7){
            if(Dinero.dinero.ObtenerDinero() >= coste1){
                Dinero.dinero.VariarDinero(-coste1);
            }else{
                return false;
            }
        }else if(EstadoJuego.EdJ._Day == 14){
            if(Dinero.dinero.ObtenerDinero() >= coste2){
                Dinero.dinero.VariarDinero(-coste2);
            }else{
                return false;
            }
        }else if(EstadoJuego.EdJ._Day == 21){
            if(Dinero.dinero.ObtenerDinero() >= coste3){
                Dinero.dinero.VariarDinero(-coste3);
            }else{
                return false;
            }
        }else if( EstadoJuego.EdJ._Day == 28){
            if(Dinero.dinero.ObtenerDinero() >= coste4){
                Dinero.dinero.VariarDinero(-coste4);
            }else{
                return false;
            }
        }
        return true;
    }

    public void OnPointerDown(PointerEventData eventData){
        ControlBotones.controlBotones.verCalendario();
    }

    private void CalcularCostes(){
        coste1 = (EstadoJuego.EdJ._Year - 1) * 1200 + (EstadoJuego.EdJ._Month - 1) * 100 + 25;
        coste2 = (EstadoJuego.EdJ._Year - 1) * 1200 + (EstadoJuego.EdJ._Month - 1) * 100 + 50;
        coste3 = (EstadoJuego.EdJ._Year - 1) * 1200 + (EstadoJuego.EdJ._Month - 1) * 100 + 75;
        coste4 = (EstadoJuego.EdJ._Year - 1) * 1200 + (EstadoJuego.EdJ._Month - 1) * 100 + 100;
    }
}
