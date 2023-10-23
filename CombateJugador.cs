using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombateJugador : MonoBehaviour
{
    [SerializeField] private float vida;
    [SerializeField] private float maximoVida;
    [SerializeField] private BarradeVida barradeVida;

     private void Start()
    {
        vida = maximoVida;
        barradeVida.InicializarBarraDeVida(vida);
    }

    public void TomarDa�o(float da�o)
    {
        vida -= da�o;
        barradeVida.CambiarVidaActual(vida);
        if (vida < 0)
        {
            Destroy(gameObject);
        }
    }

    public void Curar(float Curacion)
    {
        if((vida + Curacion) > maximoVida)
        {
            vida = maximoVida;
        }
    }
}
