using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;

public class collision : MonoBehaviour
{
    GameObject Player;
    // Start is called before the first frame update
    float resetTimer;


    void Start()
    {
        Player = gameObject.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        resetTimer += Time.deltaTime;
        if ((Player.GetComponent<jumpScript>().isFloor == false) && resetTimer > 4)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); // loads current scene
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "step")
        {
            Player.GetComponent<jumpScript>().isFloor = true;
            resetTimer = 0;

        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "step")
        {
            Player.GetComponent<jumpScript>().isFloor = false;
            resetTimer = 0;
        }
    }
}
