using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hortalizas : MonoBehaviour{

    public static Hortalizas hortalizas;

    [SerializeField] Cultivos[] _Cultivos;

    private void Awake() {
        hortalizas = this;
    }

    public Cultivos GetCultivoPorPosicion(int posicion){return _Cultivos[posicion];}

    public Cultivos[] GetCultivos(){return _Cultivos;}


}
