using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public GameObject player;
    Transform wallPack;
    Transform[] walls;
    float[] wallsZ;
    // Start is called before the first frame update
    void Start()
    {
        wallPack = GameObject.Find("WallPack").transform;
        walls = new Transform[wallPack.childCount];
        for (int i = 0; i < walls.Length; i++)
        {
            walls[i] = wallPack.GetChild(i);
        }
        wallsZ = new float[walls.Length];
        for (int i = 0; i < walls.Length; i++)
        {
            wallsZ[i] = walls[i].position.z;
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        float posx = player.transform.position.x;
        float posy = player.transform.position.y;
        float posz = player.transform.position.z;
        for (int i = 0; i < walls.Length; i++)
        {
            if (posz >= wallsZ[i] - 20 && posz < wallsZ[i])
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
}
