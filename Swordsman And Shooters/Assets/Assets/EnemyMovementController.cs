using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementController : MonoBehaviour
{
    float speed;                    // 이동 속도
    private float moveRate;         // 이동 간격(Start() 함수에서 랜덤으로 결정)
    private float timeAfterMove;    // 이동 후 지나간 시간
    Vector3 direction;
    Vector3 direction2;
    public Vector3 RetDir;
    GameObject enemy;
    public GameObject EnemyPrefab;
    GameObject bulletGenerator;

    // Start is called before the first frame update
    void Start()
    {

        speed = 8.0f;
        moveRate = 0.5f;

        timeAfterMove = 0f;
        direction2 = Vector3.zero;

        bulletGenerator = GameObject.Find("BulletGenerator");
    }

    // Update is called once per frame
    void Update()
    {
        if(bulletGenerator.GetComponent<BulletGenerator>().start)
        {
            if (timeAfterMove > moveRate)
            {
                direction = new Vector3(Random.Range(-1.0f, 1.0f), 0f, Random.Range(-1.0f, 1.0f));
                direction = direction.normalized * speed; // direction : 새롭게 이동할 벡터
                direction2 = this.transform.position;
                direction2 += direction;                // direction2 : 이동 후 예상 좌표

                if ((this.transform.position.x < 8.0f) && (this.transform.position.x > -8.0f) && (this.transform.position.z < 8.0f) && (this.transform.position.z > -8.0f)) // 현재 위치가 바닥을 벗어나지 않았을 때
                {
                    if ((direction2.x > 8.0f) || (direction2.x < -8.0f) || (direction2.z > 8.0f) || (direction2.z < -8.0f))   // 새로 갈 곳의 예상 좌표가 바닥을 벗어나는 경우, 중앙으로 향함.
                    {
                        direction = this.transform.position * (-1f);
                        direction = direction.normalized * speed;
                    }
                    else  // 새로 갈 곳의 예상 좌표가 바닥을 벗어나지 않는 경우, 그대로 진행함
                    {
                    }

                }
                else  // 현재 위치가 바닥을 벗어났을 때, 중앙으로 감
                {
                    direction = this.transform.position * (-1f);
                    direction = direction.normalized * speed;

                }
                timeAfterMove = 0f;

            }
            else
            {
                this.transform.Translate((direction * Time.deltaTime));
                timeAfterMove += Time.deltaTime;    // 이동 후 지나간 시간에 Time.deltaTime 더하기
            }
        }

    }
}
