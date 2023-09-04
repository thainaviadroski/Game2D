using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatController : MonoBehaviour
{
    public Transform player;
    public float speed;

    public float contAttack;

    //public Transform skin;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        contAttack += Time.deltaTime;

        if(GetComponent<Character>().life == 0){
            this.enabled = false;
            GetComponent<CircleCollider2D>().enabled = false;
            GetComponent<Rigidbody2D>().gravityScale = 1;
        }

        move();
    }


    void move()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player") && contAttack >= 1)
        {
            other.gameObject.GetComponent<Character>().life--;
            contAttack = 0;
        }
    }
}
