using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearTrap : MonoBehaviour
{

    public Transform skin;

    Transform player;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerControle>().skin.GetComponent<Animator>().SetBool("run", false);
            skin.GetComponent<Animator>().Play("trap", -1);
            other.GetComponent<Character>().life--;

            other.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

            other.transform.position = transform.position;

            player = other.transform;

            other.GetComponent<PlayerControle>().enabled = false;

            Invoke("realeasePlayer", 2);

            transform.GetComponent<BoxCollider2D>().enabled = false;
        }
    }


    void realeasePlayer()
    {
        player.GetComponent<PlayerControle>().enabled = true;
    }
}
