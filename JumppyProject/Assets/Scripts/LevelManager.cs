using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

[Serializable]
public class level
{
    public int id;
    public Transform Position;
}
public class LevelManager : MonoBehaviour
{
    private static LevelManager _instance;
    public static LevelManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<LevelManager>();
            }
            return _instance;
        }
    }

    public UnityEvent<Transform> changeCamera;
    public List<level> levelList = new List<level>();
    private Dictionary<int, level> _levelDic;
    public int CurrentLevel;

    private void Awake()
    {
        _levelDic = new Dictionary<int, level>();

        for (int i = 0; i < levelList.Count; i++)
        {
            _levelDic.Add(levelList[i].id, levelList[i]);
        }

        ChangeLevel(CurrentLevel);
    }

    public void ChangeLevel(int i)
    {
        if (_levelDic.ContainsKey(i))
        {
            CurrentLevel = i;
            changeCamera.Invoke(_levelDic[i].Position);

            for (int j = 0; j < levelList.Count; j++)
            {
                levelList[j].Position.gameObject.SetActive(false);
            }

            levelList[i].Position.gameObject.SetActive(true);
        }
    }

    public int GetCurrentLevel()
    {
        return CurrentLevel;
    }
}
