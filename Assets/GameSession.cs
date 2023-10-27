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
        
        if (pointer == deathTimers.Length)
        {
            SceneManager.LoadScene("Level 1");
        }

        else if (isFlipped)
        {
            Destroy(flipped.gameObject);
            StartCoroutine(TimerActivation(isFlipped));
        }
        else
        {
            Destroy(normal.gameObject);
            StartCoroutine(TimerActivation(isFlipped));
        }

        pointer += 1;
    }

    IEnumerator TimerActivation(bool isFlipped)
    {
        yield return new WaitForSecondsRealtime(deathTimers[pointer]);
        if (isFlipped)
        {
            GameObject newPlayer = Instantiate(reversePlayer, new Vector3(normal.transform.position.x,
                -normal.transform.position.y, 0), Quaternion.identity);
            flipped = newPlayer.GetComponent<Player>();
        }
        else
        {
            GameObject newPlayer = Instantiate(player, new Vector3(flipped.transform.position.x,
                -flipped.transform.position.y, 0), Quaternion.identity);
            normal = newPlayer.GetComponent<Player>();
        }   
    }
}
