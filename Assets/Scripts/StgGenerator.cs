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
    [SerializeField] GameObject spherePack;
    GameObject cloneObject;
    int iLength;
    int objectZ;
    /// <summary>
    /// Sphereの数字の指数
    /// </summary>
    int allSpherePosShift;
    int objNumExp;
    int allSphereDistance;
    /// <summary>
    /// objDistanceByNum
    /// </summary>
    int objDistanceByNum;
    int generateType;
    int generatePresetType;
    System.Random rand = new System.Random();
    // Start is called before the first frame update
    void Start()
    {
        allSphereDistance = 10;
        objDistanceByNum = 2;
        UnityEngine.Random.InitState(123);
        allSpherePosShift = 20;
        objNumExp = 0;
        if (GameVariableManager.stageNum == 1)
        {
            iLength = 10;
            for (int i = 0; i < iLength; i++)
            {
                objectZ = allSpherePosShift + i * allSphereDistance + objDistanceByNum * objNumExp;
                if (i == iLength - 1)
                {
                    GenerateObject(0, objectZ + 20, objNumExp - 1, 1f);
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
                    if (i > 0) objNumExp++;
                }
            }
        }
        else if (GameVariableManager.stageNum == 2)
        {
            iLength = 15;
            for (int i = 0; i < iLength; i++)
            {
                objectZ = allSpherePosShift + i * allSphereDistance + objDistanceByNum * objNumExp;
                if (i == iLength - 1)
                {
                    GenerateObject(0, objectZ + 20, objNumExp - 1, 1f);
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
                    if (i > 0) objNumExp++;
                }
            }
        }
        else if (GameVariableManager.stageNum == 3)
        {
            iLength = 12;
            for (int i = 0; i < iLength; i++)
            {
                objectZ = allSpherePosShift + i * allSphereDistance + objDistanceByNum * objNumExp;
                GenerateSphereArrayRandom(0, 0);
                if (i > 0) objNumExp++;
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
                GenerateObject(-2f + x, objectZ, 2f + objNumExp, 0f);
                GenerateObject(2f + x, objectZ, 1f + objNumExp, 0f);
                if ((i + 1) % 3f == 0f)
                {
                    GenerateObject(0f + x, objectZ, 2f + objNumExp, 0f);
                }
                break;
            case 1:
                GenerateObject(-2f + x, objectZ, 1f + objNumExp, 0f);
                GenerateObject(2f + x, objectZ, 2f + objNumExp, 0f);
                if ((i + 1) % 3f == 0f)
                {
                    GenerateObject(0f + x, objectZ, 1f + objNumExp, 0f);
                }
                break;
            case 2:
                GenerateObject(-2f + x, objectZ, 2f + objNumExp, 0f);
                GenerateObject(2f + x, objectZ, 2f + objNumExp, 0f);
                if ((i + 1) % 3f == 0f)
                {
                    GenerateObject(0f + x, objectZ, 1f + objNumExp, 0f);
                }
                break;
            default:
                break;
        }
    }

    void GenerateSphereArrayRandom(float x, float numExp)
    {
        generatePresetType = rand.Next(0, 13);
        generateType = rand.Next(0, 16);
        switch (generateType)
        {
            case 0:
                GenerateObjectArray3(-3.0f, 3.0f, x, numExp, generatePresetType);
                break;
            case 1:
                GenerateObjectArray3(-3.0f, 2.5f, x, numExp, generatePresetType);
                break;
            case 2:
                GenerateObjectArray3(-3.0f, 2.0f, x, numExp, generatePresetType);
                break;
            case 3:
                GenerateObjectArray4(-3.0f, 2.0f, x, numExp, generatePresetType);
                break;
            case 4:
                GenerateObjectArray3(-3.0f, 1.8f, x, numExp, generatePresetType);
                break;
            case 5:
                GenerateObjectArray4(-3.0f, 1.8f, x, numExp, generatePresetType);
                break;
            case 6:
                GenerateObjectArray3(-3.0f, 1.6f, x, numExp, generatePresetType);
                break;
            case 7:
                GenerateObjectArray4(-3.0f, 1.6f, x, numExp, generatePresetType);
                break;
            case 8:
                GenerateObjectArray3(-2.5f, 2.5f, x, numExp, generatePresetType);
                break;
            case 9:
                GenerateObjectArray3(-2.5f, 2.0f, x, numExp, generatePresetType);
                break;
            case 10:
                GenerateObjectArray3(-2.5f, 1.8f, x, numExp, generatePresetType);
                break;
            case 11:
                GenerateObjectArray3(-2.5f, 1.6f, x, numExp, generatePresetType);
                break;
            case 12:
                GenerateObjectArray4(-2.5f, 1.6f, x, numExp, generatePresetType);
                break;
            case 13:
                GenerateObjectArray3(-2.0f, 2.5f, x, numExp, generatePresetType);
                break;
            case 14:
                GenerateObjectArray3(-2.0f, 2.0f, x, numExp, generatePresetType);
                break;
            case 15:
                GenerateObjectArray3(-2.0f, 1.8f, x, numExp, generatePresetType);
                break;
            case 16:
                GenerateObjectArray3(-2.0f, 1.6f, x, numExp, generatePresetType);
                break;
            default:
                break;
        }
    }

    void GenerateObjectArray3(float leftX, float distanceX, float shiftX, float numExp, int generateType)
    {
        switch (generateType)
        {
            case 0:
                GenerateObjectPreset(leftX + distanceX * 0 + shiftX, numExp + 2f);
                GenerateObjectPreset(leftX + distanceX * 2 + shiftX, numExp + 1f);
                break;
            case 1:
                GenerateObjectPreset(leftX + distanceX * 0 + shiftX, numExp + 1f);
                GenerateObjectPreset(leftX + distanceX * 2 + shiftX, numExp + 2f);
                break;
            case 2:
            case 8:
                GenerateObjectPreset(leftX + distanceX * 0 + shiftX, numExp + 2f);
                GenerateObjectPreset(leftX + distanceX * 1 + shiftX, numExp + 1f);
                GenerateObjectPreset(leftX + distanceX * 2 + shiftX, numExp + 1f);
                break;
            case 3:
            case 9:
                GenerateObjectPreset(leftX + distanceX * 0 + shiftX, numExp + 1f);
                GenerateObjectPreset(leftX + distanceX * 1 + shiftX, numExp + 1f);
                GenerateObjectPreset(leftX + distanceX * 2 + shiftX, numExp + 2f);
                break;
            case 4:
            case 10:
                GenerateObjectPreset(leftX + distanceX * 0 + shiftX, numExp + 2f);
                GenerateObjectPreset(leftX + distanceX * 1 + shiftX, numExp + 2f);
                GenerateObjectPreset(leftX + distanceX * 2 + shiftX, numExp + 1f);
                break;
            case 5:
            case 11:
                GenerateObjectPreset(leftX + distanceX * 0 + shiftX, numExp + 1f);
                GenerateObjectPreset(leftX + distanceX * 1 + shiftX, numExp + 2f);
                GenerateObjectPreset(leftX + distanceX * 2 + shiftX, numExp + 2f);
                break;
            case 6:
            case 12:
                GenerateObjectPreset(leftX + distanceX * 0 + shiftX, numExp + 2f);
                GenerateObjectPreset(leftX + distanceX * 1 + shiftX, numExp + 1f);
                GenerateObjectPreset(leftX + distanceX * 2 + shiftX, numExp + 2f);
                break;
            case 7:
            case 13:
                GenerateObjectPreset(leftX + distanceX * 0 + shiftX, numExp + 1f);
                GenerateObjectPreset(leftX + distanceX * 1 + shiftX, numExp + 2f);
                GenerateObjectPreset(leftX + distanceX * 2 + shiftX, numExp + 1f);
                break;
            default:
                break;
        }
    }

    void GenerateObjectArray4(float leftX, float distanceX, float shiftX, float numExp, int generateType)
    {

        switch (generateType)
        {
            case 0:
                GenerateObjectPreset(leftX + distanceX * 0 + shiftX, numExp + 1f);
                GenerateObjectPreset(leftX + distanceX * 1 + shiftX, numExp + 1f);
                GenerateObjectPreset(leftX + distanceX * 2 + shiftX, numExp + 1f);
                GenerateObjectPreset(leftX + distanceX * 3 + shiftX, numExp + 2f);
                break;
            case 1:
                GenerateObjectPreset(leftX + distanceX * 0 + shiftX, numExp + 1f);
                GenerateObjectPreset(leftX + distanceX * 1 + shiftX, numExp + 1f);
                GenerateObjectPreset(leftX + distanceX * 2 + shiftX, numExp + 2f);
                GenerateObjectPreset(leftX + distanceX * 3 + shiftX, numExp + 1f);
                break;
            case 2:
                GenerateObjectPreset(leftX + distanceX * 0 + shiftX, numExp + 1f);
                GenerateObjectPreset(leftX + distanceX * 1 + shiftX, numExp + 2f);
                GenerateObjectPreset(leftX + distanceX * 2 + shiftX, numExp + 1f);
                GenerateObjectPreset(leftX + distanceX * 3 + shiftX, numExp + 1f);
                break;
            case 3:
                GenerateObjectPreset(leftX + distanceX * 0 + shiftX, numExp + 2f);
                GenerateObjectPreset(leftX + distanceX * 1 + shiftX, numExp + 1f);
                GenerateObjectPreset(leftX + distanceX * 2 + shiftX, numExp + 1f);
                GenerateObjectPreset(leftX + distanceX * 3 + shiftX, numExp + 1f);
                break;
            case 4:
                GenerateObjectPreset(leftX + distanceX * 0 + shiftX, numExp + 2f);
                GenerateObjectPreset(leftX + distanceX * 1 + shiftX, numExp + 2f);
                GenerateObjectPreset(leftX + distanceX * 2 + shiftX, numExp + 1f);
                GenerateObjectPreset(leftX + distanceX * 3 + shiftX, numExp + 1f);
                break;
            case 5:
                GenerateObjectPreset(leftX + distanceX * 0 + shiftX, numExp + 2f);
                GenerateObjectPreset(leftX + distanceX * 1 + shiftX, numExp + 1f);
                GenerateObjectPreset(leftX + distanceX * 2 + shiftX, numExp + 2f);
                GenerateObjectPreset(leftX + distanceX * 3 + shiftX, numExp + 1f);
                break;
            case 6:
                GenerateObjectPreset(leftX + distanceX * 0 + shiftX, numExp + 2f);
                GenerateObjectPreset(leftX + distanceX * 1 + shiftX, numExp + 1f);
                GenerateObjectPreset(leftX + distanceX * 2 + shiftX, numExp + 1f);
                GenerateObjectPreset(leftX + distanceX * 3 + shiftX, numExp + 2f);
                break;
            case 7:
                GenerateObjectPreset(leftX + distanceX * 0 + shiftX, numExp + 1f);
                GenerateObjectPreset(leftX + distanceX * 1 + shiftX, numExp + 2f);
                GenerateObjectPreset(leftX + distanceX * 2 + shiftX, numExp + 2f);
                GenerateObjectPreset(leftX + distanceX * 3 + shiftX, numExp + 1f);
                break;
            case 8:
                GenerateObjectPreset(leftX + distanceX * 0 + shiftX, numExp + 1f);
                GenerateObjectPreset(leftX + distanceX * 1 + shiftX, numExp + 2f);
                GenerateObjectPreset(leftX + distanceX * 2 + shiftX, numExp + 1f);
                GenerateObjectPreset(leftX + distanceX * 3 + shiftX, numExp + 2f);
                break;
            case 9:
                GenerateObjectPreset(leftX + distanceX * 0 + shiftX, numExp + 1f);
                GenerateObjectPreset(leftX + distanceX * 1 + shiftX, numExp + 1f);
                GenerateObjectPreset(leftX + distanceX * 2 + shiftX, numExp + 2f);
                GenerateObjectPreset(leftX + distanceX * 3 + shiftX, numExp + 2f);
                break;
            case 10:
                GenerateObjectPreset(leftX + distanceX * 0 + shiftX, numExp + 2f);
                GenerateObjectPreset(leftX + distanceX * 1 + shiftX, numExp + 2f);
                GenerateObjectPreset(leftX + distanceX * 2 + shiftX, numExp + 2f);
                GenerateObjectPreset(leftX + distanceX * 3 + shiftX, numExp + 1f);
                break;
            case 11:
                GenerateObjectPreset(leftX + distanceX * 0 + shiftX, numExp + 2f);
                GenerateObjectPreset(leftX + distanceX * 1 + shiftX, numExp + 2f);
                GenerateObjectPreset(leftX + distanceX * 2 + shiftX, numExp + 1f);
                GenerateObjectPreset(leftX + distanceX * 3 + shiftX, numExp + 2f);
                break;
            case 12:
                GenerateObjectPreset(leftX + distanceX * 0 + shiftX, numExp + 2f);
                GenerateObjectPreset(leftX + distanceX * 1 + shiftX, numExp + 1f);
                GenerateObjectPreset(leftX + distanceX * 2 + shiftX, numExp + 2f);
                GenerateObjectPreset(leftX + distanceX * 3 + shiftX, numExp + 2f);
                break;
            case 13:
                GenerateObjectPreset(leftX + distanceX * 0 + shiftX, numExp + 1f);
                GenerateObjectPreset(leftX + distanceX * 1 + shiftX, numExp + 2f);
                GenerateObjectPreset(leftX + distanceX * 2 + shiftX, numExp + 2f);
                GenerateObjectPreset(leftX + distanceX * 3 + shiftX, numExp + 2f);
                break;
            default:
                break;
        }
    }

    void GenerateObjectPreset(float x, float numExp)
    {
        GenerateObject(x, objectZ, numExp + objNumExp, 0f);
    }

    void GenerateObject(float x, float z, float numExp, float type)
    {
        switch (type)
        {
            case 0:
                cloneObject = Instantiate(spherePrefab, new Vector3(x, 0.5f, z), Quaternion.identity);
                cloneObject.transform.SetParent(spherePack.transform, false);
                break;
            case 1:
                cloneObject = Instantiate(wallPrefab, new Vector3(0f, 7f, z), Quaternion.identity, wallPack.transform);
                break;
            case 2:
                cloneObject = Instantiate(spherePrefab, new Vector3(x, 0.5f, z), Quaternion.identity);
                cloneObject.transform.SetParent(spherePack.transform, false);
                break;
            default:
                break;
        }
        EachObject eachObj = cloneObject.GetComponent<EachObject>();
        switch (type)
        {
            case 0:
                eachObj.Create((int)numExp);
                break;
            case 1:
                eachObj.Create((int)numExp);
                break;
            case 2:
                eachObj.Create((int)numExp);
                cloneObject = Instantiate(thornPrefab, new Vector3(x, -0.4f, z + 2.0f), Quaternion.Euler(35, 0, 45));
                break;
            default:
                break;
        }
    }
}
