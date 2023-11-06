using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitObject : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.GetComponent<HealthBehaviour>().GetHurt(0);
        collision.gameObject.GetComponent<PlayerController>().ChangeGravity();
    }
}
