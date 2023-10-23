using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    float startingXPos;
    Player player;

    // Start is called before the first frame update
    void Start()
    {
        startingXPos = FindObjectOfType<Player>().transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        player = FindObjectOfType<Player>();
        transform.position = new Vector3(player.transform.position.x - startingXPos, transform.position.y, -10);
    }
}
