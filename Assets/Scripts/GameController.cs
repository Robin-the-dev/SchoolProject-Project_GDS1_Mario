using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public int lives;

    public MarioTransformController marioChange;

    // Start is called before the first frame update
    void Start()
    {
        lives = 3;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeSprite(string marioForm)
    {
        marioChange.spriteSheet = marioForm;
        Debug.Log(marioChange.spriteSheet);
    }

    public void IncrementLives()
    {
        lives++;
        Debug.Log(lives); //For testing purposes
    }
}
