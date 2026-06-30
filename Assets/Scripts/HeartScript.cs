using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartScript : MonoBehaviour
{
    public Player playerScript;
    public GameObject Heart1, Heart2, Heart3;
    // Start is called before the first frame update
    void Start()
    {
        Heart1.gameObject.SetActive(true);
        Heart2.gameObject.SetActive(true);
        Heart3.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerScript.playerLives == 3)
        {
            Heart1.gameObject.SetActive(true);
            Heart2.gameObject.SetActive(true);
            Heart3.gameObject.SetActive(true);
        }

        if (playerScript.playerLives == 2)
        {
            Heart1.gameObject.SetActive(true);
            Heart2.gameObject.SetActive(true);
            Heart3.gameObject.SetActive(false);
        }

        if (playerScript.playerLives == 1)
        {
            Heart1.gameObject.SetActive(true);
            Heart2.gameObject.SetActive(false);
            Heart3.gameObject.SetActive(false);
        }

        if (playerScript.playerLives == 0)
        {
            Heart1.gameObject.SetActive(false);
            Heart2.gameObject.SetActive(false);
            Heart3.gameObject.SetActive(false);
        }
    }
}
