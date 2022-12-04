using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Herramienta : MonoBehaviour, IPointerDownHandler{

    private int _NumeroHerramienta;
    private KeyCode _TeclaHerramienta;
    private Sprite[] _ImagenesHerramienta;
    private string _NombreHerramienta;
    private string _DescripcionHerramienta;
    
    private int _NivelHerramientaPE;
    private int _MaxNivelHerramientaPE;
    private int _NivelHerramientaCasillas;
    private int _MaxNivelHerramientaCasillas;
    
    private int _CosteBasePE;
    private int _CosteHerramientaPE;

    private void Update() {
        if(Input.GetKeyDown(_TeclaHerramienta)){
            if(GameManager.gameManager.pausa == true) return;
            GameManager.gameManager.GetTaller().SetHerramienta(_NumeroHerramienta); 
        }  
    }

    public void OnPointerDown(PointerEventData eventData){
        if(GameManager.gameManager.pausa == true) return;
        GameManager.gameManager.GetTaller().SetHerramienta(_NumeroHerramienta);
    }

    public int NumeroHerramienta { get => _NumeroHerramienta; set => _NumeroHerramienta = value; }
    public KeyCode TeclaHerramienta { get => _TeclaHerramienta; set => _TeclaHerramienta = value; }
    public Sprite[] ImagenesHerramienta { get => _ImagenesHerramienta; set => _ImagenesHerramienta = value; }
    public string NombreHerramienta { get => _NombreHerramienta; set => _NombreHerramienta = value; }
    public string DescripcionHerramienta { get => _DescripcionHerramienta; set => _DescripcionHerramienta = value; }
    public int NivelHerramientaPE { get => _NivelHerramientaPE; set => _NivelHerramientaPE = value; }
    public int MaxNivelHerramientaPE { get => _MaxNivelHerramientaPE; set => _MaxNivelHerramientaPE = value; }
    public int NivelHerramientaCasillas { get => _NivelHerramientaCasillas; set => _NivelHerramientaCasillas = value; }
    public int MaxNivelHerramientaCasillas { get => _MaxNivelHerramientaCasillas; set => _MaxNivelHerramientaCasillas = value; }
    public int CosteBasePE { get => _CosteBasePE; set => _CosteBasePE = value; }
    public int CosteHerramientaPE { get => _CosteHerramientaPE; set => _CosteHerramientaPE = value; }

    public void ActualizarCosteAccionPE(){
        CosteHerramientaPE = CosteBasePE - NivelHerramientaPE;
    }

    public void CambiarImagen(){ 
        transform.Find("Imagen").GetComponent<Image>().sprite = _ImagenesHerramienta[NivelHerramientaCasillas-1]; 
    }

}
