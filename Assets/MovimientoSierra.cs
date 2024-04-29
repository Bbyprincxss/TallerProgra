using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoSierra : MonoBehaviour
{
    
[SerializeField] private float velocidad;
[SerializeField] private Transform controladorSuelo;
[SerializeField] private float distancia;
[SerializeField] private bool movimientoDerecha;

private Rigidbody2D rb;


private void Start()
{
	rb = GetComponent<Rigidbody2D>();
}

private void FixedUpdate()
{
	RaycastHit2D informacionSuelo = Physics2D.Raycast(controladorSuelo.position, Vector2.down, distancia);
	if(informacionSuelo == false)
	{
		Girar();
	}
}

private void Girar()
{
	movimientoDerecha = !movimientoDerecha;
	transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
	velocidad *= -1;
}

private void OnDrawGizmos()
{
	Gizmos.color = Color.red;
	Gizmos.DrawLine(controladorSuelo.transform.position, controladorSuelo.transform.position + Vector3.down * distancia);
}





}
