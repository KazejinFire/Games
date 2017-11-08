using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControrollerTransform : MonoBehaviour {
    public float moveSpeed;
    public float horizontalInput, faceVal;
    public bool isAttacking;
    public Collider swordCol;
    Animation anim;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animation>();
        swordCol.enabled = false;
    }

    // Update is called once per frame
    void Update() {
        horizontalInput = Input.GetAxis("Horizontal");
        if (!isAttacking)
        {
            Move(horizontalInput);
            if (horizontalInput == 0)
                anim.CrossFade("idle");
            else
                anim.CrossFade("Run");
            if (horizontalInput > 0)
            {
                faceVal = 0;
            }
            else if (horizontalInput < 0)
                faceVal = 180;
            transform.rotation = Quaternion.Euler(0, faceVal, 0);
        }
       if (Input.GetButtonDown("Fire1") && !isAttacking)
        {
            StartCoroutine(Attack());                   
        }

    }

    public void Move(float input)
    {
        transform.position += new Vector3(0,0,input * moveSpeed);
    }

    IEnumerator  Attack()
    {
        isAttacking = true;
        anim.Play("Attack");
        swordCol.enabled = true;
        yield return new WaitForSeconds(anim["Attack"].length);
        isAttacking = false;
        swordCol.enabled = false;
    }
}
