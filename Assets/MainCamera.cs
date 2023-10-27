using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    float startingXPos;
    Player player;
    Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        startingXPos = FindObjectOfType<Player>().transform.position.x;
        mainCamera= GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if(FindObjectsOfType<Player>().Length==0)
        { FindObjectOfType<GameSession>().RestartLevel(); }
        player = FindObjectOfType<Player>();
        float halfWidth = mainCamera.aspect * mainCamera.orthographicSize;
        float quarterWidth = halfWidth / 2;
        transform.position = new Vector3(player.transform.position.x + quarterWidth, transform.position.y, -10);
    }
}
