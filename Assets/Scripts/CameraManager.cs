using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public GameObject player;
    [SerializeField] GameObject wallPack;
    Transform wallPackT;
    Transform[] walls;
    float[] wallsZ;
    bool isFinished;
    int wallNth;
    // Start is called before the first frame update
    void Start()
    {
        isFinished = false;
        wallPackT = wallPack.transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (!isFinished)
        {
            walls = new Transform[wallPackT.childCount];
            for (int i = 0; i < walls.Length; i++)
            {
                walls[i] = wallPackT.GetChild(i);
            }
            wallsZ = new float[walls.Length];
            for (int i = 0; i < wallsZ.Length; i++)
            {
                wallsZ[i] = walls[i].position.z;
            }
            isFinished = true;
        }
        float posx = player.transform.position.x;
        float posy = player.transform.position.y;
        float posz = player.transform.position.z;
        for (int i = 0; (float)i < wallsZ.Length; i++)
        {
            if (posz < wallsZ[i])
            {
                wallNth = i;
                break;
            }
        }
        if (posz + 20f >= wallsZ[wallNth] && posz < wallsZ[wallNth])
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
