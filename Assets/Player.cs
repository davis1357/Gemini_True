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
    bool isAlive = true;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = FindObjectOfType<Camera>();
        myRigidBody = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMoves();

        PlayerJumping();
    }

    private void PlayerMoves()
    {
        transform.Translate(Vector2.right * playerSpeed * Time.deltaTime);
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
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Floor")
            isTouching = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Danger" && isActive && isAlive)
        {
            FindObjectOfType<GameSession>().Death(isFlipped);
        }

        if (collision.gameObject.tag == "Floor")
            isTouching = true;
    }
}
