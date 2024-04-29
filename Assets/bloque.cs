using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bloque : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.CompareTag("Jugador")) 
        {
            other.gameObject.GetComponent<VidaJugador>().TomarDanio(34, other.GetContact(0).normal);
        }
    }
}
