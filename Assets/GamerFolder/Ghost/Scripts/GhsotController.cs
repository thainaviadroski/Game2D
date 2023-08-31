using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhsotController : MonoBehaviour
{
    public Transform pontoA;
    public Transform pontoB;

    public int speed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        move();
    }


    void move()
    {
        if (Vector2.Distance(transform.position, pontoA.position) <= 0.5f)
        {
            transform.position = pontoB.position;
        }
        transform.position = Vector2.MoveTowards(transform.position, pontoA.position, speed * Time.deltaTime);

    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
            other.GetComponent<Character>().life --;
        }
    }
}
