using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;

public class EachSphereAndWall : MonoBehaviour
{
    [SerializeField] TextMeshPro objectNumberObject;
    public int objectNumber;
    int objectNumberExp;
    int objectNumberKilo;
    public Material[] numberMaterial;
    // Start is called before the first frame update
    void Start()
    {
        numberMaterial = GameObject.Find("Player").GetComponent<Renderer>().materials;
        if (objectNumberObject.text.Contains("k"))
        {
            objectNumberKilo = int.Parse(Regex.Replace(objectNumberObject.text, @"[^0-9]", ""));
            objectNumber = (int)Mathf.Pow(2, objectNumberKilo + 9);
        }
        else
        {
            objectNumber = int.Parse(objectNumberObject.text);
        }
        objectNumberExp = (int)Mathf.Log(objectNumber, 2);
        gameObject.GetComponent<Renderer>().material = numberMaterial[objectNumberExp];
    }

    // Update is called once per frame
    void Update()
    {

    }
}
