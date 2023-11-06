using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehaviour : MonoBehaviour
{
    private Animator anim;
    private BoxCollider2D collider;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        collider = GetComponent<BoxCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        int counter = 0;
        for(int i = 0; i < ItemsList.ObjectsList.Length; i++)
        {
            if(ItemsList.ObjectsList[i].IsPicked() == 1)
            {
                counter++;
            }
        }

        if (counter == ItemsList.ObjectsList.Length)
        {
            anim.SetInteger("Open", 1);
            collider.enabled = false;
        }
        else
        {
            anim.SetInteger("Open", 0);
        }
    }
}
