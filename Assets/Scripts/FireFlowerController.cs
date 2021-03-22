using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireFlowerController : MonoBehaviour
{
    public AudioClip absorbed;

    private GameController gameController;

    // Start is called before the first frame update
    void Start()
    {
        // Referencing game controller object and script
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        gameController = gameControllerObject.GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Mario")
        {
            AudioManager.Instance.PlayPowerup_eat();
            gameController.ChangeSprite("fire mario");
            Destroy(gameObject);
        }
    }
}
