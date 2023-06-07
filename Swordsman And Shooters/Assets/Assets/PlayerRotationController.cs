using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * It is code that controlls whole rotation of the player. 
 */
public class PlayerRotationController : MonoBehaviour
{
    public Vector3 playerToMouse;    // Vector variable that stores direction from player to mouse pointer.

    // Below are vector variables that store direction from the rotated player.
    public Vector3 playerRight;
    public Vector3 playerLeft;
    public Vector3 playerForward;
    public Vector3 playerBack;
    public Vector3 playerUp;
    public Vector3 playerDown;

    // Below are vector variables that store joint angle when the player starts swing.
    Vector3 startBodyAngle;
    Vector3 startJoint1Angle;
    Vector3 startJoint2Angle;
    Vector3 startWaistAngle;


    Vector3 endBodyAngle;
    Vector3 endJoint1Angle;
    Vector3 endJoint2Angle;
    Vector3 endWaistAngle;

    // Below are vector variables that store joint angle speed while the player swings.
    float deltaBodyAngle;
    float deltaJoint1Angle;
    float deltaJoint1YPos;
    float deltaWaistAngle;
    float deltaJoint2Angle;
    float deltaJoint2YPos;

    Vector3 currentBodyAngle;
    Vector3 currentJoint1Angle;
    Vector3 currentWaistAngle;
    Vector3 currentJoint2Angle;


    GameObject playerJoint1;
    GameObject playerWaist;
    GameObject playerJoint2;

    bool clickStarted = false;
    public bool swing = false;
    Vector3 positionOfMouse;

    float distanceLength = 0f;


