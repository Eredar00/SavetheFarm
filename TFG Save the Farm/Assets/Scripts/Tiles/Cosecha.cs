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
        vacio = Resources.Load<Sprite>("Sprites/Plantas/vacio");
        tomate = Resources.Load<Sprite>("Sprites/Plantas/Tomate");
        patata = Resources.Load<Sprite>("Sprites/Plantas/Patata");
        zanahoria = Resources.Load<Sprite>("Sprites/Plantas/Zanahoria");
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
        Dinero.dinero.VariarDinero(numeroCosecha);
    }


    
}
