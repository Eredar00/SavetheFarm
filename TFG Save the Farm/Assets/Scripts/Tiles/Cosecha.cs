using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cosecha : MonoBehaviour
{
    public enum TipoCosecha{
        Tomate,
        Patata,
        Zanahoria
    }

    [SerializeField] private int numeroCosecha;
    [SerializeField] private bool reiterativa;
    [SerializeField] private TipoCosecha tipoPlanta;
    [SerializeField] private int cadaCuantoCosecha;

    private Sprite vacio, tomate, patata, zanahoria;

    private void Start() {
        vacio = Resources.Load<Sprite>("Sprites/Hortalizas/vacio");
        tomate = Resources.Load<Sprite>("Sprites/Hortalizas/Tomate");
        patata = Resources.Load<Sprite>("Sprites/Hortalizas/Patata");
        zanahoria = Resources.Load<Sprite>("Sprites/Hortalizas/Zanahoria");
        numeroCosecha = 2;
        reiterativa = false;
        tipoPlanta = TipoCosecha.Tomate;
        cadaCuantoCosecha = 0;
    }

    public void PonerCosecha(){
        transform.GetComponent<SpriteRenderer>().sprite = tomate;
    }

    public void QuitarCosecha(){
        transform.GetComponent<SpriteRenderer>().sprite = vacio;
        if(tipoPlanta == TipoCosecha.Tomate){Hortalizas.hortalizas.getVegetal(0).VariarCantidadVegetal(numeroCosecha);}
        if(tipoPlanta == TipoCosecha.Patata){Hortalizas.hortalizas.getVegetal(1).VariarCantidadVegetal(numeroCosecha);}
        if(tipoPlanta == TipoCosecha.Zanahoria){Hortalizas.hortalizas.getVegetal(2).VariarCantidadVegetal(numeroCosecha);}
    }
}
