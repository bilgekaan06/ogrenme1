using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundcollision : MonoBehaviour {

    public BoxCollider2D groundCol;
    public BoxCollider2D playerCol;
    //public BoxCollider2D triggerbehavior;
	void Start () {

        playerCol = GameObject.Find("Player").GetComponent<BoxCollider2D>();
        Physics2D.IgnoreCollision(groundCol, /*triggerbehavior*/groundCol, true);//deneye deneye bulduk :)

		
	}
    void OnTriggerEnter2D(Collider2D bilesen)
    {
        if (bilesen.gameObject.name=="Player")
        {
            Physics2D.IgnoreCollision(groundCol,playerCol, true);
        }
    }
    void OnTriggerExit2D(Collider2D bilesen)
    {
        if (bilesen.gameObject.name == "Player")
        {
            Physics2D.IgnoreCollision(groundCol, playerCol, false);
        }
    }
	
}
