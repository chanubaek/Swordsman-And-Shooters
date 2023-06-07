using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * It is code that controlls movement(not rotation) of the player.
 */
public class PlayerMoveController : MonoBehaviour
{
    float speed = 10.0f;
    int direction = -1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
            direction = 0;

        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
            direction = 1;
        }
        else if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            direction = 2;
        }
        else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime);
            direction = 3;
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            switch (direction)
            {
                case 0:
                    transform.Translate(Vector3.left * speed * 0.25f);
                    break;
                case 1:
                    transform.Translate(Vector3.right * speed * 0.25f);
                    break;
                case 3:
                    transform.Translate(Vector3.back * speed * 0.25f);
                    break;
                case 2:
                default:
                    transform.Translate(Vector3.forward * speed * 0.25f);
                    break;

            }
        }
    }


}
