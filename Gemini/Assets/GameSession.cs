using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{
    [SerializeField] int[] deathTimers;
    [SerializeField] Player normal;
    [SerializeField] Player flipped;
    [SerializeField] GameObject player;
    [SerializeField] GameObject reversePlayer;

    int pointer;

    // Start is called before the first frame update
    void Start()
    {
        pointer = 0;
    }

    public void Death(bool isFlipped)
    {
        //Debug.Log(isFlipped);
        pointer += 1;
        if (pointer == deathTimers.Length)
        {
            SceneManager.LoadScene("Level 1");
        }

        else if (isFlipped)
        {
            Destroy(flipped.gameObject);
            //Debug.Log("flipped");
            //flipped.GetComponent<SpriteRenderer>().enabled = false;
            //flipped.GetComponent<BoxCollider2D>().enabled = false;
            //flipped.isActive = false;
            //flipped.GetComponent<BoxCollider2D>().isTrigger = true;
            StartCoroutine(TimerActivation(isFlipped));
        }
        else
        {
            Destroy(normal.gameObject);
            //Debug.Log("normal");
            //normal.GetComponent<SpriteRenderer>().enabled = false;
            //normal.GetComponent<BoxCollider2D>().enabled = false;
            //normal.isActive = false;
            //normal.GetComponent<BoxCollider2D>().isTrigger = true;
            StartCoroutine(TimerActivation(isFlipped));
        }
    }

    IEnumerator TimerActivation(bool isFlipped)
    {
        yield return new WaitForSecondsRealtime(deathTimers[pointer]);
        if (isFlipped)
        {
            //flipped.GetComponent<SpriteRenderer>().enabled = true;
            //flipped.GetComponent<BoxCollider2D>().enabled = true;
            //flipped.isActive = true;
            //flipped.GetComponent<BoxCollider2D>().isTrigger = false;
            //flipped.gameObject.SetActive(true);
            GameObject newPlayer = Instantiate(reversePlayer, new Vector3(normal.transform.position.x,
                -normal.transform.position.y, 0), Quaternion.identity);
            flipped = newPlayer.GetComponent<Player>();
        }
        else
        {
            //normal.GetComponent<SpriteRenderer>().enabled = true;
            //normal.GetComponent<BoxCollider2D>().enabled = true;
            //normal.isActive = true;
            //normal.GetComponent<BoxCollider2D>().isTrigger = false;
            //normal.gameObject.SetActive(true);
            GameObject newPlayer = Instantiate(player, new Vector3(flipped.transform.position.x,
                -flipped.transform.position.y, 0), Quaternion.identity);
            normal = newPlayer.GetComponent<Player>();
        }   
    }
}
