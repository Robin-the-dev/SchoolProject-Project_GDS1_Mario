using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionBoxController : MonoBehaviour
{
    public AudioClip hit;
    public AudioClip open;

    public bool oneUpMushroom;
    public bool powerUpItem;
    public bool coin;

    float destroyTime = 2;

    bool bottomCol;

    public GameObject redMushroom;
    public GameObject oneUpShroom;
    public GameObject fireFlower;
	public GameObject emptyBlock;
    public GameObject coinOb;

    GameObject spawnRedMushroom;
    GameObject spawnFireFlower;
    GameObject spawnOneUpMushroom;
    GameObject spawnEmptyBlock;
    GameObject spawnCoin;

    Vector3 pos = new Vector3(0f, 1f, 0f); //Temp; For spawning atop box

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Attempt 2
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Detects if collision is from the bottom of the box..
        if (collision.contacts.Length > 0)
        {
            ContactPoint2D contact = collision.contacts[0];
            if (Vector3.Dot(contact.normal, Vector3.up) > 0.5)
            {

                if (powerUpItem) // If set to spawn a power-up item...
                {
                    if (collision.collider.bounds.max.y < transform.position.y && collision.collider.name == "Mario")
                    {
                        AudioManager.Instance.PlayPowerup_appear(); //Plays audio
                        
                        MarioTransformController marioTC = collision.gameObject.GetComponent<MarioTransformController>();
                        if (marioTC.spriteSheet == "normal mario") // Will spawn a fire flower if normal mario
                        {
                            spawnFireFlower = Instantiate(fireFlower, transform.position + pos, transform.rotation);

                            //spawnEmptyBlock = Instantiate(emptyBlock, transform.position, transform.rotation);
                            gameObject.SetActive(false);
                        }

                        else if (marioTC.spriteSheet == "tiny mario") // Will spawn a red mushroom if tiny mario
                        {
                            spawnRedMushroom = Instantiate(redMushroom, transform.position + pos, transform.rotation);

                            //spawnEmptyBlock = Instantiate(emptyBlock, transform.position, transform.rotation);
                            gameObject.SetActive(false);
                        }
                    }
                }
                if (oneUpMushroom) // Will spawn a 1UP mushroom if set to spawn so
                {
                    if (collision.collider.bounds.max.y < transform.position.y && collision.collider.name == "Mario")
                        spawnOneUpMushroom = Instantiate(oneUpShroom, transform.position + pos, transform.rotation);
                    
                    AudioManager.Instance.PlayPowerup_appear(); // Plays audio
                    
                    //spawnEmptyBlock = Instantiate(emptyBlock, transform.position, transform.rotation);
                    gameObject.SetActive(false);
                }
                
                if (coin)
                {
                    AudioManager.Instance.PlayCoin(); //Plays audio
                    if (collision.collider.bounds.max.y < transform.position.y && collision.collider.name == "Mario")
                        spawnCoin = Instantiate(coinOb, transform.position + pos, transform.rotation);
                    Destroy(spawnCoin, destroyTime * Time.deltaTime);

                    //spawnEmptyBlock = Instantiate(emptyBlock, transform.position, transform.rotation);
                    gameObject.SetActive(false);
                }
            }
        }
    }
}
