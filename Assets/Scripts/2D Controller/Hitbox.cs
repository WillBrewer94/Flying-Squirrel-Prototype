using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour {

    public PolygonCollider2D frame2;
    public PolygonCollider2D frame3;

    private PolygonCollider2D[] colliders;

    private PolygonCollider2D localCollider;

    public enum Hitboxes {
        frame2Box,
        frame3Box,
        clear // special case to remove all boxes
    }

    // Use this for initialization
    void Start () {
        colliders = new PolygonCollider2D[] { frame2, frame3 };
        localCollider = gameObject.AddComponent<PolygonCollider2D>();
        localCollider.isTrigger = true;
        localCollider.pathCount = 0;
	}

    void OnTriggerEnter2D(Collider2D col) {
        Debug.Log("Collider hit something!");
    }

    public void SetHitBox(Hitboxes val) {
        if(val != Hitboxes.clear) {
            localCollider.SetPath(0, colliders[(int)val].GetPath(0));
            return;
        }

        localCollider.pathCount = 0;
    }
}
