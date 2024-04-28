using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DañoSierra : MonoBehaviour
{

    [SerializeField] private float tiempoEntreDanio;

    private float tiempoSiguienteDanio;

    void OnTriggerStay2D (Collider2D other) 
    {
        if (other.CompareTag("Jugador")) 
        {
            tiempoSiguienteDanio -= Time.deltaTime;

            if (tiempoSiguienteDanio <= 0) 
            {
                other.GetComponent<Vida>().RecibirDanio(1);
                tiempoSiguienteDanio = tiempoEntreDanio;
            }
        }
    }

}
