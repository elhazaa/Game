using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapScrolling : MonoBehaviour
{
    public float scrollSpeed = 1.0f; // Velocidad de desplazamiento del mapa.
    public float repeatPosition = -20.0f; // Posición en la que el mapa se reiniciará.

    void Update()
    {
        // Obtén la velocidad actual del jugador (ajusta esto según tu juego).
        float playerSpeed = 4.0f;

        // Calcula la cantidad de desplazamiento del mapa.
        float scrollAmount = playerSpeed * scrollSpeed * Time.deltaTime;

        // Mueve el objeto vacío del mapa en la dirección opuesta al movimiento del jugador.
        transform.Translate(Vector3.left * scrollAmount);

        // Comprueba si el objeto vacío ha alcanzado la posición de reinicio.
        if (transform.position.x <= repeatPosition)
        {
            // Restablece la posición del objeto vacío al punto inicial para repetir el mapa.
            transform.position = new Vector3(0, transform.position.y, transform.position.z);
        }
    }
}
