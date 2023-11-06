using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Cherry : Items
{
    private DestroyDisableObjects Ddo;
    public ProgressBarController PB;
    public UnityEvent PickItem;

    private static Cherry _instance;
    public static Cherry Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<Cherry>();
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
        ItemManager.CherryIsPicked = 1;
        PickItem.Invoke();
        UpdateProgress(PB.maxValue / ItemsList.ObjectsList.Length);
        Ddo.DisableObject();
    }

    public override int IsPicked()
    {
        return ItemManager.CherryIsPicked;
    }

    public override void UpdateProgress(float amount)
    {
        PB.IncreaseValue(amount);
    }
}
