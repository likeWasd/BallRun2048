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
    // Start is called before the first frame update
    void Start()
    {
        GenerateSphere(-3f, 20f, 1);
        GenerateSphere(3f, 20f, 2);
        GenerateSphere(-3f, 35f, 4);
        GenerateSphere(3f, 35f, 2);
        GenerateSphere(-3f, 50f, 1);
        GenerateSphere(0f, 50f, 1);
        GenerateSphere(3f, 50f, 3);
        GenerateWall(75, 4);
        for (float i = 0f; i < 4f; i++)
        {
            for (float j = 0f; j < 5f; j++)
            {
                GenerateWithThorn(j * 2f - 4f, i * 7.5f + 95f, 4);
            }
        }
        for (float i = 0f; i < 5f; i++)
        {
            GenerateSphere(i * 2f - 4f, 125f, 4);
        }
        GenerateSphere(-3f, 135f, 5);
        GenerateSphere(-1f, 135f, 6);
        GenerateSphere(1f, 135f, 9);
        GenerateSphere(3f, 135f, 6);
        GenerateSphere(-3f, 145f, 9);
        GenerateSphere(-1f, 145f, 6);
        GenerateSphere(1f, 145f, 5);
        GenerateSphere(3f, 145f, 6);
        for (float i = 0f; i < 4f; i++)
        {
            GenerateSphere(i * 2f - 4f, 155f, 7);
        }
        for (float i = 0f; i < 4f; i++)
        {
            GenerateSphere(i * 2f - 3f, 165f, 8);
        }
        GenerateWall(190, 8);
        GenerateWall(250, 7);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GenerateSphere(float x, float z, int number)
    {
        cloneObject = Instantiate(spherePrefab, new Vector3(x, 0.5f, z), Quaternion.identity);
        EachSphere eachSphere = cloneObject.GetComponent<EachSphere>();
        eachSphere.Create(number);

    }

    void GenerateWall(float z, int number)
    {
        cloneObject = Instantiate(wallPrefab, new Vector3(0f, 7f, z), Quaternion.identity, wallPack.transform);
        EachSphere eachSphere = cloneObject.GetComponent<EachSphere>();
        eachSphere.Create(number);

    }

    void GenerateWithThorn(float x, float z, int number)
    {
        GenerateSphere(x, z, number);
        cloneObject = Instantiate(thornPrefab, new Vector3(x, -0.4f, z + 2.0f), Quaternion.Euler(35, 0, 45));
    }
}
