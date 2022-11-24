using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hortalizas : MonoBehaviour{

    public static Hortalizas hortalizas;

    [SerializeField] Vegetal[] vegetales;

    private void Awake() {
        hortalizas = this;
    }

    public Vegetal getVegetal(int posicion){
        return vegetales[posicion];
    }


}
