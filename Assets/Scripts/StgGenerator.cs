using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StgGenerator : MonoBehaviour
{
    [SerializeField] GameObject spherePrefab;
    [SerializeField] GameObject wallPrefab;
    [SerializeField] GameObject thornPrefab;
    [SerializeField] GameObject wallPack;
    GameObject cloneObject;
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
    int generatePresetType;
    System.Random rand = new System.Random();
    // Start is called before the first frame update
    void Start()
    {
        allSphereDistance = 10;
        sphereDistanceByNum = 2;
        UnityEngine.Random.InitState(123);
        allSpherePosShift = 20;
        sphereNumberExp = 0;
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
        allSpherePosShift = 164;
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

    }

    // xは全体的にx座標をどれくらいずらすか
    void GenerateSphereArray(int i, float x)
    {
        generateType = UnityEngine.Random.Range(0, 2);
        switch (generateType)
        {
            case 0:
                GenerateObject(-2f + x, objectZ, 2f + sphereNumberExp, 0f);
                GenerateObject(2f + x, objectZ, 1f + sphereNumberExp, 0f);
                if ((i + 1) % 3f == 0f)
                {
                    GenerateObject(0f + x, objectZ, 2f + sphereNumberExp, 0f);
                }
                break;
            case 1:
                GenerateObject(-2f + x, objectZ, 1f + sphereNumberExp, 0f);
                GenerateObject(2f + x, objectZ, 2f + sphereNumberExp, 0f);
                if ((i + 1) % 3f == 0f)
                {
                    GenerateObject(0f + x, objectZ, 1f + sphereNumberExp, 0f);
                }
                break;
            case 2:
                GenerateObject(-2f + x, objectZ, 2f + sphereNumberExp, 0f);
                GenerateObject(2f + x, objectZ, 2f + sphereNumberExp, 0f);
                if ((i + 1) % 3f == 0f)
                {
                    GenerateObject(0f + x, objectZ, 1f + sphereNumberExp, 0f);
                }
                break;
            default:
                break;
        }
    }

    void GenerateSphereArrayRandom(float x)
    {
        generatePresetType = rand.Next(0, 7);
        generateType = rand.Next(0, 26);
        switch (generateType)
        {
            case 0:
                GenerateObjectArrayPreset1(-3f, 3f, x, generatePresetType);
                break;
            case 1:
                GenerateObjectArrayPreset1(-3f, 2.5f, x, generatePresetType);
                break;
            case 2:
                GenerateObjectArrayPreset1(-3f, 2f, x, generatePresetType);
                break;
            case 4:
                GenerateObjectArrayPreset1(-2.5f, 2.5f, x, generatePresetType);
                break;
            case 5:
                GenerateObjectArrayPreset1(-2.5f, 2f, x, generatePresetType);
                break;
            case 15:
                GenerateObjectArrayPreset1(-2f, 2.5f, x, generatePresetType);
                break;
            case 32:
                GenerateObjectPreset1(-3f + x, 1f);
                GenerateObjectPreset1(-1f + x, 1f);
                GenerateObjectPreset1(1f + x, 1f);
                GenerateObjectPreset1(3f + x, 2f);
                break;
            case 33:
                GenerateObjectPreset1(-3f + x, 1f);
                GenerateObjectPreset1(-1f + x, 1f);
                GenerateObjectPreset1(1f + x, 2f);
                GenerateObjectPreset1(3f + x, 1f);
                break;
            case 34:
                GenerateObjectPreset1(-3f + x, 1f);
                GenerateObjectPreset1(-1f + x, 2f);
                GenerateObjectPreset1(1f + x, 1f);
                GenerateObjectPreset1(3f + x, 1f);
                break;
            case 35:
                GenerateObjectPreset1(-3f + x, 2f);
                GenerateObjectPreset1(-1f + x, 1f);
                GenerateObjectPreset1(1f + x, 1f);
                GenerateObjectPreset1(3f + x, 1f);
                break;
            case 36:
                GenerateObjectPreset1(-3f + x, 2f);
                GenerateObjectPreset1(-1f + x, 2f);
                GenerateObjectPreset1(1f + x, 1f);
                GenerateObjectPreset1(3f + x, 1f);
                break;
            case 37:
                GenerateObjectPreset1(-3f + x, 2f);
                GenerateObjectPreset1(-1f + x, 1f);
                GenerateObjectPreset1(1f + x, 2f);
                GenerateObjectPreset1(3f + x, 1f);
                break;
            case 38:
                GenerateObjectPreset1(-3f + x, 2f);
                GenerateObjectPreset1(-1f + x, 1f);
                GenerateObjectPreset1(1f + x, 1f);
                GenerateObjectPreset1(3f + x, 2f);
                break;
            case 39:
                GenerateObjectPreset1(-3f + x, 1f);
                GenerateObjectPreset1(-1f + x, 2f);
                GenerateObjectPreset1(1f + x, 2f);
                GenerateObjectPreset1(3f + x, 1f);
                break;
            case 40:
                GenerateObjectPreset1(-3f + x, 1f);
                GenerateObjectPreset1(-1f + x, 2f);
                GenerateObjectPreset1(1f + x, 1f);
                GenerateObjectPreset1(3f + x, 2f);
                break;
            case 41:
                GenerateObjectPreset1(-3f + x, 1f);
                GenerateObjectPreset1(-1f + x, 1f);
                GenerateObjectPreset1(1f + x, 2f);
                GenerateObjectPreset1(3f + x, 2f);
                break;
            case 42:
                GenerateObjectPreset1(-3f + x, 2f);
                GenerateObjectPreset1(-1f + x, 2f);
                GenerateObjectPreset1(1f + x, 2f);
                GenerateObjectPreset1(3f + x, 1f);
                break;
            case 43:
                GenerateObjectPreset1(-3f + x, 2f);
                GenerateObjectPreset1(-1f + x, 2f);
                GenerateObjectPreset1(1f + x, 1f);
                GenerateObjectPreset1(3f + x, 2f);
                break;
            case 44:
                GenerateObjectPreset1(-3f + x, 2f);
                GenerateObjectPreset1(-1f + x, 1f);
                GenerateObjectPreset1(1f + x, 2f);
                GenerateObjectPreset1(3f + x, 2f);
                break;
            case 45:
                GenerateObjectPreset1(-3f + x, 1f);
                GenerateObjectPreset1(-1f + x, 2f);
                GenerateObjectPreset1(1f + x, 2f);
                GenerateObjectPreset1(3f + x, 2f);
                break;
            default:
                break;
        }
    }

    void GenerateObjectArrayPreset1(float leftX, float distanceX, float shiftX, int generateType)
    {
        switch (generateType)
        {
            case 0:
                GenerateObjectPreset1(leftX + distanceX * 0 + shiftX, 2f);
                GenerateObjectPreset1(leftX + distanceX * 2 + shiftX, 1f);
                break;
            case 1:
                GenerateObjectPreset1(leftX + distanceX * 0 + shiftX, 1f);
                GenerateObjectPreset1(leftX + distanceX * 2 + shiftX, 2f);
                break;
            case 2:
                GenerateObjectPreset1(leftX + distanceX * 0 + shiftX, 2f);
                GenerateObjectPreset1(leftX + distanceX * 1 + shiftX, 1f);
                GenerateObjectPreset1(leftX + distanceX * 2 + shiftX, 1f);
                break;
            case 3:
                GenerateObjectPreset1(leftX + distanceX * 0 + shiftX, 1f);
                GenerateObjectPreset1(leftX + distanceX * 1 + shiftX, 1f);
                GenerateObjectPreset1(leftX + distanceX * 2 + shiftX, 2f);
                break;
            case 4:
                GenerateObjectPreset1(leftX + distanceX * 0 + shiftX, 2f);
                GenerateObjectPreset1(leftX + distanceX * 1 + shiftX, 2f);
                GenerateObjectPreset1(leftX + distanceX * 2 + shiftX, 1f);
                break;
            case 5:
                GenerateObjectPreset1(leftX + distanceX * 0 + shiftX, 1f);
                GenerateObjectPreset1(leftX + distanceX * 1 + shiftX, 2f);
                GenerateObjectPreset1(leftX + distanceX * 2 + shiftX, 2f);
                break;
            case 6:
                GenerateObjectPreset1(leftX + distanceX * 0 + shiftX, 2f);
                GenerateObjectPreset1(leftX + distanceX * 1 + shiftX, 1f);
                GenerateObjectPreset1(leftX + distanceX * 2 + shiftX, 2f);
                break;
            case 7:
                GenerateObjectPreset1(leftX + distanceX * 0 + shiftX, 1f);
                GenerateObjectPreset1(leftX + distanceX * 1 + shiftX, 2f);
                GenerateObjectPreset1(leftX + distanceX * 2 + shiftX, 1f);
                break;
            default:
                break;
        }
    }

    void GenerateObjectPreset1(float x, float number)
    {
        GenerateObject(x, objectZ, number + sphereNumberExp, 0f);
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
        EachObject eachObject = cloneObject.GetComponent<EachObject>();
        switch (type)
        {
            case 0:
                eachObject.Create((int)number);
                break;
            case 1:
                eachObject.Create((int)number);
                break;
            case 2:
                eachObject.Create((int)number);
                cloneObject = Instantiate(thornPrefab, new Vector3(x, -0.4f, z + 2.0f), Quaternion.Euler(35, 0, 45));
                break;
            default:
                break;
        }
    }
}
