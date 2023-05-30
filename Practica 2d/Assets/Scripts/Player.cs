using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Animator animator;
    public float jumpForce;
    private Rigidbody2D rigidbody2d;
    public GameManager manager;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (manager.start == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                animator.SetBool("IsJumping", true);
                rigidbody2d.AddForce(new Vector2(0, jumpForce));
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.tag == "Floor")
        {
            animator.SetBool("IsJumping", false);
        }

        if (collision.gameObject.tag == "obstacle")
        {
            manager.GameOver = true;
        }
    }
}
