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
        generatePresetType = rand.Next(0, 13);
        generateType = rand.Next(0, 17);
        switch (generateType)
        {
            case 0:
                GenerateObjectArray3(-3.0f, 3.0f, x, generatePresetType);
                break;
            case 1:
                GenerateObjectArray3(-3.0f, 2.5f, x, generatePresetType);
                break;
            case 2:
                GenerateObjectArray3(-3.0f, 2.0f, x, generatePresetType);
                break;
            case 3:
                GenerateObjectArray4(-3.0f, 2.0f, x, generatePresetType);
                break;
            case 4:
                GenerateObjectArray3(-3.0f, 1.8f, x, generatePresetType);
                break;
            case 5:
                GenerateObjectArray4(-3.0f, 1.8f, x, generatePresetType);
                break;
            case 6:
                GenerateObjectArray3(-3.0f, 1.6f, x, generatePresetType);
                break;
            case 7:
                GenerateObjectArray4(-3.0f, 1.6f, x, generatePresetType);
                break;
            case 8:
                GenerateObjectArray3(-2.5f, 2.5f, x, generatePresetType);
                break;
            case 9:
                GenerateObjectArray3(-2.5f, 2.0f, x, generatePresetType);
                break;
            case 10:
                GenerateObjectArray3(-2.5f, 1.8f, x, generatePresetType);
                break;
            case 11:
                GenerateObjectArray3(-2.5f, 1.6f, x, generatePresetType);
                break;
            case 12:
                GenerateObjectArray4(-2.5f, 1.6f, x, generatePresetType);
                break;
            case 13:
                GenerateObjectArray3(-2.0f, 2.5f, x, generatePresetType);
                break;
            case 14:
                GenerateObjectArray3(-2.0f, 2.0f, x, generatePresetType);
                break;
            case 15:
                GenerateObjectArray3(-2.0f, 1.8f, x, generatePresetType);
                break;
            case 16:
                GenerateObjectArray3(-2.0f, 1.6f, x, generatePresetType);
                break;
            default:
                break;
        }
    }

    void GenerateObjectArray3(float leftX, float distanceX, float shiftX, int generateType)
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
            case 8:
                GenerateObjectPreset1(leftX + distanceX * 0 + shiftX, 2f);
                GenerateObjectPreset1(leftX + distanceX * 1 + shiftX, 1f);
                GenerateObjectPreset1(leftX + distanceX * 2 + shiftX, 1f);
                break;
            case 3:
            case 9:
                GenerateObjectPreset1(leftX + distanceX * 0 + shiftX, 1f);
                GenerateObjectPreset1(leftX + distanceX * 1 + shiftX, 1f);
                GenerateObjectPreset1(leftX + distanceX * 2 + shiftX, 2f);
                break;
            case 4:
            case 10:
                GenerateObjectPreset1(leftX + distanceX * 0 + shiftX, 2f);
                GenerateObjectPreset1(leftX + distanceX * 1 + shiftX, 2f);
                GenerateObjectPreset1(leftX + distanceX * 2 + shiftX, 1f);
                break;
            case 5:
            case 11:
                GenerateObjectPreset1(leftX + distanceX * 0 + shiftX, 1f);
                GenerateObjectPreset1(leftX + distanceX * 1 + shiftX, 2f);
                GenerateObjectPreset1(leftX + distanceX * 2 + shiftX, 2f);
                break;
            case 6:
            case 12:
                GenerateObjectPreset1(leftX + distanceX * 0 + shiftX, 2f);
                GenerateObjectPreset1(leftX + distanceX * 1 + shiftX, 1f);
                GenerateObjectPreset1(leftX + distanceX * 2 + shiftX, 2f);
                break;
            case 7:
            case 13:
                GenerateObjectPreset1(leftX + distanceX * 0 + shiftX, 1f);
                GenerateObjectPreset1(leftX + distanceX * 1 + shiftX, 2f);
                GenerateObjectPreset1(leftX + distanceX * 2 + shiftX, 1f);
                break;
            default:
                break;
        }
    }

    void GenerateObjectArray4(float leftX, float distanceX, float shiftX, int generateType)
    {

        switch (generateType)
        {
            case 0:
                GenerateObjectPreset1(leftX + distanceX * 0 + shiftX, 1f);
                GenerateObjectPreset1(leftX + distanceX * 1 + shiftX, 1f);
                GenerateObjectPreset1(leftX + distanceX * 2 + shiftX, 1f);
                GenerateObjectPreset1(leftX + distanceX * 3 + shiftX, 2f);
                break;
            case 1:
                GenerateObjectPreset1(leftX + distanceX * 0 + shiftX, 1f);
                GenerateObjectPreset1(leftX + distanceX * 1 + shiftX, 1f);
                GenerateObjectPreset1(leftX + distanceX * 2 + shiftX, 2f);
                GenerateObjectPreset1(leftX + distanceX * 3 + shiftX, 1f);
                break;
            case 2:
                GenerateObjectPreset1(leftX + distanceX * 0 + shiftX, 1f);
                GenerateObjectPreset1(leftX + distanceX * 1 + shiftX, 2f);
                GenerateObjectPreset1(leftX + distanceX * 2 + shiftX, 1f);
                GenerateObjectPreset1(leftX + distanceX * 3 + shiftX, 1f);
                break;
            case 3:
                GenerateObjectPreset1(leftX + distanceX * 0 + shiftX, 2f);
                GenerateObjectPreset1(leftX + distanceX * 1 + shiftX, 1f);
                GenerateObjectPreset1(leftX + distanceX * 2 + shiftX, 1f);
                GenerateObjectPreset1(leftX + distanceX * 3 + shiftX, 1f);
                break;
            case 4:
                GenerateObjectPreset1(leftX + distanceX * 0 + shiftX, 2f);
                GenerateObjectPreset1(leftX + distanceX * 1 + shiftX, 2f);
                GenerateObjectPreset1(leftX + distanceX * 2 + shiftX, 1f);
                GenerateObjectPreset1(leftX + distanceX * 3 + shiftX, 1f);
                break;
            case 5:
                GenerateObjectPreset1(leftX + distanceX * 0 + shiftX, 2f);
                GenerateObjectPreset1(leftX + distanceX * 1 + shiftX, 1f);
                GenerateObjectPreset1(leftX + distanceX * 2 + shiftX, 2f);
                GenerateObjectPreset1(leftX + distanceX * 3 + shiftX, 1f);
                break;
            case 6:
                GenerateObjectPreset1(leftX + distanceX * 0 + shiftX, 2f);
                GenerateObjectPreset1(leftX + distanceX * 1 + shiftX, 1f);
                GenerateObjectPreset1(leftX + distanceX * 2 + shiftX, 1f);
                GenerateObjectPreset1(leftX + distanceX * 3 + shiftX, 2f);
                break;
            case 7:
                GenerateObjectPreset1(leftX + distanceX * 0 + shiftX, 1f);
                GenerateObjectPreset1(leftX + distanceX * 1 + shiftX, 2f);
                GenerateObjectPreset1(leftX + distanceX * 2 + shiftX, 2f);
                GenerateObjectPreset1(leftX + distanceX * 3 + shiftX, 1f);
                break;
            case 8:
                GenerateObjectPreset1(leftX + distanceX * 0 + shiftX, 1f);
                GenerateObjectPreset1(leftX + distanceX * 1 + shiftX, 2f);
                GenerateObjectPreset1(leftX + distanceX * 2 + shiftX, 1f);
                GenerateObjectPreset1(leftX + distanceX * 3 + shiftX, 2f);
                break;
            case 9:
                GenerateObjectPreset1(leftX + distanceX * 0 + shiftX, 1f);
                GenerateObjectPreset1(leftX + distanceX * 1 + shiftX, 1f);
                GenerateObjectPreset1(leftX + distanceX * 2 + shiftX, 2f);
                GenerateObjectPreset1(leftX + distanceX * 3 + shiftX, 2f);
                break;
            case 10:
                GenerateObjectPreset1(leftX + distanceX * 0 + shiftX, 2f);
                GenerateObjectPreset1(leftX + distanceX * 1 + shiftX, 2f);
                GenerateObjectPreset1(leftX + distanceX * 2 + shiftX, 2f);
                GenerateObjectPreset1(leftX + distanceX * 3 + shiftX, 1f);
                break;
            case 11:
                GenerateObjectPreset1(leftX + distanceX * 0 + shiftX, 2f);
                GenerateObjectPreset1(leftX + distanceX * 1 + shiftX, 2f);
                GenerateObjectPreset1(leftX + distanceX * 2 + shiftX, 1f);
                GenerateObjectPreset1(leftX + distanceX * 3 + shiftX, 2f);
                break;
            case 12:
                GenerateObjectPreset1(leftX + distanceX * 0 + shiftX, 2f);
                GenerateObjectPreset1(leftX + distanceX * 1 + shiftX, 1f);
                GenerateObjectPreset1(leftX + distanceX * 2 + shiftX, 2f);
                GenerateObjectPreset1(leftX + distanceX * 3 + shiftX, 2f);
                break;
            case 13:
                GenerateObjectPreset1(leftX + distanceX * 0 + shiftX, 1f);
                GenerateObjectPreset1(leftX + distanceX * 1 + shiftX, 2f);
                GenerateObjectPreset1(leftX + distanceX * 2 + shiftX, 2f);
                GenerateObjectPreset1(leftX + distanceX * 3 + shiftX, 2f);
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
