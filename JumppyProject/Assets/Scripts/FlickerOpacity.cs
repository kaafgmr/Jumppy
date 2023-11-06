using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class FlickerOpacity : MonoBehaviour
{
    private bool CanChange;
    public float frequency;
    public float Duration;
    private float d;

    private void Awake()
    {
        d = Duration;
    }

    IEnumerator ChangeOpacityTilemap(Tilemap t)
    {
        t.color = new Color(t.color.r, t.color.g, t.color.b, Mathf.PingPong(Time.time * frequency, 1));
        yield return new WaitForSeconds(0.01f);
        if (CanChange)
        {
            StartCoroutine("ChangeOpacityTilemap", t);
        }
        else
        {
            t.color = new Color(1, 1, 1, 1);
           StopCoroutine("ChangeOpacityTilemap");
        }
    }

    IEnumerator ChangeOpacitySprite(SpriteRenderer sr)
    {
        sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, Mathf.PingPong(Time.time * frequency, 1));
        d--;
        yield return new WaitForSeconds(0.01f);
        if (CanChange && d != 0)
        {
            StartCoroutine("ChangeOpacitySprite", sr);
        }
        else
        {
            d = Duration;
            sr.color = new Color(1, 1, 1, 1);
            StopCoroutine("ChangeOpacitySprite");
        }
    }

    public void StartFlickerTilemap(Tilemap t)
    {
        CanChange = true;
        StartCoroutine("ChangeOpacityTilemap", t);
    }

    public void StartFlickerSprite(SpriteRenderer sr)
    {
        CanChange = true;
        StartCoroutine("ChangeOpacitySprite", sr);
    }

    public void StopFlicker()
    {
        CanChange = false;
    }
    
}