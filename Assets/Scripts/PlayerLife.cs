using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    [SerializeField] private AudioSource DeathSoundEffect;
    private void Start()
    {

        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("trap"))
        {
            Die();
        }
    }

    private void Die()
    {
        anim.SetTrigger("death");
        DeathSoundEffect.Play();
        rb.bodyType = RigidbodyType2D.Static; //so when we die the player will not move around (changed from dynamic to static)
    }


    private void RestartLevel ()
    {
       SceneManager.LoadScene(SceneManager.GetActiveScene().name); //reload the current level when u die
    }
}
