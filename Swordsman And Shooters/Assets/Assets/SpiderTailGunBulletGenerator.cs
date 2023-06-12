using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderTailGunBulletGenerator : MonoBehaviour
{
    public GameObject BulletPrefab;
    GameObject SpiderTailGun;



    //float time = 0f;
    float timePassed = 0f;
    public bool start = false;

    // Start is called before the first frame update
    void Start()
    {
        SpiderTailGun = GameObject.Find("SpiderTailGun");
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
            bullet.GetComponent<BulletController>().Shoot(SpiderTailGun.GetComponent<SpiderTailGunController>().dir.normalized * (650f));

            Destroy(bullet, 2f);
        }
        if (start)
        {

            timePassed += Time.deltaTime;
            if (timePassed > 4.0f)
            {
                // �������� �̿��Ͽ� ������Ʈ ����
                GameObject bullet = Instantiate(BulletPrefab, transform.position, transform.rotation);

                // BulletController ��ũ��Ʈ�� ã�Ƽ� Shoot() �Լ� ȣ��(�Ѿ� �߻�)
                //bullet.GetComponent<BulletController>().Shoot((-SpiderTailGun.GetComponent<SpiderTailGunController>().dir + 0.2f * Vector3.down) * (2500f));
                //bullet.GetComponent<BulletController>().Shoot((-spiderFrontCannonController.GetComponent<SpiderFrontCannonController>().dir + 0.2f * Vector3.down) * (2500f));
                timePassed = 0f;
                Destroy(bullet, 5f);
            }
        }
    }

}
