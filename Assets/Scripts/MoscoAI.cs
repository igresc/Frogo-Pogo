using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoscoAI : MonoBehaviour
{
    public float speed;
    public float lineOfSight = 5;
    public bool isChasing;
    private GameObject player;
    private Vector2 number;
    private float movingTime = 2;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (movingTime <= 0) {
            number.x = Random.Range(-20, 20);
            number.y = Random.Range(-10, 10);
            movingTime = 2;
        }
        else movingTime -= Time.deltaTime;

        if (Vector2.Distance(player.transform.position, transform.position) <= lineOfSight)
        {
            isChasing = true;
        }
        else 
        {
            isChasing = false;
        }

        if (player == null)
            return;
        if (isChasing) { ChasePlayer(); }
        else
            Patroling();
        
        Flip();
    }
    private void ChasePlayer() 
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }
    private void Patroling()
    {
        Vector2 moveTo = number;
        transform.position = Vector2.MoveTowards(transform.position, moveTo, speed * Time.deltaTime);
    }
    private void Flip() 
    {
        if (transform.position.x > player.transform.position.x)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else 
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }
}
