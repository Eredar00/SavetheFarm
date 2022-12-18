using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorInstrucciones : MonoBehaviour{

    [SerializeField] private GameObject[] _Paginas;
    private GameObject _Siguiente;
    private GameObject _Anterior;
    private int _NumeroPagina;

    private void Awake() {
        _Siguiente = transform.Find("Siguiente").gameObject;
        _Anterior = transform.Find("Anterior").gameObject;
    }

    private void Start() {
        OcultarPaginas();
        _Paginas[0].SetActive(true);
        _NumeroPagina = 0;
        _Anterior.SetActive(false);
    }

    private void OcultarPaginas(){
        for (int i = 0; i < _Paginas.Length; i++){
            _Paginas[i].SetActive(false);
        }
    }

    public void SiguientePagina(){
        OcultarPaginas();
        _Paginas[_NumeroPagina + 1].SetActive(true);
        _NumeroPagina++;
        _Anterior.SetActive(true);

        if((_NumeroPagina + 1) == _Paginas.Length){
            _Siguiente.SetActive(false);
        }
    }

    public void AnteriorPagina(){
        OcultarPaginas();
        _Paginas[_NumeroPagina - 1].SetActive(true);
        _NumeroPagina--;
        _Siguiente.SetActive(true);
        
        if(_NumeroPagina == 0){
            _Anterior.SetActive(false);
        }
    }
}
