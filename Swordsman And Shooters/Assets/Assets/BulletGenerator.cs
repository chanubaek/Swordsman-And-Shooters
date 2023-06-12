using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGenerator : MonoBehaviour
{
    public GameObject BulletPrefab;
    GameObject enemyGun;

    GameObject spiderCannonController;


    //float time = 0f;
    float timePassed = 0f;
    public bool start = false;

    // Start is called before the first frame update
    void Start()
    {
        enemyGun = GameObject.Find("EnemyGun");
        spiderCannonController = GameObject.Find("SpiderCannonSphere");
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
            // 프리팹을 이용하여 오브젝트 생성
            GameObject bullet = Instantiate(BulletPrefab, transform.position, transform.rotation);


            // BulletController 스크립트를 찾아서 Shoot() 함수 호출(총알 발사)
            bullet.GetComponent<BulletController>().Shoot(enemyGun.GetComponent<GunController>().dir.normalized * (650f));

            Destroy(bullet, 2f);
        }
        if(start)
        {

            timePassed += Time.deltaTime;
            if (timePassed > 0.01f)
            {
                // 프리팹을 이용하여 오브젝트 생성
                GameObject bullet = Instantiate(BulletPrefab, transform.position, transform.rotation);

                // BulletController 스크립트를 찾아서 Shoot() 함수 호출(총알 발사)
                //bullet.GetComponent<BulletController>().Shoot( (enemyGun.GetComponent<GunController>().dir.normalized+Vector3.down) * (1000f));
                //bullet.GetComponent<BulletController>().Shoot( (Vector3.forward) * (1000f));
                bullet.GetComponent<BulletController>().Shoot( (spiderCannonController.GetComponent<SpiderFrontCannonController>().dir + 0.2f * Vector3.down ) * (1000f));
                timePassed = 0f;
                Destroy(bullet, 2f);
            }
        }
    }

}
