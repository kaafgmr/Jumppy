using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PathFollow : MonoBehaviour
{
    private MovementBehaviour MB;
    public int CurrentPoint;
    private Vector3 Dir;
    public List<Transform> pointList;
    private bool CanMove = true;
    public float velocity;

    public UnityEvent ReachedNextPoint;

    private void Awake()
    {
        MB = GetComponent<MovementBehaviour>();
        Dir = (pointList[CurrentPoint + 1].position - transform.position).normalized;
        MB.Init(velocity);
    }

    IEnumerator FollowPath()
    {
        if (CurrentPoint + 1 <= pointList.Count && CanMove)
        {
            MB.Move(Dir);

            if (Vector3.Distance(transform.position, pointList[CurrentPoint + 1].position) <= 0.2f)
            {
                ReachedNextPoint.Invoke();
                CurrentPoint++;
                transform.position = pointList[CurrentPoint].position;
                if (CurrentPoint >= pointList.Count - 1)
                {
                    pointList.Reverse();
                    CurrentPoint = 0;
                }
                Dir = (pointList[CurrentPoint + 1].position - transform.position).normalized;
            }
        }
        yield return new WaitForSeconds(0.01f);
        if(CanMove)
        {
            StartCoroutine("FollowPath");
        }
        else
        {
            StopCoroutine("FollowPath");
        }
    }

    private void OnBecameVisible()
    {
        CanMove = true;
        StartCoroutine("FollowPath");
    }

    private void OnBecameInvisible()
    {
        CanMove = false;
    }

}
