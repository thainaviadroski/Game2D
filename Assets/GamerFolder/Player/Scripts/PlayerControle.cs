using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControle : MonoBehaviour
{

    public float speed;
    public float speedRun;
    public float impulse;

    public bool floorTouch;

    Rigidbody2D rigid;

    Animator animator;

    public Transform skin;

    public int combo;
    public float countCombo;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {


        if (GetComponent<Character>().life == 0)
        {
            this.enabled = false;
            //GetComponent<CapsuleCollider2D>.enabled = false;
        }

        countCombo += Time.deltaTime;

        move();
        if (Input.GetButtonDown("Jump"))
        {
            jump();

        }

        if (Input.GetButtonDown("Fire1"))
        {
            attack();
        }

        if (Input.GetButtonDown("Fire2"))
        {
            attack2();
        }

        if (Input.GetButtonDown("Fire3"))
        {
            dash();
        }

    }


    public void move()
    {
        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            skin.GetComponent<Animator>().SetBool("run", true);

        }
        else
        {
            skin.GetComponent<Animator>().SetBool("run", false);
        }

        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            //skin.GetComponent<SpriteRenderer>().flipX = true;
            transform.localScale = new Vector3(-5, 5, 0);
        }

        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            //skin.GetComponent<SpriteRenderer>().flipX = false;
            transform.localScale = new Vector3(5, 5, 0);
        }

        Vector3 moviment = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
        transform.position += moviment * speed * Time.deltaTime;
    }

    public void jump()
    {
        skin.GetComponent<Animator>().Play("jump", -1);
        rigid.AddForce(new Vector2(0f, impulse), ForceMode2D.Impulse);

    }

    public void attack()
    {

        if (combo == 1 && countCombo <= 2)
        {
            skin.GetComponent<Animator>().Play("attack02", -1);
            combo = 0;

        }
        else
        {
            skin.GetComponent<Animator>().Play("attack01", -1);
            combo = 1;
            countCombo = 0;
        }


    }

    public void attack2()
    {
        skin.GetComponent<Animator>().Play("attack02", -1);

    }

    public void dash()
    {
        skin.GetComponent<Animator>().Play("dash", -1);

        //rigid.AddForce(new Vector2(0f, impulse), ForceMode2D.Impulse);
        rigid.AddForce(new Vector2(5 * Input.GetAxisRaw("Horizontal"), 0f), ForceMode2D.Impulse);

    }

}
