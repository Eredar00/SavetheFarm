using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Calendario : MonoBehaviour, IPointerDownHandler{
    
    [SerializeField] private Text textoDia;
    [SerializeField] private int dia;
    [SerializeField] GameObject calendario; 
    [SerializeField] GameObject[] dias;
    private Sprite cruz;
    private bool finalJuego;

    private void Start() {
        cruz = Resources.Load<Sprite>("Sprites/Calendario/Cruz");
        calendario.SetActive(false);
        dia = 1;
        ActualizarTextoDia();
        dias[dia-1].GetComponentInChildren<Image>().color = new Color(0,255,0,255);
        finalJuego = false;
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.C)) verCalendario();
    }

    private void ActualizarTextoDia(){
        textoDia.text = "Día " + dia.ToString();
    }

    public void SumarDia(){
        RevisarEstadoDias();
        if(!finalJuego){
            tachar();
            dia++;
            ActualizarTextoDia();
        }
    }

    private void tachar(){
        dias[dia-1].GetComponentInChildren<Image>().sprite = cruz;
        dias[dia-1].GetComponentInChildren<Image>().color = new Color(255,255,255,255);
        dias[dia].GetComponentInChildren<Image>().color = new Color(0,255,0,255);
    }
    
    private void verCalendario(){
        if(calendario.activeSelf){
            calendario.SetActive(false);
        }else{
            calendario.SetActive(true);
        }
    }

    private void RevisarEstadoDias(){
        if(dia == 14){
            if(Dinero.dinero.ObtenerDinero() >= 100){
                Dinero.dinero.VariarDinero(-100);
            }else{
                finalJuego = true;
                SceneManager.LoadScene("Game Over");
            }
        }else if(dia == 28){
            if(Dinero.dinero.ObtenerDinero() >= 200){
                Dinero.dinero.VariarDinero(-200);
                finalJuego = true;
                SceneManager.LoadScene("Ganador");
            }else{
                finalJuego = true;
                SceneManager.LoadScene("Game Over");
            }
        }
    }

    public void OnPointerDown(PointerEventData eventData){
        verCalendario();
    }
}
