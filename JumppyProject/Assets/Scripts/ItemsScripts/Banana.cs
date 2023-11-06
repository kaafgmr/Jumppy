using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Banana : Items
{
    private DestroyDisableObjects Ddo;
    public ProgressBarController PB;
    public UnityEvent PickItem;

    private static Banana _instance;
    public static Banana Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<Banana>();
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
        ItemManager.BananaIsPicked = 1;
        PickItem.Invoke();
        UpdateProgress(PB.maxValue / ItemsList.ObjectsList.Length);
        Ddo.DisableObject();
    }

    public override int IsPicked()
    {
        return ItemManager.BananaIsPicked;
    }

    public override void UpdateProgress(float amount)
    {
        PB.IncreaseValue(amount);
    }
}
