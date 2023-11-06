using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class DoorGuardianText : MonoBehaviour
{
    public Canvas TextBox;
    public UnityEvent WhenTextIsShown;

    private void Awake()
    {
        TextBox.enabled = false;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        TextBox.enabled = true;
        WhenTextIsShown.Invoke();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        TextBox.enabled = false;
    }
}
