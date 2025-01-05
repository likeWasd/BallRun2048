using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomStageGenerator : MonoBehaviour
{
    [SerializeField] GameObject spherePrefab;
    GameObject a;
    // Start is called before the first frame update
    void Start()
    {
        Generate(0f, 2f, 205f, 9);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Generate(float x, float y, float z, int number)
    {
        a = Instantiate(spherePrefab, new Vector3(x, y, z), Quaternion.identity);
        EachSphere eachSphere = a.GetComponent<EachSphere>();
        eachSphere.Create(number);

    }
}
