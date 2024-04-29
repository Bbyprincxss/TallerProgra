using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        animator.SetTrigger("Golpe");
        AudioSource.PlayClipAtPoint(sonidoHerida, transform.position);
        StartCoroutine(PerderControl());
        movimientoJugador.Rebote(posicion);
    }

    private IEnumerator PerderControl() 
    {
        movimientoJugador.sePuedeMover = false;
        yield return new WaitForSeconds(tiempoPerdidaControl);
        movimientoJugador.sePuedeMover = true; ;
    }
}
