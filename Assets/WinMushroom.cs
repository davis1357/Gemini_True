using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinMushroom : MonoBehaviour
{
    [SerializeField] public GameObject winText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void WinScreen()
    {
        winText.GetComponent<Text>().enabled = true;
    }
}
