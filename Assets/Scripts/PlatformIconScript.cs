using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformIconScript : MonoBehaviour
{
    public Player playerScript;
    public GameObject PlatformIcon1;
    // Start is called before the first frame update
    void Start()
    {
        PlatformIcon1.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerScript.hasGroundItem == true)
        {
            PlatformIcon1.gameObject.SetActive(true);
        }

        if (playerScript.hasGroundItem == false)
        {
            PlatformIcon1.gameObject.SetActive(false);
        }
    }
}
