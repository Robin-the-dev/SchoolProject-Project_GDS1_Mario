using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneUpMushroomController : MonoBehaviour
{
    private GameController gameController;
    public AudioClip absorbed;

    public float speed;

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
        transform.Translate(Vector2.right * speed * Time.deltaTime);

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Mario") //If colliding w/ Mario, will increase his lives
        {
            AudioManager.Instance.PlayOneUp(); // Plays audio
            
            gameController.IncrementLives();
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "Wall") // Placeholder for turning when hit by wall or similar obstacle
        {
            speed = -speed;
        }
    }
}
