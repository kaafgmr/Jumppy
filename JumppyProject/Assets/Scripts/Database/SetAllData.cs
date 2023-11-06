using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetAllData : MonoBehaviour
{
    public GameObject Player;

    private void Awake()
    {
        DBManager.GetData(DBManager.ID);
    }

    private void Start()
    {
        LevelManager.Instance.ChangeLevel(DBManager.level);
        CheckPointManager.Instance.ChangeCheckPoint(DBManager.checkPoint);
        CheckPointManager.Instance.MoveToCheckPoint(Player);
        if (ItemManager.CherryIsPicked == 1)
        {
            Cherry.Instance.Pick();
        }
        if (ItemManager.PumpkinIsPicked == 1)
        {
            Pumpkin.Instance.Pick();
        }
        if (ItemManager.BananaIsPicked == 1)
        {
            Banana.Instance.Pick();
        }
    }
}
