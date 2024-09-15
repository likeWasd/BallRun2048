using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // プレイヤーが進むスピード(FはForward)
    int moveSpeedF;
    // プレイヤーが進むスピード(LRはLeftRight)
    int moveSpeedLR;
    // Start is called before the first frame update
    void Start()
    {
        moveSpeedF = 7;
        moveSpeedLR = 10;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += moveSpeedF * transform.forward * Time.deltaTime;
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position -= moveSpeedLR * transform.right * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += moveSpeedLR * transform.right * Time.deltaTime;
        }
    }
}
