using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    /// <summary>
    /// プレイヤーが進むスピード
    /// </summary>
    int moveSpeed;
    /// <summary>
    /// プレイヤーが回るスピード
    /// </summary>
    int rotateSpeed;
    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 7;
        rotateSpeed = 2;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += moveSpeed * transform.forward * Time.deltaTime;
    }
}
