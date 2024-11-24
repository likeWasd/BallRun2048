using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EachSphereManager : MonoBehaviour
{
    [SerializeField] TextMeshPro sphereNumberObject;
    public int sphereNumber;
    int sphereNumberKilo;
    [SerializeField] Material[] numberMaterials = new Material[10];
    // Start is called before the first frame update
    void Start()
    {
        if (sphereNumberObject.text.Contains("k"))
        {
            sphereNumberKilo = int.Parse(Regex.Replace(sphereNumberObject.text, @"[^0-9]", ""));
            sphereNumber = (int)Mathf.Pow(2, sphereNumberKilo + 9);
        }
        else
        {
            sphereNumber = int.Parse(sphereNumberObject.text);
            GetComponent<MeshRenderer>().material = numberMaterials[0];
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
