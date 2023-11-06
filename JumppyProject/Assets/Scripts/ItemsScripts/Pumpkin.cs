using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Pumpkin : Items
{
    private DestroyDisableObjects Ddo;
    public ProgressBarController PB;
    public UnityEvent PickItem;

    private static Pumpkin _instance;
    public static Pumpkin Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<Pumpkin>();
            }
            return _instance;
        }
    }

    private void Awake()
    {
        Ddo = GetComponent<DestroyDisableObjects>();
    }

    public override void Pick()
    {
        ItemManager.PumpkinIsPicked = 1;
        PickItem.Invoke();
        UpdateProgress(PB.maxValue / ItemsList.ObjectsList.Length);
        Ddo.DisableObject();
    }

    public override int IsPicked()
    {
        return ItemManager.PumpkinIsPicked;
    }

    public override void UpdateProgress(float amount)
    {
        PB.IncreaseValue(amount);
    }
}
