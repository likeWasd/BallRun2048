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
    // Start is called before the first frame update
    void Start()
    {
        objectDatas = new float[][]
        {
            new float[] {-3f, 20f, 1f, 0f},
            new float[] {3f, 20f, 2f, 0f},
            new float[] {-3f, 35f, 4f, 0f},
            new float[] {3f, 35f, 2f, 0f},
            new float[] {-3f, 50f, 1f, 0f},
            new float[] {0f, 50f, 1f, 0f},
            new float[] {3f, 50f, 3f, 0f},
            new float[] {75f, 4f, 1f}
        };
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                objectDatas[8 + i * 4 + j] = new float[] {
                    (float)j * 2f - 4f,
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
        objectDatas[35] = new float[] { -3f, 135f, 5 };
        objectDatas[36] = new float[] { -1f, 135f, 6 };
        objectDatas[37] = new float[] { 1f, 135f, 9 };
        objectDatas[38] = new float[] { 3f, 135f, 6 };
        objectDatas[39] = new float[] { -3f, 145f, 9 };
        objectDatas[40] = new float[] { -1f, 145f, 6 };
        objectDatas[41] = new float[] { 1f, 145f, 5 };
        objectDatas[42] = new float[] { 3f, 145f, 6 };
        for (int i = 0; i < 4; i++)
        {
            objectDatas[43 + i] = new float[] { i * 2f - 4f, 155f, 7f, 0f };
        }
        for (int i = 0; i < 4; i++)
        {
            objectDatas[47 + i] = new float[] { i * 2f - 3f, 165f, 8f, 0f };
        }
        objectDatas[51] = new float[] { 190f, 8f, 1f };
        objectDatas[52] = new float[] { 250f, 7f, 1f };
    }

    // Update is called once per frame
    void Update()
    {
        if (objectDatas != null)
        {
            switch (objectDatas[0][3])
            {
                case 0f:
                case 2f:
                    GenerateSphere(objectDatas[0][0], objectDatas[0][1], objectDatas[0][2], 0f);
                    break;
                case 1f:
                    GenerateSphere(0f, objectDatas[0][0], objectDatas[0][1], 1f);
                    break;
            }
            objectDatas[0] = null;
        }
    }

    void GenerateSphere(float x, float z, float number, float type)
    {
        EachSphere eachSphere = cloneObject.GetComponent<EachSphere>();
        switch (type)
        {
            case 0:
                cloneObject = Instantiate(spherePrefab, new Vector3(x, 0.5f, z), Quaternion.identity);
                eachSphere.Create((int)number);
                break;
            case 1:
                cloneObject = Instantiate(wallPrefab, new Vector3(0f, 7f, z), Quaternion.identity, wallPack.transform);
                eachSphere.Create((int)number);
                break;
            case 2:
                cloneObject = Instantiate(spherePrefab, new Vector3(x, 0.5f, z), Quaternion.identity);
                eachSphere.Create((int)number);
                cloneObject = Instantiate(thornPrefab, new Vector3(x, -0.4f, z + 2.0f), Quaternion.Euler(35, 0, 45));
                break;
            default:
                break;
        }

    }
}
