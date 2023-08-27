using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    public Transform pontoA;
    public Transform pontoB;


    public bool goRight;
    public bool goLeft;

    public Transform skin;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (GetComponent<Character>().life == 0)
        {
            this.enabled = false;
            GetComponent<CapsuleCollider2D>().enabled = false;
        }
        move();

    }

    void move()
    {

        if (goRight)
        {
            if (Vector2.Distance(transform.position, pontoA.position) <= 0.5f)
            {
                goRight = false;
                skin.GetComponent<SpriteRenderer>().flipX = false;
            }

            transform.position = Vector2.MoveTowards(transform.position, pontoA.position, 2 * Time.deltaTime);
        }
        else
        {
            if (Vector2.Distance(transform.position, pontoB.position) <= 0.5f)
            {
                goRight = true;
                skin.GetComponent<SpriteRenderer>().flipX = true;
            }
            transform.position = Vector2.MoveTowards(transform.position, pontoB.position, 2 * Time.deltaTime);
        }

    }
}
