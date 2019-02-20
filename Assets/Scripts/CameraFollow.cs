using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform Player;
    public float pos;
    
    public float minX;
    public float maxX;

    public float minY;
    public float maxY;


    void Start()
    {

    }

    void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(Player.position.x,minX,maxX) + pos,Mathf.Clamp(Player.position.y,minY,maxY), transform.position.z);
    }
}
