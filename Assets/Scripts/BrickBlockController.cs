using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickBlockController : MonoBehaviour
{
    [SerializeField] private PlayerController PC;
    [SerializeField] private float speed = 1;
    [SerializeField] private Animator anim;
    [SerializeField] private ParticleSystem PS;
    [SerializeField] private SpriteRenderer SR;
    [SerializeField] private BoxCollider2D BC;

    private bool bump;

    void Start()
    {
        PC = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        PS = GetComponentInChildren<ParticleSystem>();
        SR = GetComponent<SpriteRenderer>();
        BC = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if mario hits block from below 
        if (collision.gameObject.CompareTag("Player") && collision.GetContact(0).normal.y > 0.5f)
        {
            //if mario is fiery or big, destroy the block
            if (PlayerController.marioState == PlayerController.MarioState.fiery ||
                PlayerController.marioState == PlayerController.MarioState.big)
            {   //trigger block breaking effect
                StartCoroutine(BreakBlock());
            }
            else //if mario is small, bump the block
            {
                AudioManager.Instance.PlayBump();
                anim.SetTrigger("HitBlock");
            }
            
        } 
    }

    private IEnumerator BreakBlock()
    {
        AudioManager.Instance.PlayBreakBlock();
        PS.Play();
        SR.enabled = false;
        BC.enabled = false;

        yield return new WaitForSeconds(PS.main.startLifetime.constantMax);
        Destroy(gameObject);
    }


}
