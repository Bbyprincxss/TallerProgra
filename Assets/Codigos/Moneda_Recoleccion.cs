using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moneda_Recoleccion : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float cantidadPuntos;
    [SerializeField] private contadorMonedas contador;
    [SerializeField] private GameObject efecto;
    public AudioClip sonidoMoneda;
    

    void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.CompareTag("Jugador")) 
        {
            contador.SumarPuntos(cantidadPuntos);
            AudioSource.PlayClipAtPoint(sonidoMoneda, transform.position);
            Destroy(gameObject);
        }
    }


}
