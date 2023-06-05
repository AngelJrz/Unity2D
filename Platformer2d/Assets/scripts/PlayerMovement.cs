using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float Salto = 0; // El Serialize es para encapsular el atributo pero que siga apareciendo en el editor
    private Rigidbody2D personaje;
    private Animator animacionDePersonaje;
    private SpriteRenderer spriteDePersonaje;
    [SerializeField] private AudioSource JumpSoundEffect;
    private float directionX;
    private bool puedeSaltarNuevamente;

    private enum AnimationState
    {
        IDLE,
        RUNNING,
        JUMPING,
        FALLING 
    }

    private AnimationState state = AnimationState.IDLE;

    // Start is called before the first frame update
    private void Start()
    {
        personaje = GetComponent<Rigidbody2D>();
        animacionDePersonaje = GetComponent<Animator>();
        spriteDePersonaje = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        RevisarAccionesDeJugador();
        RenderDeAnimacion();
    }

    private void RevisarAccionesDeJugador()
    {
        //float directionX = Input.GetAxis("Horizontal");
        directionX = Input.GetAxisRaw("Horizontal"); // Quita el movimiento tipo "hielo" al caminar
        personaje.velocity = new Vector2(directionX * 7f, personaje.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            // El Rigidbody2D se saca de la jerarquia al que pertenese el objeto sobre el que esta el script, en este caso Square(player)
            // La diferencia entre los 2 es la cantidad de valores, hay que calibrarlo con la "gravity scale" y el "Salto" (Fuerza que se aplica)

            if (puedeSaltarNuevamente)
            {
                //GetComponent<Rigidbody2D>().AddForce(new Vector2(0, Salto));
                personaje.velocity = new Vector2(personaje.velocity.x, Salto);
                JumpSoundEffect.Play();
                puedeSaltarNuevamente = false;

            }
        }
    }

    private void RenderDeAnimacion()
    {
        if (directionX != 0f) // Es la fuerza aplicada, en este caso si se mueve a los lados
        {
            if (directionX < 0f)
            {
                spriteDePersonaje.flipX = true;
            }
            else
            {
                spriteDePersonaje.flipX = false;
            }

            //animacionDePersonaje.SetBool("estaCorriendo", true);
            state = AnimationState.RUNNING;
        }
        else
        {
            //animacionDePersonaje.SetBool("estaCorriendo", false);
            state = AnimationState.IDLE;
        }

        if (personaje.velocity.y > .1f)
        {
            state = AnimationState.JUMPING;
        }
        else if (personaje.velocity.y < -.1f)
        {
            state = AnimationState.FALLING;
        }

        animacionDePersonaje.SetInteger("state", (int)state);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Suelo")
        {
            puedeSaltarNuevamente = true;
        }
    }
}
