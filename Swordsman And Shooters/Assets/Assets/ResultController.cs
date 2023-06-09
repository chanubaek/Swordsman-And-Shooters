using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResultController : MonoBehaviour
{
    bool result = false;

    GameObject playerBody;
    GameObject enemyBody;

    GameObject playerPrefab;
    GameObject enemyPrefab;


    // Start is called before the first frame update
    void Start()
    {
        playerBody = GameObject.Find("PlayerBody");
        enemyBody = GameObject.Find("EnemyBody");

        playerPrefab = GameObject.Find("PlayerPrefab");
        enemyPrefab = GameObject.Find("EnemyPrefab");
    }

    // Update is called once per frame
    void Update()
    {
        TextMeshProUGUI textmeshPro = this.GetComponent<TextMeshProUGUI>();

        if(!result)
        {
            if (playerBody.GetComponent<PlayerHealthController>().playerDead)
            {
                textmeshPro.text = "You Lose!";
                Debug.Log("You Lose!");
                result = true;

                Destroy(enemyPrefab);
                Destroy(playerPrefab);
            }
            if (enemyBody.GetComponent<EnemyHealthController>().enemyDead)
            {
                textmeshPro.text = "You Win!";
                Debug.Log("You Win!");
                result = true;

                Destroy(enemyPrefab);
                Destroy(playerPrefab);
            }
        }

    }
}
