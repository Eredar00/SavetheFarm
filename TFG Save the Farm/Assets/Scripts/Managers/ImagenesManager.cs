using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImagenesManager : MonoBehaviour{

    public static ImagenesManager iMan;

    [SerializeField] private Sprite[] _ImagenesPlanta;
    [SerializeField] private Sprite[] _ImagenesCasilla;
    [SerializeField] private Sprite[] _ImagenesCosecha;

    [SerializeField] private Sprite[] _ImagenesPala;
    [SerializeField] private Sprite[] _ImagenesBolsa;
    [SerializeField] private Sprite[] _ImagenesRegadera;
    [SerializeField] private Sprite[] _ImagenesCesta;
    [SerializeField] private Sprite[] _ImagenesPapelera;
    [SerializeField] private Sprite[] _ImagenesLupa;

    private void Awake() {
        iMan = this;
    }

    public Sprite[] GetImagenesPlanta(){return _ImagenesPlanta;}
    public Sprite[] GetImagenesCasilla(){return _ImagenesCasilla;}
    public Sprite[] GetImagenesCosecha(){return _ImagenesCosecha;}

    public Sprite[] GetImagenesPala(){return _ImagenesPala;}
    public Sprite[] GetImagenesBolsa(){return _ImagenesBolsa;}
    public Sprite[] GetImagenesRegadera(){return _ImagenesRegadera;}
    public Sprite[] GetImagenesCesta(){return _ImagenesCesta;}
    public Sprite[] GetImagenesPapelera(){return _ImagenesPapelera;}
    public Sprite[] GetImagenesLupa(){return _ImagenesLupa;}
}
