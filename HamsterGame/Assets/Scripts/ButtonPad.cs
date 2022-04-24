using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPad : MonoBehaviour
{
    public ActivatorScript recipiantObject;

    public bool multiPlayerButton;


    private SpriteRenderer buttonSprite;
    public Sprite buttonUp;
    public Sprite buttonDown;
    public SpriteRenderer buttonColorSprite;
    public Sprite buttonUpColor;
    public Sprite buttonDownColor;

    private ActivatorScript activatorScript;

    private void Start()
    {
        activatorScript = gameObject.GetComponent<ActivatorScript>();
        buttonSprite = gameObject.GetComponent<SpriteRenderer>();
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
        if (collision.gameObject.CompareTag("Ground") == false)
        {
            buttonSprite.sprite = buttonDown;
            buttonColorSprite.sprite = buttonDownColor;
        }

        if ((multiPlayerButton == false || activatorScript.isActive == true) && collision.gameObject.CompareTag("Ground") == false)
        {
            recipiantObject.isActive = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        recipiantObject.isActive = false;
        buttonSprite.sprite = buttonUp;
        buttonColorSprite.sprite = buttonUpColor;
    }
}
