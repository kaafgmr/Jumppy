using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelChanger : MonoBehaviour
{
    public int GoTo;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        LevelManager.Instance.ChangeLevel(GoTo);
        CheckPointManager.Instance.ChangeCheckPoint(GoTo);
    }
}
