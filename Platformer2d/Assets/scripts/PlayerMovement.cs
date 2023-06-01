using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float Salto = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // El Rigidbody2D se saca de la jerarquia al que pertenese el objeto sobre el que esta el script, en este caso Square(player)
            // La diferencia entre los 2 es la cantidad de valores, hay que calibrarlo con la "gravity scale" y el "Salto" (Fuerza que se aplica)

            //GetComponent<Rigidbody2D>().AddForce(new Vector2(0, Salto));
            GetComponent<Rigidbody2D>().velocity = new Vector3(0, Salto, 0);
        }
    }
}
