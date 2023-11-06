using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class standUp : MonoBehaviour
{
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        anim.SetInteger("Standing", 1);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        anim.SetInteger("Standing", 0);
    }
}
