using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class verificarMonedas : MonoBehaviour
{

// Cantidad de monedas necesarias para abrir el cofre
    public int coinsRequired = 14; 

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.CompareTag("Jugador")) 
        {
             if (contadorMonedas.puntos == coinsRequired)
        {
            
            print("¡Cofre abierto!");
            print("¡TERMINO EL MEJRO JUEGO DEL MUNDO!");
            
            
        }
        else
        {
            
            Debug.Log("¡No tienes suficientes monedas para abrir este cofre!");
        }
        }
    }

   



}
