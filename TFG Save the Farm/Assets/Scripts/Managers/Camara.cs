using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Este Script es utilizado para controlar las funciones de la cámara del juego. Incorpora las siguientes funciones:
    - Movimiento de la cámara con las teclas WASD y flechas del teclado.
    - Scroll de la cámara con la rueda del ratón.
*/

public class Camara : MonoBehaviour
{
    [SerializeField] private float maxScroll = 10;
    [SerializeField] private float minScroll = 3;
    [SerializeField] private float zoomSize = 6;
    [SerializeField] private float zoomSpeed = 1;

    [SerializeField] private float cameraSpeed = 20;

    void Update()
    {   
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");

        GetComponent<Camera>().transform.position = transform.position + new Vector3(horizontalInput * cameraSpeed * Time.deltaTime, verticalInput * cameraSpeed * Time.deltaTime, 0);
    
        if(scrollInput > 0){
            if(zoomSize > minScroll) zoomSize -= zoomSpeed;
        }
        if(scrollInput < 0){
            if(zoomSize < maxScroll) zoomSize += zoomSpeed;
        }

        GetComponent<Camera>().orthographicSize = zoomSize;
    
    }
}
