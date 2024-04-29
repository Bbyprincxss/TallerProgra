using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class VidaJugador : MonoBehaviour
{
    [SerializeField] private float vida;
    private Perro movimientoJugador;
    [SerializeField] private float tiempoPerdidaControl;
    private Animator animator;
    public AudioClip sonidoHerida;

    private void Start() 
    {
        movimientoJugador = GetComponent<Perro>();
        animator = GetComponent<Animator>();
    }


    public void TomarDanio(float danio) 
    {
        vida += danio;
    }

    public void TomarDanio(float danio, Vector2 posicion) 
    {
        vida -= danio;
        if (vida > 0) 
        {
            animator.SetTrigger("Golpe");
            AudioSource.PlayClipAtPoint(sonidoHerida, transform.position);
            StartCoroutine(PerderControl());
            movimientoJugador.Rebote(posicion);
        }
        else
        {
            animator.SetTrigger("Muerte");
            Application.Quit();
        }
        
    }

    private IEnumerator PerderControl() 
    {
        movimientoJugador.sePuedeMover = false;
        yield return new WaitForSeconds(tiempoPerdidaControl);
        movimientoJugador.sePuedeMover = true; ;
    }
}
