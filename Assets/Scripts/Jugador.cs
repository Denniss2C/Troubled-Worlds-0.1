using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    private GameManager gameManager;
    private Rigidbody2D rigidbody2d;
    public float fuerzaSalto;
    private bool salto = false;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && salto == false)
        {
            animator.SetBool("estasaltando", true);
            rigidbody2d.AddForce(new Vector2(0, fuerzaSalto));
            salto = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "plataforma01")
        {
            animator.SetBool("estasaltando", false);
            salto = false;
        }
    }

}
