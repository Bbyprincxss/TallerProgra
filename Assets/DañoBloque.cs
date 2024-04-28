using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DañoBloque : MonoBehaviour
{
    public float velocidadCaida = 5f;
    public float tiempoDesaparicion = 2f;
    private LayerMask capaPersonaje;
    private bool cayendo = false;
    private bool tocandoSuelo = false;

    private void Update()
    {
        if (!cayendo)
        {
            // Verificar si el personaje está debajo del bloque
            Collider2D personaje = Physics2D.OverlapCircle(transform.position, 1f, capaPersonaje);
            if (personaje != null)
            {
                // Comenzar a caer si se detecta el personaje debajo
                cayendo = true;
                GetComponent<Rigidbody2D>().gravityScale = 1f;
            }
        }

        if (cayendo && !tocandoSuelo)
        {
            // Mover el bloque hacia abajo
            transform.Translate(Vector3.down * velocidadCaida * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Verificar si el bloque ha tocado el suelo
        if (collision.gameObject.CompareTag("suelo"))
        {
            tocandoSuelo = true;
            // Después de un tiempo, hacer desaparecer el bloque
            Invoke("Desaparecer", tiempoDesaparicion);
        }
    }

    private void Desaparecer()
    {
        Destroy(gameObject);
    }

}
