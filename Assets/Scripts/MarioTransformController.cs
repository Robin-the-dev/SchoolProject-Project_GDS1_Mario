using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioTransformController : MonoBehaviour
{
    public string spriteSheet;

    void LateUpdate()
    {
        // Loads spritesheet from Resources folder
        var subSprites = Resources.LoadAll<Sprite>(spriteSheet);

        // For each sprite in current spritesheet, exchanges for respective sprite in new spritesheet
        foreach (var spRenderer in GetComponentsInChildren<SpriteRenderer>())
        {
            string spriteName = spRenderer.sprite.name;
            var newSprite = System.Array.Find(subSprites, item => item.name == spriteName);

            if (newSprite)
            {
                spRenderer.sprite = newSprite;
            }
        }
    }
}
