using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Perro : MonoBehaviour
{
    private Rigidbody2D rb2d;

    [Header("Movimiento")]

    public float fuerzaGolpe;

    private float movimientoHoizontal = 0f;

    [SerializeField] private float velocidadDeMovimiento;

    [Range(0, 0.3f)][SerializeField] private float suavizadoDeMovimiento;

    private Vector3 velocidad = Vector3.zero;

    private bool mirandoDer = true;

    [Header("Salto")]

    [SerializeField] private float fuerzaDeSalto;

    [SerializeField] private LayerMask queEsSuelo; //identificar superficie

    [SerializeField] private Transform controladorSuelo; 

    [SerializeField] private Vector3 dimensionesCaja; //dimension si se esta en el suelo o no

    [SerializeField] private bool enSuelo;

    private bool salto = false;

    [Header("Animacion")]
    private Animator animator;


    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        movimientoHoizontal = Input.GetAxisRaw("Horizontal") * velocidadDeMovimiento;
        Saltar();
        animator.SetFloat("Horizontal", Mathf.Abs(movimientoHoizontal));
        animator.SetFloat("VelocidadY", rb2d.velocity.y);


    }

    private void FixedUpdate()
    {
        //enSuelo = Physics2D.OverlapBox(controladorSuelo.position, dimensionesCaja, 0f, queEsSuelo);
        animator.SetBool("enSuelo", enSuelo);
        Mover(movimientoHoizontal * Time.fixedDeltaTime, salto);

        salto = false;

    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("suelo"))
        {
            enSuelo = true;
            salto = false;
        }
    }

    private void Mover(float mover, bool saltar)
    {
        Vector3 velocidadO = new Vector2(mover, rb2d.velocity.y);

        rb2d.velocity = Vector3.SmoothDamp(rb2d.velocity, velocidadO, ref velocidad, suavizadoDeMovimiento);

        if (mover > 0 && !mirandoDer)
        {
            Girar();
        }
        else if (mover < 0 && mirandoDer)
        {
            Girar();
        }

    }

    public void Saltar()
    {
        if(Input.GetKeyDown(KeyCode.Space) && enSuelo)
        {
            rb2d.AddForce(new Vector2(0f,fuerzaDeSalto),ForceMode2D.Impulse);
            enSuelo = false;
            salto = true;
        }
    }

    private void Girar()
    {
        mirandoDer = !mirandoDer;
        Vector3 escala = transform.localScale;
        escala.x *= -1;
        transform.localScale = escala;

    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.green;
        Gizmos.DrawCube(controladorSuelo.position, dimensionesCaja);
    }

    public void aplicarGolpe()
    {
        Vector2 direccionGolpe;

        if (rb2d.velocity.x > 0) 
        {
            direccionGolpe = new Vector2(-1, 1);
        }
        else
        {
            direccionGolpe = new Vector2(1, 1);
        }

        rb2d.AddForce(direccionGolpe * fuerzaGolpe);
    }


}

