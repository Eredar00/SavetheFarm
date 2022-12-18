using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalJuegoSceneManager : MonoBehaviour{

    [SerializeField] private GameObject _Ganador;
    [SerializeField] private GameObject _GameOver;

    private void Awake() {
        EstadoJuego.EdJ.Guardar();
        if(EstadoJuego.EdJ.FinalJuego == "Game Over"){
            _GameOver.SetActive(true);
            _Ganador.SetActive(false);
        }
        if(EstadoJuego.EdJ.FinalJuego == "Win"){
            _GameOver.SetActive(false);
            _Ganador.SetActive(true);
        }
    }
}
