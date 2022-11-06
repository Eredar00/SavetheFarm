using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Planta : MonoBehaviour
{
    public enum TipoPlanta{
        Tomate,
        Patata,
        Zanahoria
    }

    [SerializeField] private int puntosCrecimiento;
    [SerializeField] private int puntosMax;
    [SerializeField] private TipoPlanta tipoPlanta;
    [SerializeField] private bool regada;
    
    private Sprite vacio, planta_01, planta_02, planta_03, planta_04, planta_05;

    private void Start() {
        vacio = Resources.Load<Sprite>("Sprites/Plantas/vacio");
        planta_01 = Resources.Load<Sprite>("Sprites/Plantas/Planta_01");
        planta_02 = Resources.Load<Sprite>("Sprites/Plantas/Planta_02");
        planta_03 = Resources.Load<Sprite>("Sprites/Plantas/Planta_03");
        planta_04 = Resources.Load<Sprite>("Sprites/Plantas/Planta_04");
        planta_05 = Resources.Load<Sprite>("Sprites/Plantas/Planta_05");
        puntosCrecimiento = 0;
        puntosMax = 5;
        CalcularNivel();
        
    }

   

    private void CalcularNivel(){
        if(puntosCrecimiento == 0){
            transform.GetComponent<SpriteRenderer>().sprite = vacio;
        }else{
            int nivelCrecimiento = (int)((float)puntosCrecimiento / (float)puntosMax * 10);
            if(nivelCrecimiento <= 2){
                transform.GetComponent<SpriteRenderer>().sprite = planta_01;
            }else  if(nivelCrecimiento > 02 && nivelCrecimiento <= 04 ){
                transform.GetComponent<SpriteRenderer>().sprite = planta_02;
            }else  if(nivelCrecimiento > 04 && nivelCrecimiento <= 06 ){
                transform.GetComponent<SpriteRenderer>().sprite = planta_03;
            }else  if(nivelCrecimiento > 06 && nivelCrecimiento <= 08 ){
                transform.GetComponent<SpriteRenderer>().sprite = planta_04;
            }else  if(nivelCrecimiento > 08){
                transform.GetComponent<SpriteRenderer>().sprite = planta_05;
            }
            if(puntosCrecimiento == puntosMax){
                GetComponentInParent<Tile>().GetComponentInChildren<Cosecha>().PonerCosecha();
                GetComponentInParent<Tile>().ChangeTileState(TileState.Cosecha_Seca);
            }
        }
        
    }

    public bool EstaRegada(){
        return regada;
    }

    public void RegarPlanta(){
        regada = true;
    }

    public void SecarPlanta(){
        regada = false;
    }

    public void CrecerPlanta(){
        puntosCrecimiento++;
        CalcularNivel();
    }

    public void EliminarPlanta(){
        puntosCrecimiento = 0;
        CalcularNivel();
    }
}
