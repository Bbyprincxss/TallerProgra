using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaidaBloque : MonoBehaviour
{
    public float tiempoAntesDestruccion = 2f; 

    private bool tocandoPiso = false;
   
   public float distanciaActivación = 5f; 
   
    public Rigidbody2D rb; 

    private Transform jugador; 

    void Start()
    {
        jugador = GameObject.FindGameObjectWithTag("Jugador").transform; 
    }

    void Update()
    {
        
        float distancia = Vector2.Distance(transform.position, jugador.position);

        
        if (distancia <= distanciaActivación)
        {
            
            rb.gravityScale = 1f;
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("suelo"))
        {
            
            tocandoPiso = true;

            
            Invoke("DestruirBloque", tiempoAntesDestruccion);
        }
    }

    void DestruirBloque()
    {
        // Destruye el bloque
        Destroy(gameObject);
    }
}
