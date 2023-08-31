using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    public Transform pontoA;
    public Transform pontoB;


    public bool goRight;    

    public Transform skin;

    public Transform rangeAttack;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (skin.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("attack"))
        {
            return;
        }

        if (GetComponent<Character>().life == 0)
        {
            this.enabled = false;
            GetComponent<CapsuleCollider2D>().enabled = false;
            rangeAttack.GetComponent<CircleCollider2D>().enabled = false;
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
                transform.localScale = new Vector3(6,6,0);
            }

            transform.position = Vector2.MoveTowards(transform.position, pontoA.position, 2 * Time.deltaTime);
        }
        else
        {
            if (Vector2.Distance(transform.position, pontoB.position) <= 0.5f)
            {
                goRight = true;
                transform.localScale = new Vector3(-6,6,0);
            }
            transform.position = Vector2.MoveTowards(transform.position, pontoB.position, 2 * Time.deltaTime);
        }

    }
}
