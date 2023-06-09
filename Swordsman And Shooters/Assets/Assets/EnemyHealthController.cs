using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthController : MonoBehaviour
{
    GameObject enemyHealth;
    GameObject playerBody;

    int enemyHealthPoint = 400;
    public bool enemyDead=false;

    float time;

    // Start is called before the first frame update
    void Start()
    {
        enemyHealth = GameObject.Find("EnemyHealthImage");
        playerBody = GameObject.Find("PlayerBody");
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnCollisionEnter(Collision collision)
    {
        if ((playerBody.GetComponent<PlayerRotationController>().swing) && collision.collider.tag == "SWORD")
        {
            playerBody.GetComponent<PlayerRotationController>().swing = false;
            enemyHealthPoint -= 140;
            RectTransform rectTran = enemyHealth.GetComponent<RectTransform>();
            rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, enemyHealthPoint);
            if (enemyHealthPoint <= 0)
            {
                enemyDead = true;
            }

        }
    }
}
