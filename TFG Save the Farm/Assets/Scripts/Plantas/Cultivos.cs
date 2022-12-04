using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Cultivos : MonoBehaviour, IPointerClickHandler{

    private string _Nombre;
    private Sprite _Imagen;
    
    private int _PuntosCrecimiento;
    private int _PuntosParaCosecha;
    
    private int _ProbabilidadSeguirRegada;
    private int _CantidadCosechaMin;
    private int _CantidadCosechaMax;  
    private bool _CosechaReiterativa;
    private int _TiempoCosechaReiterativa;

    public int _CantidadSemillas;
    private int _CantidadVegetal;
    private float _PrecioSemillas;
    private float _PrecioVenta;

    public string Nombre { get => _Nombre; set => _Nombre = value; }
    public Sprite Imagen { get => _Imagen; set => _Imagen = value; }
    public int PuntosParaCosecha { get => _PuntosParaCosecha; set => _PuntosParaCosecha = value; }
    public int PuntosCrecimiento { get => _PuntosCrecimiento; set => _PuntosCrecimiento = value; }
    public int ProbabilidadSeguirRegada { get => _ProbabilidadSeguirRegada; set => _ProbabilidadSeguirRegada = value; }
    public int CantidadCosechaMax { get => _CantidadCosechaMax; set => _CantidadCosechaMax = value; }
    public int CantidadCosechaMin { get => _CantidadCosechaMin; set => _CantidadCosechaMin = value; }
    public bool CosechaReiterativa { get => _CosechaReiterativa; set => _CosechaReiterativa = value; }
    public int TiempoCosechaReiterativa { get => _TiempoCosechaReiterativa; set => _TiempoCosechaReiterativa = value; }
    public int CantidadSemillas { get => _CantidadSemillas; set => _CantidadSemillas = value; }
    public int CantidadVegetal { get => _CantidadVegetal; set => _CantidadVegetal = value; }
    public float PrecioSemillas { get => _PrecioSemillas; set => _PrecioSemillas = value; }
    public float PrecioVenta { get => _PrecioVenta; set => _PrecioVenta = value; }
    

    public void OnPointerClick(PointerEventData eventData){
        ControlBotones.controlBotones.getTiendaHortalizas().GetComponent<Tienda_Hortalizas>().ActualizarTextoMenu02(this);
    }

    public void ActualizarTextoMenu01(){
        transform.Find("Sprite").GetComponent<Image>().sprite = Imagen;
        transform.Find("Semillas").GetComponent<Text>().text = CantidadSemillas.ToString();
        transform.Find("Cantidad").GetComponent<Text>().text = CantidadVegetal.ToString();
        transform.Find("Nombre").GetComponent<Text>().text = Nombre;
    }

    

    
}