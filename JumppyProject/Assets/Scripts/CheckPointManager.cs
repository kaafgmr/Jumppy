using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

[Serializable]
public class Checkpoint
{
    public int id;
    public Transform CPtransform;
}
public class CheckPointManager : MonoBehaviour
{
    private static CheckPointManager _instance;
    public static CheckPointManager Instance
    {
        get
        {
            if (_instance == null)
            {

                _instance = FindObjectOfType<CheckPointManager>();
            }
            return _instance;
        }
    }

    public List<Checkpoint> CheckPointList = new List<Checkpoint>();
    private Dictionary<int, Checkpoint> _CheckPointDic;
    public int CurrentCheckPoint;

    private void Awake()
    {
        _CheckPointDic = new Dictionary<int, Checkpoint>();

        for (int i = 0; i < CheckPointList.Count; i++)
        {
            _CheckPointDic.Add(CheckPointList[i].id, CheckPointList[i]);
        }

        ChangeCheckPoint(CurrentCheckPoint);
    }

    public void ChangeCheckPoint(int i)
    {
        if (_CheckPointDic.ContainsKey(i))
        {
            CurrentCheckPoint = i;
            for (int j = 0; j < CheckPointList.Count; j++)
            {
                CheckPointList[j].CPtransform.gameObject.SetActive(false);
            }
            CheckPointList[CurrentCheckPoint].CPtransform.gameObject.SetActive(true);
        }
    }

    public void MoveToCheckPoint(GameObject ObjectToMove)
    {
        ObjectToMove.transform.position =  CheckPointList[CurrentCheckPoint].CPtransform.position;
    }

    public int GetCurrentCheckPoint()
    {
        return CurrentCheckPoint;
    }
}
