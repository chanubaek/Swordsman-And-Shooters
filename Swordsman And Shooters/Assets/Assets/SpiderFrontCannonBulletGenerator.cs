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
            // 프리팹을 이용하여 오브젝트 생성
            GameObject bullet = Instantiate(BulletPrefab, transform.position, transform.rotation);


            // BulletController 스크립트를 찾아서 Shoot() 함수 호출(총알 발사)
            bullet.GetComponent<BulletController>().Shoot(spiderFrontCannonController.GetComponent<SpiderFrontCannonController>().dir.normalized * (650f));

            Destroy(bullet, 2f);
        }
        if (start)
        {

            timePassed += Time.deltaTime;
            if (timePassed > 1.0f)
            {
                // 프리팹을 이용하여 오브젝트 생성
                GameObject bullet = Instantiate(BulletPrefab, transform.position, transform.rotation);

                // BulletController 스크립트를 찾아서 Shoot() 함수 호출(총알 발사)
                //bullet.GetComponent<BulletController>().Shoot(((spiderFrontCannonController.GetComponent<SpiderFrontCannonController>().dir +
                //    new Vector3(0f, spiderFrontCannonController.GetComponent<SpiderFrontCannonController>().yPos
                //    , 0f)).normalized + 0.2f * Vector3.down) * (2000f));
                bullet.GetComponent<BulletController>().Shoot(spiderFrontCannonController.GetComponent<SpiderFrontCannonController>().dir.normalized  * 2000f);
                timePassed = 0f;
                Destroy(bullet, 5f);
            }

        }
    }

}
