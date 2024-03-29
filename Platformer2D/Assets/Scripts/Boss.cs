﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField]
    private int life = 5;
    private float speed = 8f;
    private float distance;
    private float startTimer;
    private float duration = 2f;
    [SerializeField]
    private float repulseForce = 10f;
    [SerializeField]
    private Transform start = null;
    [SerializeField]
    private Transform end = null;
    [SerializeField]
    private GameObject bullet = null;
    [SerializeField]
    private Rigidbody player = null;

    void Awake()
    {
        startTimer = duration;
    }

    void Update()
    {
        Move();
        Life();
    }

    private void Move()
    {
        distance = Mathf.PingPong(Time.time, speed);
        transform.position = Vector3.Lerp(start.position, end.position, distance / speed);
    }

    private void Shoot()
    {

        if (startTimer > 0)
            startTimer -= Time.deltaTime;
        else
        {
            startTimer = duration;
            bullet.transform.position = new Vector3(transform.position.x, bullet.transform.position.y, 0);
            Instantiate(bullet);
        }      
        
        bullet.GetComponent<Bullet>().direction = Vector3.Normalize(player.position - bullet.transform.position);
    }

    private void Life()
    {
        switch(life)
        {
            case 4:
                transform.GetChild(10).gameObject.SetActive(false);
                break;

            case 3:
                transform.GetChild(9).gameObject.SetActive(false);
                break;

            case 2:
                transform.GetChild(5).gameObject.SetActive(false);
                break;

            case 1:
                transform.GetChild(7).gameObject.SetActive(false);
                break;

            case 0:
                Destroy(gameObject);
                break;

            default:
                break;
        }
    }

    public bool IsAlive()
    {
        if (life <= 0)
            return false;

        return true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (collision.GetContact(0).normal == new Vector3(0f, -1f, 0f))
            {
                --life;
                player.AddForce(new Vector3(0f, 0.8f, 0f) * repulseForce, ForceMode.Impulse);
            }
        }
    }

    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            Shoot();
    }
}