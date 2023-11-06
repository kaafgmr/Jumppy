using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WinGame : MonoBehaviour
{
    public UnityEvent winGame;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        winGame.Invoke();
    }
}
