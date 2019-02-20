using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goldcollider : MonoBehaviour
{
    void Start()
    {
    }

    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D collecter)
    {
        if (collecter.gameObject.tag == "maincharacter")
        {
            Player.gold_count++;
            //Debug.Log(Player.gold_count);
            Destroy(gameObject);
        }
    }
}
