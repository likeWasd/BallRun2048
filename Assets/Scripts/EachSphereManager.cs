using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EachSphereManager : MonoBehaviour
{
    [SerializeField] TextMeshPro sphereNumberObject;
    public int sphereNumber;
    int sphereNumberExp;
    int sphereNumberKilo;
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
            sphereNumberExp = (int)Mathf.Log(sphereNumber, 2);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
