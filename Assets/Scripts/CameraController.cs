using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class CameraController : MonoBehaviour
{
    [HideInInspector]
    public Transform player;
    public Tilemap tilemap;
    private Vector3 boundary1;
    private Vector3 boundary2;
    private float halfHeight;
    private float halfWidth;


    void Start()
    {
        player = FindObjectOfType<PlayerController>().transform;


        halfHeight = Camera.main.orthographicSize;
        halfWidth = halfHeight * Camera.main.aspect;


        if (tilemap != null)
        {
            tilemap.CompressBounds();


            boundary1 = tilemap.localBounds.min + new Vector3(halfWidth, halfHeight, 0f);
            boundary2 = tilemap.localBounds.max + new Vector3(-halfWidth, -halfHeight, 0f);


            PlayerController.instance.SetBounds(tilemap.localBounds.min, tilemap.localBounds.max);
        }
    }




    void LateUpdate()
    {
        transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);


    }
}














