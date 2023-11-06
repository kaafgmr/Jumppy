using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Items : MonoBehaviour
{
    protected int ID;
    protected string Name;
    protected int Picked;

    private void Awake()
    {
        Picked = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(Picked == 0)
        {
            AudioManager.instance.PlaySound("PickItem");
            Pick();
        }
    }
    public abstract void Pick();
    public abstract int IsPicked();

    public abstract void UpdateProgress(float amount);
}
