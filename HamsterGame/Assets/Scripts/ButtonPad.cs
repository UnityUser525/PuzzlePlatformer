using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPad : MonoBehaviour
{
    public ActivatorScript recipiantObject;

    public bool multiPlayerButton;
    public ActivatorScript activatorScript;

    private void Start()
    {
        activatorScript = gameObject.GetComponent<ActivatorScript>();
    }

    void Update()
    {
        if (multiPlayerButton == true && activatorScript.isActive == false)
        {
            recipiantObject.isActive = false;
        }
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if ((multiPlayerButton == false || activatorScript.isActive == true) && collision.gameObject.CompareTag("Ground") == false)
        {
            recipiantObject.isActive = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        recipiantObject.isActive = false;
    }
}
