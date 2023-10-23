using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapScrolling : MonoBehaviour
{
    public float scrollSpeed = 1.0f; // Velocidad de desplazamiento del mapa.
    public float repeatPosition = -20.0f; // Posici�n en la que el mapa se reiniciar�.

    void Update()
    {
        // Obt�n la velocidad actual del jugador (ajusta esto seg�n tu juego).
        float playerSpeed = 4.0f;

        // Calcula la cantidad de desplazamiento del mapa.
        float scrollAmount = playerSpeed * scrollSpeed * Time.deltaTime;

        // Mueve el objeto vac�o del mapa en la direcci�n opuesta al movimiento del jugador.
        transform.Translate(Vector3.left * scrollAmount);

        // Comprueba si el objeto vac�o ha alcanzado la posici�n de reinicio.
        if (transform.position.x <= repeatPosition)
        {
            // Restablece la posici�n del objeto vac�o al punto inicial para repetir el mapa.
            transform.position = new Vector3(0, transform.position.y, transform.position.z);
        }
    }
}
