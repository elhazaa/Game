using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GhostControl : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 1;
    [Header("Objetivo a seguir")]
    public Transform target;
    public int damage = 1;
    void Start()
    {
        GameObject player = GameObject.Find("player");
        if (player != null)
            target = player.transform;

    }

    // Update is called once per frame
    void Update()
    {
        //calculamos la direccion en la cual se debe mover el pteranodon.
        Vector3 v_to_p = (target.position - this.transform.position).normalized;
        //modificamos la posicion en base al vector de direccion
        //la velocidad de movimiento y el tiempo transcurrido
        transform.position = transform.position + (v_to_p * (speed * Time.deltaTime));
        //verificamos el signo en x de v_to_p para voltear el pteranodon al sentido correcto
        Vector3 ls = transform.localScale;
        ls.x = Mathf.Abs(ls.x) * Mathf.Sign(v_to_p.x);
        transform.localScale = ls;
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            //se debe morir el jugador
            //Debug.Log("Perdiste");
            //GM.gm.LooseLevel();

        }
        if (collision.CompareTag("Player"))
        {
            // Aplicar daño al personaje principal
            // Esto podría ser parte de un sistema de salud o puntuación del personaje principal
            // Asegúrate de que el personaje principal tenga un Tag llamado "PersonajePrincipal"
            Bandit player = collision.GetComponent<Bandit>();
            if (player != null)
            {
                player.RecibirDano(damage);
            }
        }
    }

}
