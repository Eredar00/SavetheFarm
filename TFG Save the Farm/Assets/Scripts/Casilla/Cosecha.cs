using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cosecha : MonoBehaviour{

    private Sprite[] _ImagenesCosecha;

    private void Start() {
        _ImagenesCosecha = ImagenesManager.iMan.GetImagenesCosecha();
        SetImagenSprite(0);
    }

    private void SetImagenSprite(int numero){transform.GetComponent<SpriteRenderer>().sprite = _ImagenesCosecha[numero];}

    public void PonerCosecha(TipoVegetal tipo){
        if(tipo == TipoVegetal.Tomate){SetImagenSprite(1);}
        if(tipo == TipoVegetal.Patata){SetImagenSprite(2);}
        if(tipo == TipoVegetal.Zanahoria){SetImagenSprite(3);}
        if(tipo == TipoVegetal.Naranja){SetImagenSprite(4);}
        if(tipo == TipoVegetal.Arroz){SetImagenSprite(5);}
        if(tipo == TipoVegetal.Trigo){SetImagenSprite(6);}
    }

    public void RecolectarCosecha(TipoVegetal tipo, int cantidad){
        SetImagenSprite(0);
        if(tipo == TipoVegetal.Tomate){Hortalizas.hortalizas.GetCultivoPorPosicion(0).SumarVegetales(cantidad);}
        else if(tipo == TipoVegetal.Patata){Hortalizas.hortalizas.GetCultivoPorPosicion(1).SumarVegetales(cantidad);}
        else if(tipo == TipoVegetal.Zanahoria){Hortalizas.hortalizas.GetCultivoPorPosicion(2).SumarVegetales(cantidad);}
        else if(tipo == TipoVegetal.Naranja){Hortalizas.hortalizas.GetCultivoPorPosicion(3).SumarVegetales(cantidad);}
        else if(tipo == TipoVegetal.Arroz){Hortalizas.hortalizas.GetCultivoPorPosicion(4).SumarVegetales(cantidad);}
        else if(tipo == TipoVegetal.Trigo){Hortalizas.hortalizas.GetCultivoPorPosicion(5).SumarVegetales(cantidad);}
    }

}
