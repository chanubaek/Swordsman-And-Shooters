using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderFrontCannonBulletGenerator : MonoBehaviour
{
    public GameObject BulletPrefab;
    GameObject spiderFrontCannonController;



    //float time = 0f;
    float timePassed = 0f;
    public bool start = false;

    // Start is called before the first frame update
    void Start()
    {
        spiderFrontCannonController = GameObject.Find("SpiderFrontCannon1");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            start = !start;
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            // �������� �̿��Ͽ� ������Ʈ ����
            GameObject bullet = Instantiate(BulletPrefab, transform.position, transform.rotation);


            // BulletController ��ũ��Ʈ�� ã�Ƽ� Shoot() �Լ� ȣ��(�Ѿ� �߻�)
            bullet.GetComponent<BulletController>().Shoot(spiderFrontCannonController.GetComponent<SpiderFrontCannonController>().dir.normalized * (650f));

            Destroy(bullet, 2f);
        }
        if (start)
        {

            timePassed += Time.deltaTime;
            if (timePassed > 1.0f)
            {
                // �������� �̿��Ͽ� ������Ʈ ����
                GameObject bullet = Instantiate(BulletPrefab, transform.position, transform.rotation);

                // BulletController ��ũ��Ʈ�� ã�Ƽ� Shoot() �Լ� ȣ��(�Ѿ� �߻�)
                bullet.GetComponent<BulletController>().Shoot(((spiderFrontCannonController.GetComponent<SpiderFrontCannonController>().dir +
                    new Vector3(0f, spiderFrontCannonController.GetComponent<SpiderFrontCannonController>().yPos
                    , 0f)).normalized + 0.2f * Vector3.down) * (1000f));
                timePassed = 0f;
                Destroy(bullet, 5f);
            }

        }
    }

}
