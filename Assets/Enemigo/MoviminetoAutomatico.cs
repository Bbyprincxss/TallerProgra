using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoviminetoAutomatico : MonoBehaviour
{
    [SerializeField] private float velocidad;

    [SerializeField] private Transform controladorSueloEnemigo;

    [SerializeField] private float distancia;
    [SerializeField] private bool moviminetoDerecha;
   
    private Rigidbody2D rigidbody2;

    private void Start()
    {
        rigidbody2 = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        RaycastHit2D infoSuelo = Physics2D.Raycast(controladorSueloEnemigo.position, Vector2.down, distancia);

        rigidbody2.velocity = new Vector2(velocidad, rigidbody2.velocity.y);

        //si no se encunetra, gire
        if(infoSuelo == false) {

            //girar
            Girar();
        }

    }

    private void Girar()
    {
        moviminetoDerecha = !moviminetoDerecha;
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
        //se mueva en direccion contraria
        velocidad *= -1;
    }

    private void OnDrawGizmos()
    {
       Gizmos.color = Color.red;
        Gizmos.DrawLine(controladorSueloEnemigo.transform.position, controladorSueloEnemigo.transform.position + Vector3.down * distancia);
    }
}
