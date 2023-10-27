using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Camera mainCamera;
    [SerializeField] float playerSpeed = 10f;
    [SerializeField] float jumpSpeed = 5f;
    [SerializeField] bool isFlipped = false;

    Rigidbody2D myRigidBody;
    BoxCollider2D myCollider;
    bool isTouching = true;
    public bool isActive = true;
    //float startingXPos;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = FindObjectOfType<Camera>();
        myRigidBody = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<BoxCollider2D>();
        //startingXPos = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        //mainCamera.transform.position = new Vector3(this.transform.position.x - startingXPos, mainCamera.transform.position.y, -10);

        PlayerMoves();

        PlayerJumping();
    }

    private void PlayerMoves()
    {
        //myRigidBody.velocity = new Vector2(playerSpeed, 0);
        transform.Translate(Vector2.right * playerSpeed * Time.deltaTime);
        //this.transform.position += this.transform.right * Time.deltaTime * playerSpeed;
    }

    private void PlayerJumping()
    {
        if (!isTouching)
        { return; }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(!isFlipped)
                myRigidBody.AddRelativeForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
            else
                myRigidBody.AddRelativeForce(Vector2.down * jumpSpeed, ForceMode2D.Impulse);
            //myRigidBody.AddRelativeForce(0,jumpSpeed,0);
            //myRigidBody.velocity = new Vector2(playerSpeed, jumpSpeed);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Floor")
            isTouching = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Danger" && isActive)
        {
            FindObjectOfType<GameSession>().Death(isFlipped);
        }

        if (collision.gameObject.tag == "Floor")
            isTouching = true;
    }
}
