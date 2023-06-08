using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGenerator : MonoBehaviour
{
    public GameObject BulletPrefab;
    GameObject enemyGun;

    //float time = 0f;
    float timePassed = 0f;
    public bool start = false;

    // Start is called before the first frame update
    void Start()
    {
        enemyGun = GameObject.Find("EnemyGun");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.O))
        {
            start = !start;
        }

        if(Input.GetKeyDown(KeyCode.P))
        {
            // �������� �̿��Ͽ� ������Ʈ ����
            GameObject bullet = Instantiate(BulletPrefab, transform.position, transform.rotation);

            // BulletController ��ũ��Ʈ�� ã�Ƽ� Shoot() �Լ� ȣ��(�Ѿ� �߻�)
            bullet.GetComponent<BulletController>().Shoot(enemyGun.GetComponent<GunController>().dir.normalized * (1500f));

            Destroy(bullet, 2f);
        }
        if(start)
        {
            timePassed += Time.deltaTime;
            if (timePassed > 0.9f)
            {
                // �������� �̿��Ͽ� ������Ʈ ����
                GameObject bullet = Instantiate(BulletPrefab, transform.position, transform.rotation);

                // BulletController ��ũ��Ʈ�� ã�Ƽ� Shoot() �Լ� ȣ��(�Ѿ� �߻�)
                bullet.GetComponent<BulletController>().Shoot(enemyGun.GetComponent<GunController>().dir.normalized * (1500f));
                timePassed = 0f;
                Destroy(bullet, 3f);
            }
        }
    }

}
