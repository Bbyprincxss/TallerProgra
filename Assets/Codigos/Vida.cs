using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vida : MonoBehaviour
{

    [SerializeField] private int vida;

    [SerializeField] private int maximaVida;

    // Start is called before the first frame update
    void Start()
    {
        vida = maximaVida;


    }

    public void RecibirDanio(int danio) 
    {
        vida -= danio;
        if (vida <= 0) 
        {
            Destroy(gameObject);
        }
    }

    public void Curar(int curacion)
    {
        if ((vida + curacion) > maximaVida)
        {
            vida = maximaVida;
        }
        else {
            vida += curacion; 
        }
    }


}
