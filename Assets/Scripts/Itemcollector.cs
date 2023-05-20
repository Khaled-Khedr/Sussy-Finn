using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Itemcollector : MonoBehaviour
{
    private int strawberries = 0;
    [SerializeField] private Text strawberrytext; //so we can change it in unity as well and connect it to the player object
    [SerializeField] private AudioSource CollectSoundEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("strawberry")) //if ur colliding with one of the strawberries we assigned a tag to it 
        {
            CollectSoundEffect.Play();
            Destroy(collision.gameObject); //destroys the strawberry so we collect it 
            strawberries++;
            strawberrytext.text="strawberries: " +strawberries; // no need to get component at all for texts

        }
    }

}
