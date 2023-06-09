using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealthController : MonoBehaviour
{
    GameObject playerLife1;
    GameObject playerLife2;
    GameObject playerLife3;
    public bool playerDead=false;

    int playerHealth = 3;
    // Start is called before the first frame update
    void Start()
    {
        playerLife1 = GameObject.Find("life1");
        playerLife2 = GameObject.Find("life2");
        playerLife3 = GameObject.Find("life3");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "BULLET")
        {
            if(!collision.collider.GetComponent<BulletController>().hit)
            {
                switch (playerHealth)
                {
                    case 3:
                        Destroy(playerLife3);
                        playerHealth--;
                        collision.collider.GetComponent<BulletController>().hit = true;
                        Destroy(collision.collider);
                        break;
                    case 2:
                        Destroy(playerLife2);
                        playerHealth--;
                        collision.collider.GetComponent<BulletController>().hit = true;
                        Destroy(collision.collider);
                        break;
                    case 1:
                        Destroy(playerLife1);
                        playerHealth--;
                        collision.collider.GetComponent<BulletController>().hit = true;
                        Destroy(collision.collider);
                        break;
                }

                if (playerHealth <= 0)
                {
                    playerDead = true;
                }
            }

        }
    }
}
