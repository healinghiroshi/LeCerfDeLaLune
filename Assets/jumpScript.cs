using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpScript : MonoBehaviour
{
    public Animator animator;

    public float moveSpeed = 5f;
    public bool isFloor = false;
  

    private SpriteRenderer mySpriteRenderer;
    private Vector2 startTouchPosition, endTouchPosition;

    // Update is called once per frame
    void Update()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            startTouchPosition = Input.GetTouch(0).position;
        }
        Jump();
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"),0f,0f);
        transform.position += movement * Time.deltaTime * moveSpeed;
    }

    void Jump()
    {
        animator.SetBool("isJumping", true);
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            endTouchPosition = Input.GetTouch(0).position;

            if ((Input.GetButtonDown("Right Jump") || endTouchPosition.x > startTouchPosition.x) && isFloor == true)
            {
                mySpriteRenderer.flipX = false;
                gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(1.4f, 5f), ForceMode2D.Impulse);
            }
            if ((Input.GetButtonDown("Right Jump") || endTouchPosition.x < startTouchPosition.x) && isFloor == true)
            {
                mySpriteRenderer.flipX = true;
                gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-1.4f, 5f), ForceMode2D.Impulse);
            }
        }
    }

    
}
