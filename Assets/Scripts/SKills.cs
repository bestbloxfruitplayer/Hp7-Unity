using System;
using System.Collections;
using UnityEngine;

public class Skills : MonoBehaviour
{
    public GameObject Bucket;
    private bool isCollecting = false;
    private int lavaCollected = 0;
    public GameObject UnleaseSkill;
    public GameObject Boss;
    private int bossHealth = 3;

    void Start()
    {
        Bucket.SetActive(false);
        UnleaseSkill.SetActive(false);
    }

    void Update()
    {
        HandleInputE(); 
        Unleasing();
        if(bossHealth <= 0)
        {
            Boss.SetActive(false);
        }
    }

    private void HandleInputE()
    {
        if (Input.GetKey(KeyCode.E))
        {
            Bucket.SetActive(true);
            isCollecting = true;
        }
        else
        {
            isCollecting = false;
            Bucket.SetActive(false);
        }
    }

   

    void OnTriggerStay2D(Collider2D collision)
    {
        if (isCollecting == true && collision.CompareTag("consumeLava"))
        {
            collision.gameObject.SetActive(false);
            lavaCollected += 1;
        }
    }

    void Unleasing()
    {
        if (Input.GetMouseButtonDown(0) && lavaCollected >= 1)
        {
            lavaCollected--;
            UnleaseSkill.SetActive(true);
            UnleaseSkill.transform.position = transform.position;
            bossHealth--;
        }
    }

}

