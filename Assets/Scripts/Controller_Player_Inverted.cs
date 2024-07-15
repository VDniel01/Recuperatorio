using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller_Player_Inverted : Controller_Player
{
    protected override void Start()
    {
        base.Start();
        rb.useGravity = false; // Desactivar la gravedad predeterminada
    }

    protected override void FixedUpdate()
    {
        if (GameManager.actualPlayer == playerNumber)
        {
            Movement();
            // Aplicamos una fuerza continua hacia arriba para simular gravedad invertida
            rb.AddForce(new Vector3(0, 30f, 0));
        }
        base.FixedUpdate();
    }

    protected override void Update()
    {
        if (GameManager.actualPlayer == playerNumber)
        {
            Jump();
            canMoveLeft = !SomethingLeft();
            canMoveRight = !SomethingRight();
            canJump = IsOnSomething();
        }
        else
        {
            if (onFloor)
            {
                rb.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotation;
            }
            else
            {
                if (IsOnSomething() && downHit.collider != null && downHit.collider.gameObject.CompareTag("Player"))
                {
                    rb.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
                }
            }
        }
    }

    public override bool IsOnSomething()
    {
        // Comprobamos si hay algo sobre el jugador en lugar de debajo
        return Physics.BoxCast(transform.position, new Vector3(transform.localScale.x * 0.9f, transform.localScale.y / 3, transform.localScale.z * 0.9f), Vector3.up, out downHit, Quaternion.identity, downDistanceRay);
    }

    public override void Jump()
    {
        if (Input.GetKeyDown(KeyCode.W) && canJump)
        {
            rb.AddForce(new Vector3(0, -jumpForce, 0), ForceMode.Impulse); // Aplicar fuerza hacia abajo
        }
    }

    private void Movement()
    {
        if (Input.GetKey(KeyCode.A) && canMoveLeft)
        {
            rb.velocity = new Vector3(1 * -speed, rb.velocity.y, 0);
        }
        else if (Input.GetKey(KeyCode.D) && canMoveRight)
        {
            rb.velocity = new Vector3(1 * speed, rb.velocity.y, 0);
        }
        else
        {
            rb.velocity = new Vector3(0, rb.velocity.y, 0);
        }
    }
}
