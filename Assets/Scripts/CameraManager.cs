using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void LateUpdate()
    {
        float posx = player.transform.position.x;
        float posy = player.transform.position.y;
        float posz = player.transform.position.z;
        if (posz >= 155)
        {
            transform.position = new Vector3(posx, posy + 4.5f, posz - 8);
            transform.rotation = Quaternion.Euler(5, 0, 0);
        }
        else
        {
            transform.position = new Vector3(posx, posy + 4.5f, posz - 3);
            transform.rotation = Quaternion.Euler(40, 0, 0);
        }
    }
}
