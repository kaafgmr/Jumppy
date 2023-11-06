using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GravityChangerBehaviour : MonoBehaviour
{
    private FlickerOpacity flicker;
    private Tilemap tilemap;

    private void Awake()
    {
        tilemap = GetComponent<Tilemap>();
        flicker = GetComponent<FlickerOpacity>();
    }

    private void OnBecameVisible()
    {
        flicker.StartFlickerTilemap(tilemap);
    }

    private void OnBecameInvisible()
    {
        flicker.StopFlicker();
    }
    private void OnTriggerEnter2D(Collider2D collision)
     {
        collision.transform.Rotate(new Vector3(0, 0, 180));
        collision.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        collision.gameObject.GetComponent<Rigidbody2D>().gravityScale = -collision.gameObject.GetComponent<Rigidbody2D>().gravityScale;
     }
}
