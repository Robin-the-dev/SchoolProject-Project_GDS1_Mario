using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Script for testing audio using keys
 */
public class AudioTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            //Example of how to call the audio
            AudioManager.Instance.PlayJumpSmall();
        }
        
        if (Input.GetKeyDown(KeyCode.W))
        {
            //Example of how to call the audio
            AudioManager.Instance.BGMUnderground();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            //Example of how to call the audio
            AudioManager.Instance.BGMStar();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            AudioManager.Instance.PlayJump_super();
        }
        
        if (Input.GetKeyDown(KeyCode.T))
        {
            AudioManager.Instance.PlayPipeGoingIn();
        }
        
        if (Input.GetKeyDown(KeyCode.Y))
        {
            AudioManager.Instance.PlayPipeGoingOut();
        }
        
        if (Input.GetKeyDown(KeyCode.A))
        {
            AudioManager.Instance.PlayLevelClear();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            AudioManager.Instance.PlayPoints();
        }
        
        if (Input.GetKeyDown(KeyCode.A))
        {
            AudioManager.Instance.StopBGM();
        }
        
        
    }
}
