using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class contadorMonedas : MonoBehaviour
{
    public static float puntos;
    private TextMeshProUGUI textMesh;


    void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
    }


    void Update()
    {
        textMesh.text = puntos.ToString("0");
    }

    //metodo que suma la cantidad de moendas
    public void SumarPuntos(float puntosEntrada) 
    {
        puntos += puntosEntrada;
    }
    
}
