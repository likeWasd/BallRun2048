using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialStageGenerator : MonoBehaviour
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
    // Start is called before the first frame update
    void Start()
    {
        allSphereDistance = 10;
        sphereDistanceByNum = 2;
        Random.InitState(123);
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

    void GenerateObject(float x, float z, float number, float type)
    {
        Debug.Log("Created");
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