    // Start is called before the first frame update
    void Start()
    {
        playerJoint1 = GameObject.Find("PlayerJoint1");
        playerWaist = GameObject.Find("PlayerWaist");
        playerJoint2 = GameObject.Find("PlayerJoint2");
    }
    void AdjustPlayerToMouse()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Vector3 playerToMouseCandidate;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            positionOfMouse = hit.point;
            playerToMouseCandidate = hit.point - transform.position;
            if ((playerToMouseCandidate.x* playerToMouseCandidate.x + playerToMouseCandidate.z* playerToMouseCandidate.z) > 20f)
            {
                playerToMouse = hit.point - transform.position;
                startBodyAngle = playerToMouse;
                playerToMouse.y = 0;
                this.transform.rotation = Quaternion.LookRotation((-1) * playerToMouse);
            }

        }
        playerRight = playerToMouse.normalized;
        playerLeft = ((-1f) * playerRight).normalized;
        playerUp = new Vector3(0f, 1f, 0f).normalized;
        playerDown = -playerUp;
        playerForward = Vector3.Cross(playerRight, playerUp).normalized;
        playerBack = ((-1f) * playerForward).normalized;

        startJoint1Angle = (1.5f * playerRight + playerUp).normalized;
        startWaistAngle = (playerRight + playerBack).normalized;
        startJoint2Angle = (1.5f * playerRight + playerUp).normalized;

        currentBodyAngle = playerToMouse;
        currentJoint1Angle = startJoint1Angle;
        currentWaistAngle = startWaistAngle;
        currentJoint2Angle = startJoint2Angle;

        deltaBodyAngle = 0.2f;
        deltaJoint1Angle = 0.2f;
        deltaJoint1YPos = 0.02f;
        deltaWaistAngle = 0.17f;
        deltaJoint2Angle = 0.2f;
        deltaJoint2YPos = 0.02f;
    }

    // Update is called once per frame
    void Update()
    {
        if (!clickStarted)
        {
            AdjustPlayerToMouse();
            playerWaist.transform.rotation = Quaternion.LookRotation((-1f)*playerToMouse, (-1f)*playerToMouse);
            playerJoint1.transform.rotation = Quaternion.LookRotation((-1f)*playerToMouse, (-1f)*playerToMouse);
            //playerJoint2.transform.rotation = Quaternion.LookRotation((-1f)*playerToMouse, (-1f)*playerToMouse);
        }
        if (Input.GetMouseButtonDown(0))
        {
            clickStarted = true;
            playerWaist.transform.rotation = Quaternion.LookRotation((-1f) * startWaistAngle, (-1f) * startWaistAngle);
            playerJoint1.transform.rotation = Quaternion.LookRotation((-1f) * startJoint1Angle, (-1f) * startJoint1Angle);
            playerJoint2.transform.rotation = Quaternion.LookRotation((-1f) * startJoint2Angle, (-1f) * startJoint2Angle);
            distanceLength = 0f;
        }
        else if (Input.GetMouseButton(0))
        {
            //Ray ray2 = Camera.main.ScreenPointToRay(Input.mousePosition);
            //RaycastHit hit2;
            //Vector3 distance;

            //if (Physics.Raycast(ray2, out hit2, Mathf.Infinity))
            //{
            //    distance = positionOfMouse - hit2.point;
            //    distance.y = 0;
            //    distanceLength = distance.x * distance.x + distance.y * distance.y + distance.z * distance.z;
            //    distanceLength *= 0.03f;

            swing = true;

            if (Input.GetMouseButton(1))
            {
                distanceLength += 108f * Time.deltaTime;

                if (startJoint1Angle.y - distanceLength * deltaJoint1YPos>-0.05f)
                {
                    currentBodyAngle =
                        new Vector3
                        (
                            startBodyAngle.x * Mathf.Cos(distanceLength * deltaBodyAngle) - startBodyAngle.z * Mathf.Sin(distanceLength * deltaBodyAngle),
                            0f,
                            startBodyAngle.x * Mathf.Sin(distanceLength * deltaBodyAngle) + startBodyAngle.z * Mathf.Cos(distanceLength * deltaBodyAngle)
                        );

                    currentJoint1Angle =
                        new Vector3
                        (
                            startJoint1Angle.x * Mathf.Cos(distanceLength * deltaJoint1Angle) - startJoint1Angle.z * Mathf.Sin(distanceLength * deltaJoint1Angle),
                            startJoint1Angle.y - distanceLength * deltaJoint1YPos,
                            startJoint1Angle.x * Mathf.Sin(distanceLength * deltaJoint1Angle) + startJoint1Angle.z * Mathf.Cos(distanceLength * deltaJoint1Angle)
                        );

                    currentWaistAngle =
                        new Vector3
                        (
                            startWaistAngle.x * Mathf.Cos(distanceLength * deltaWaistAngle) - startWaistAngle.z * Mathf.Sin(distanceLength * deltaWaistAngle),
                            0f,
                            startWaistAngle.x * Mathf.Sin(distanceLength * deltaWaistAngle) + startWaistAngle.z * Mathf.Cos(distanceLength * deltaWaistAngle)
                        );

                    currentJoint2Angle =
                        new Vector3
                        (
                            startJoint2Angle.x * Mathf.Cos(distanceLength * deltaJoint2Angle) - startJoint2Angle.z * Mathf.Sin(distanceLength * deltaJoint2Angle),
                            startJoint2Angle.y - distanceLength * deltaJoint2YPos,
                            startJoint2Angle.x * Mathf.Sin(distanceLength * deltaJoint2Angle) + startJoint2Angle.z * Mathf.Cos(distanceLength * deltaJoint2Angle)
                        );

                    this.transform.rotation = Quaternion.LookRotation((-1f) * currentBodyAngle, (-1f) * currentBodyAngle);
                    playerWaist.transform.rotation = Quaternion.LookRotation((-1f) * currentWaistAngle, (-1f) * currentWaistAngle);
                    playerJoint1.transform.rotation = Quaternion.LookRotation((-1f) * currentJoint1Angle, (-1f) * currentJoint1Angle);
                    playerJoint2.transform.rotation = Quaternion.LookRotation((-1f) * currentJoint2Angle, (-1f) * currentJoint2Angle);
                }
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            AdjustPlayerToMouse();
            playerWaist.transform.rotation = Quaternion.LookRotation((-1f)*playerToMouse, (-1f)*playerToMouse);
            playerJoint1.transform.rotation = Quaternion.LookRotation((-1f)*playerToMouse, (-1f)*playerToMouse);
            //playerJoint2.transform.rotation = Quaternion.LookRotation((-1f)*playerToMouse, (-1f)*playerToMouse);
        }
        else
        {
            AdjustPlayerToMouse();
        }
    }
}

