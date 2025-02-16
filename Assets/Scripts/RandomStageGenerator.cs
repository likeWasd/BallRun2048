using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomStageGenerator : MonoBehaviour
{
    [SerializeField] GameObject spherePrefab;
    [SerializeField] GameObject wallPrefab;
    [SerializeField] GameObject thornPrefab;
    [SerializeField] GameObject wallPack;
    GameObject cloneObject;
    float[][] objectDatas;
    int iLength;
    int objectZ;
    /// <summary>
    /// Sphereの数字の指数
    /// </summary>
    int allSpherePosShift;
    int sphereNumberExp;
    int allSphereDistance;
    /// <summary>
    /// sphereDistanceByNum
    /// </summary>
    int sphereDistanceByNum;
    int generateType;
    System.Random rand = new System.Random();
    // Start is called before the first frame update
    void Start()
    {
        /*
        objectDatas = new float[][]
        {
            new float[] {-3f, 20f, 1f, 0f},
            new float[] {3f, 20f, 2f, 0f},
            new float[] {-3f, 35f, 4f, 0f},
            new float[] {3f, 35f, 2f, 0f},
            new float[] {-3f, 50f, 1f, 0f},
            new float[] {0f, 50f, 1f, 0f},
            new float[] {3f, 50f, 3f, 0f},
            new float[] {0f, 75f, 4f, 1f}
        };
        for (int i = 0; i < 4; i++)
        {
            for (int sphereNumberExp = 0; sphereNumberExp < 5; sphereNumberExp++)
            {
                objectDatas[8 + i * 4 + sphereNumberExp] = new float[] {
                    (float)sphereNumberExp * 2f - 4f,
                    (float)i * 7.5f + 95f,
                    4f,
                    2f
                };
            }
        }
        for (int i = 0; i < 5; i++)
        {
            objectDatas[29 + i] = new float[] {
                    (float)i * 2f - 4f,
                    125f,
                    4f,
                    0f
            };
        }
        objectDatas[34] = new float[] { -3f, 135f, 5f, 0f };
        objectDatas[35] = new float[] { -3f, 135f, 5f, 0f };
        objectDatas[36] = new float[] { -1f, 135f, 6f, 0f };
        objectDatas[37] = new float[] { 1f, 135f, 9f, 0f };
        objectDatas[38] = new float[] { 3f, 135f, 6f, 0f };
        objectDatas[39] = new float[] { -3f, 145f, 9f, 0f };
        objectDatas[40] = new float[] { -1f, 145f, 6f, 0f };
        objectDatas[41] = new float[] { 1f, 145f, 5f, 0f };
        objectDatas[42] = new float[] { 3f, 145f, 6f, 0f };
        for (int i = 0; i < 4; i++)
        {
            objectDatas[43 + i] = new float[] { i * 2f - 4f, 155f, 7f, 0f };
        }
        for (int i = 0; i < 4; i++)
        {
            objectDatas[47 + i] = new float[] { i * 2f - 3f, 165f, 8f, 0f };
        }
        objectDatas[51] = new float[] { 0f, 190f, 8f, 1f };
        objectDatas[52] = new float[] { 0f, 250f, 7f, 1f };
        */
        allSpherePosShift = 20;
        allSphereDistance = 10;
        sphereDistanceByNum = 2;
        sphereNumberExp = 0;
        UnityEngine.Random.InitState(123);
        //iLength = rand.Next(16, 26);
        iLength = 10;
        for (int i = 0; i < iLength; i++)
        {
            objectZ = allSpherePosShift + i * allSphereDistance + sphereDistanceByNum * sphereNumberExp;
            if (i == iLength - 1)
            {
                GenerateObject(0, objectZ + 20, sphereNumberExp - 1, 1f);
            }
            else
            {
                if (i <= 4)
                {
                    GenerateSphereArray(i, 0f);
                }
                else
                {
                    if ((i + 1) % 2f == 0f)
                    {
                        GenerateSphereArray(i, 1f);
                    }
                    else
                    {
                        GenerateSphereArray(i, -1.5f);
                    }
                }
                if (i > 0) sphereNumberExp++;
            }
        }
        allSpherePosShift = 160;
        sphereNumberExp = 0;
        iLength = 15;
        for (int i = 0; i < iLength; i++)
        {
            objectZ = allSpherePosShift + i * allSphereDistance + sphereDistanceByNum * sphereNumberExp;
            if (i == iLength - 1)
            {
                GenerateObject(0, objectZ + 20, sphereNumberExp - 1, 1f);
            }
            else
            {
                if (i <= 4)
                {
                    GenerateSphereArray(i, 0f);
                }
                else
                {
                    if ((i + 1) % 2f == 0f)
                    {
                        GenerateSphereArray(i, 1f);
                    }
                    else
                    {
                        GenerateSphereArray(i, -1.5f);
                    }
                }
                if (i > 0) sphereNumberExp++;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (objectDatas != null)
        {
            GenerateObject(objectDatas[0][0], objectDatas[0][1], objectDatas[0][2], objectDatas[0][3]);
        }
        */
    }

    // xは全体的にx座標をどれくらいずらすか
    void GenerateSphereArray(int i, float x)
    {
        generateType = UnityEngine.Random.Range(0, 2);
        switch (generateType)
        {
            case 0:
                GenerateObject(   -2f + x, objectZ, 2f + sphereNumberExp, 0f);
                GenerateObject(    2f + x, objectZ, 1f + sphereNumberExp, 0f);
                if ((i + 1) % 3f == 0f)
                {
                    GenerateObject(0f + x, objectZ, 2f + sphereNumberExp, 0f);
                }
                break;
            case 1:
                GenerateObject(   -2f + x, objectZ, 1f + sphereNumberExp, 0f);
                GenerateObject(    2f + x, objectZ, 2f + sphereNumberExp, 0f);
                if ((i + 1) % 3f == 0f)
                {
                    GenerateObject(0f + x, objectZ, 1f + sphereNumberExp, 0f);
                }
                break;
            case 2:
                GenerateObject(   -2f + x, objectZ, 2f + sphereNumberExp, 0f);
                GenerateObject(    2f + x, objectZ, 2f + sphereNumberExp, 0f);
                if ((i + 1) % 3f == 0f)
                {
                    GenerateObject(0f + x, objectZ, 1f + sphereNumberExp, 0f);
                }
                break;
            default:
                break;
        }
    }

    void GenerateObject(float x, float z, float number, float type)
    {
        switch (type)
        {
            case 0:
                cloneObject = Instantiate(spherePrefab, new Vector3(x, 0.5f, z), Quaternion.identity);
                break;
            case 1:
                cloneObject = Instantiate(wallPrefab, new Vector3(0f, 7f, z), Quaternion.identity, wallPack.transform);
                break;
            case 2:
                cloneObject = Instantiate(spherePrefab, new Vector3(x, 0.5f, z), Quaternion.identity);
                break;
            default:
                break;
        }
        EachSphere eachSphere = cloneObject.GetComponent<EachSphere>();
        switch (type)
        {
            case 0:
                eachSphere.Create((int)number);
                break;
            case 1:
                eachSphere.Create((int)number);
                break;
            case 2:
                eachSphere.Create((int)number);
                cloneObject = Instantiate(thornPrefab, new Vector3(x, -0.4f, z + 2.0f), Quaternion.Euler(35, 0, 45));
                break;
            default:
                break;
        }

    }
}
