using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsScript : MonoBehaviour
{
    public GameObject recipiant;

    private bool recipiantActive = false;

    public void setRecipiantActive()
    {
        if (recipiantActive == false)
        {
            recipiantActive = true;
        }
        else
        {
            recipiantActive = false;
        }
        recipiant.SetActive(recipiantActive);
    }
}
