using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * It is code that controlls movement(not rotation) of the player.
 */
public class PlayerMoveController : MonoBehaviour
{
    GameObject background;
    GameObject playerBody;

    float speed = 3.5f;
    int direction = -1;
    bool keyNotInputted = true;
    float time = 0f;

    Vector3 originalPosition;

    // Start is called before the first frame update
    void Start()
    {
        originalPosition = transform.position;
        background = GameObject.Find("Background");
        playerBody = GameObject.Find("PlayerBody");
    }

    // Update is called keyNotInputted per frame
    void Update()
    {

        
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
            direction = 0;
            keyNotInputted = false;

        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
            direction = 1;
            keyNotInputted = false;
        }
        else if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            direction = 2;
            keyNotInputted = false;
        }
        else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime);
            direction = 3;
            keyNotInputted = false;
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            switch (direction)
            {
                case 0:
                    transform.Translate(Vector3.left * speed * 0.5f);
                    break;
                case 1:
                    transform.Translate(Vector3.right * speed * 0.5f);
                    break;
                case 3:
                    transform.Translate(Vector3.back * speed * 0.5f);
                    break;
                case 2:
                default:
                    transform.Translate(Vector3.forward * speed * 0.5f);
                    break;

            }
            keyNotInputted = false;
        }

        if (
            (Input.GetKeyUp(KeyCode.A))|| (Input.GetKeyUp(KeyCode.S))|| (Input.GetKeyUp(KeyCode.D))|| (Input.GetKeyUp(KeyCode.W))
            || (Input.GetKeyUp(KeyCode.LeftArrow)) || (Input.GetKeyUp(KeyCode.DownArrow)) || (Input.GetKeyUp(KeyCode.RightArrow)) || (Input.GetKeyUp(KeyCode.UpArrow))
            || (Input.GetKeyUp(KeyCode.LeftShift))
            )   // 키보드 뗐을 때, 뗀 시점의 위치로 player의 위치를 저장.
        {
            time = 0f;
            originalPosition = transform.position;
            keyNotInputted = true;

        }

        if (keyNotInputted)  // 키보드 입력 안 했을 때, 키보드를 뗀 순간 저장한 player의 위치 그대로 player를 고정.
        {
            transform.position = originalPosition;
        }
        if(background.GetComponent<FallController>().playerFall)
        {
            transform.position += new Vector3(0f, -1f, 0f);
            playerBody.GetComponent<PlayerHealthController>().playerDead = true;
        }
    }
}
