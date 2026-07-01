using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpIconScript : MonoBehaviour
{
    public Player playerScript;
    public GameObject JumpIcon1;
    // Start is called before the first frame update
    void Start()
    {
        JumpIcon1.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerScript.extraJump >= 1)
        {
            JumpIcon1.gameObject.SetActive(true);
        }

        if (playerScript.extraJump <= 0)
        {
            JumpIcon1.gameObject.SetActive(false);
        }
    }
}
