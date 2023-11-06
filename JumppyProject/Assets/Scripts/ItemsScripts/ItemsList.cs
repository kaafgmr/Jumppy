using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsList : MonoBehaviour
{
    public static Items[] ObjectsList;

    private void Awake()
    {
        ObjectsList = GetComponentsInChildren<Items>();
    }
}
