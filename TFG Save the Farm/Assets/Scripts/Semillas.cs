using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Semillas : MonoBehaviour, IPointerDownHandler{

    public static Semillas semillas;

    public int _NumeroDeCultivo = 0;

    public Text _TextoCantidadSemillas;

    [SerializeField] private Cultivos vegetalPlantar;
    [SerializeField] private TipoVegetal tipoVegetalPlantar;

    private void Awake() {
        semillas = this;
    }

    private void Start() {
        _TextoCantidadSemillas = transform.Find("Numero").GetComponent<Text>();  
        SiguienteSemilla();      
    }

    public void SiguienteSemilla(){
        if(_NumeroDeCultivo == GameManager.gameManager.GetHortalizas().GetCultivos().Length){
            _NumeroDeCultivo = 1;
        }else{
            _NumeroDeCultivo++;
        }
        vegetalPlantar = GameManager.gameManager.GetHortalizas().GetCultivoPorPosicion(_NumeroDeCultivo-1);
        transform.Find("Imagen").GetComponent<Image>().sprite = vegetalPlantar.Imagen;
        ActualizarTextoNumero();
        
        SetTipoVegetalPlantar();
    }

    public void ActualizarTextoNumero(){
        _TextoCantidadSemillas.text = vegetalPlantar.CantidadSemillas.ToString();
    }

    private void SetTipoVegetalPlantar(){
        if(vegetalPlantar == null){tipoVegetalPlantar = TipoVegetal.Ninguno;}
        else if(vegetalPlantar.Nombre == "Tomate"){tipoVegetalPlantar = TipoVegetal.Tomate;}
        else if(vegetalPlantar.Nombre == "Patata"){tipoVegetalPlantar = TipoVegetal.Patata;}
        else if(vegetalPlantar.Nombre == "Zanahoria"){tipoVegetalPlantar = TipoVegetal.Zanahoria;}
    }

    public TipoVegetal GetTipoVegetalPlantar(){return tipoVegetalPlantar;}

    public Cultivos GetVegetalPlantar(){return vegetalPlantar;}

    public int GetNumeroSemillas(){return vegetalPlantar.CantidadSemillas;}

    public void OnPointerDown(PointerEventData eventData){
        SiguienteSemilla();
    }
}
