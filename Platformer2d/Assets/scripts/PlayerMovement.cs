using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float Salto = 0;
    private Rigidbody2D personaje;

    // Start is called before the first frame update
    private void Start()
    {
        personaje = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        //float directionX = Input.GetAxis("Horizontal");
        float directionX = Input.GetAxisRaw("Horizontal"); // Quita el movimiento tipo "hielo" al caminar
        personaje.velocity = new Vector2(directionX * 7f, personaje.velocity.y);


        if (Input.GetKeyDown(KeyCode.Space))
        {
            // El Rigidbody2D se saca de la jerarquia al que pertenese el objeto sobre el que esta el script, en este caso Square(player)
            // La diferencia entre los 2 es la cantidad de valores, hay que calibrarlo con la "gravity scale" y el "Salto" (Fuerza que se aplica)

            //GetComponent<Rigidbody2D>().AddForce(new Vector2(0, Salto));
            personaje.velocity = new Vector2(personaje.velocity.x, Salto);
        }
    }
}
