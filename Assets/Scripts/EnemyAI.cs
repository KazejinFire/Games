using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {
    public float moveSpeed, direction;
    public Transform player;

	// Use this for initialization
	void Start () {
        player = GameObject.FindWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.z - player.position.z > 0)
            direction = -1;
        else
            direction = 1;
        Move(direction, 0.01f);
        Debug.Log(transform.position.z - player.position.z);
	}

    private void Move(float dir ,float mSpeed)
    {
        float faceVal;
        transform.position +=new Vector3( 0, 0, dir * mSpeed);
        if (dir > 0)
            faceVal = 0;
        else
            faceVal = 180;
        transform.rotation = Quaternion.Euler(0, faceVal, 0);
    }
}
