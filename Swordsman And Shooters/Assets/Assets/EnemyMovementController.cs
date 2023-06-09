using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementController : MonoBehaviour
{
    float speed;                    // �̵� �ӵ�
    private float moveRate;         // �̵� ����(Start() �Լ����� �������� ����)
    private float timeAfterMove;    // �̵� �� ������ �ð�
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
                direction = direction.normalized * speed; // direction : ���Ӱ� �̵��� ����
                direction2 = this.transform.position;
                direction2 += direction;                // direction2 : �̵� �� ���� ��ǥ

                if ((this.transform.position.x < 8.0f) && (this.transform.position.x > -8.0f) && (this.transform.position.z < 8.0f) && (this.transform.position.z > -8.0f)) // ���� ��ġ�� �ٴ��� ����� �ʾ��� ��
                {
                    if ((direction2.x > 8.0f) || (direction2.x < -8.0f) || (direction2.z > 8.0f) || (direction2.z < -8.0f))   // ���� �� ���� ���� ��ǥ�� �ٴ��� ����� ���, �߾����� ����.
                    {
                        direction = this.transform.position * (-1f);
                        direction = direction.normalized * speed;
                    }
                    else  // ���� �� ���� ���� ��ǥ�� �ٴ��� ����� �ʴ� ���, �״�� ������
                    {
                    }

                }
                else  // ���� ��ġ�� �ٴ��� ����� ��, �߾����� ��
                {
                    direction = this.transform.position * (-1f);
                    direction = direction.normalized * speed;

                }
                timeAfterMove = 0f;

            }
            else
            {
                this.transform.Translate((direction * Time.deltaTime));
                timeAfterMove += Time.deltaTime;    // �̵� �� ������ �ð��� Time.deltaTime ���ϱ�
            }
        }

    }
}
