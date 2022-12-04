using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opciones : MonoBehaviour{

    public static Opciones opciones;

    [SerializeField] private String idioma = "ESP";
    [SerializeField] Textos prr;

    private void Awake() {
        DontDestroyOnLoad(transform.gameObject);
        opciones = this;
    }

    private void Start() {
        Prr = transform.GetComponent<Textos>();
    }

    public string Idioma { get => idioma; set => idioma = value; }
    public Textos Prr { get => prr; set => prr = value; }
}
