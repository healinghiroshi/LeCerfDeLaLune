using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;

public class collision : MonoBehaviour
{
    GameObject Player;
    // Start is called before the first frame update
    float resetTimer;
    public bool playerStateAlive;
    public bool playerDoneJumping;
    public int jumpCounter = 0;


    void Start()
    {
        Player = gameObject.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        playerStateAlive = true;
        resetTimer += Time.deltaTime;
        if ((Player.GetComponent<jumpScript>().isFloor == false) && resetTimer > 4)
        {
            playerStateAlive = false;
            jumpCounter = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); // loads current scene
        }
        if(jumpCounter > 5)
        {
            jumpCounter = 0;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Collider>().tag == "step")
        {
            Player.GetComponent<jumpScript>().isFloor = true;
            playerDoneJumping = true;
            resetTimer = 0;
            jumpCounter++;

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Collider>().tag == "step")
        {
            Player.GetComponent<jumpScript>().isFloor = false;
            playerDoneJumping = false;
            resetTimer = 0;
        }
    }
}
