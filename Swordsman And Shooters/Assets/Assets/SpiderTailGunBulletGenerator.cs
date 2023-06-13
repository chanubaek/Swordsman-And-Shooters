using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderTailGunBulletGenerator : MonoBehaviour
{
    public GameObject BulletPrefab;
    GameObject spiderTailController;
    //GameObject spider

    public Vector3 direction;


    //float time = 0f;
    float timePassed = 0f;
    public bool start = false;

    // Start is called before the first frame update
    void Start()
    {
        spiderTailController = GameObject.Find("SpiderTailJoint1");
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = spiderTailController.GetComponent<SpiderTailController>().direction;
        direction = this.transform.position - spiderTailController.GetComponent<SpiderTailController>().position;
        direction.y = 0f;
        
        //transform.Rotate(Vector3.up * Time.deltaTime * 100f);
        if (Input.GetKeyDown(KeyCode.O))
        {
            start = !start;
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            // �������� �̿��Ͽ� ������Ʈ ����
            GameObject bullet = Instantiate(BulletPrefab, transform.position, transform.rotation);


            // BulletController ��ũ��Ʈ�� ã�Ƽ� Shoot() �Լ� ȣ��(�Ѿ� �߻�)
            bullet.GetComponent<BulletController>().Shoot(direction* (650f));

            Destroy(bullet, 2f);
        }
        if (start)
        {
            //direction = spiderTailController.GetComponent<SpiderTailController>().direction;
            direction = this.transform.position - spiderTailController.GetComponent<SpiderTailController>().position;
            direction.y = 0f;

            timePassed += Time.deltaTime;
            if (timePassed > 0.01f)
            {
                // �������� �̿��Ͽ� ������Ʈ ����
                GameObject bullet = Instantiate(BulletPrefab, transform.position, transform.rotation);
                //GameObject bullet = Instantiate(BulletPrefab, transform.position, spiderTailController.GetComponent<SpiderTailController>().direction);
                //GameObject bullet = Instantiate(BulletPrefab, transform.position,Vector3.forward.);

                // BulletController ��ũ��Ʈ�� ã�Ƽ� Shoot() �Լ� ȣ��(�Ѿ� �߻�)
                bullet.GetComponent<BulletController>().Shoot(direction*1000f);
                //bullet.GetComponent<BulletController>().Shoot(Vector3.back * 2000f);
                //bullet.GetComponent<BulletController>().Shoot(-spiderTailController.GetComponent<SpiderTailController>().direction.eulerAngles * 1000f);
                //bullet.GetComponent<BulletController>().Shoot((spiderTailController.GetComponent<SpiderTailController>().direction) * (2500f));
                //bullet.GetComponent<BulletController>().Shoot((spiderTailController.GetComponent<SpiderTailController>().direction) * (2500f));
                //bullet.GetComponent<BulletController>().Shoot((-SpiderTailGun.GetComponent<SpiderTailGunController>().dir + 0.2f * Vector3.down) * (2500f));
                //bullet.GetComponent<BulletController>().Shoot((-SpiderTailGun.GetComponent<SpiderTailGunController>().dir + 0.2f * Vector3.down) * (2500f));
                //bullet.GetComponent<BulletController>().Shoot((-spiderFrontCannonController.GetComponent<SpiderFrontCannonController>().dir + 0.2f * Vector3.down) * (2500f));
                timePassed = 0f;
                Destroy(bullet, 2f);
            }
        }
    }

}
