using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private MovementBehaviour MB;
    private Vector3 dir;
    private Rigidbody2D RB;
    private Animator Anim;
    public float speed;
    void Start()
    {
        MB = GetComponent<MovementBehaviour>();
        MB.Init(speed);
        RB = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
    }

    void Update()
    {
        float hor = Input.GetAxisRaw("Horizontal");

        dir = new Vector3(hor * speed, RB.velocity.y, 0);

        MB.MoveVelocity(dir);

        if(hor != 0)
        {
            Anim.SetInteger("run", 1);
        }
        else
        {
            Anim.SetInteger("run", 0);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            ChangeGravity();
            AudioManager.instance.PlaySound("ChangeGravity");
        }
    }

    public void ChangeGravity()
    {
        transform.Rotate(new Vector3(0, 0, 180));
        RB.velocity = new Vector2(0, 0);
        RB.gravityScale = -RB.gravityScale;
    }
}
