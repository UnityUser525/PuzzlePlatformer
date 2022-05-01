using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenFit : MonoBehaviour
{
    public SpriteRenderer gameScreen;

    // Start is called before the first frame update
    void Start()
    {
        float screenRatio = (float)Screen.width / (float)Screen.height;
        float targetRatio = gameScreen.bounds.size.x / gameScreen.bounds.size.y;

        if (screenRatio >= targetRatio)
        {
            Camera.main.orthographicSize = gameScreen.bounds.size.y / 2;
        }
        else
        {
            float differenceInSize = targetRatio / screenRatio;
            Camera.main.orthographicSize = gameScreen.bounds.size.y / 2 * differenceInSize;
        }
        if (screenRatio >= targetRatio)
        {
            Camera.main.orthographicSize = gameScreen.bounds.size.y / 2;
        }
        else
        {
            float differenceInSize = targetRatio / screenRatio;
            Camera.main.orthographicSize = gameScreen.bounds.size.y / 2 * differenceInSize;
        }
    }
}
