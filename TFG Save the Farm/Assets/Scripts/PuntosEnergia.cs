using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PuntosEnergia : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler{
    
    [SerializeField] private Image barraPE;
    [SerializeField] private Text textoPE;
    [SerializeField] private float llenadoBarra;
    [SerializeField] private int actualPE;
    [SerializeField] private int maxPE;

    private void Start(){
        //barraPE = transform.Find("Barra PE").GetComponent<Image>();
        //textoPE = transform.Find("Fondo Barra").Find("Vida").Find("Texto Vida").GetComponent<Text>();
        llenadoBarra = (float)actualPE / (float)maxPE;
    }

    
    private void Update(){
        PintarBarras();
    }

    private void PintarBarras(){
        if(llenadoBarra != barraPE.fillAmount){
            barraPE.fillAmount = Mathf.Lerp(barraPE.fillAmount, llenadoBarra, Time.deltaTime * 5);
        }
        textoPE.text = (actualPE + " / " + maxPE);
    }

    public void OnPointerEnter(PointerEventData eventData){
        textoPE.gameObject.SetActive(true);
    }
    public void OnPointerExit(PointerEventData eventData){
        textoPE.gameObject.SetActive(false);
    }



    public bool RevisarPE(int variacion){
        if(actualPE + variacion < 0){
            return false;
        }else{
            return true;
        }
    }

    public void VariarPE(int variacion){
        actualPE = actualPE + variacion;
        llenadoBarra = (float)actualPE / (float)maxPE;
    }



    // Variables ya escritas bien:

    // Función para llenar los PE hasta su valor máximo
    public void LlenarPE(){
        actualPE = maxPE;
        llenadoBarra = (float)actualPE / (float)maxPE;
    }
}
