using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EachWallManager : MonoBehaviour
{
    [SerializeField] TextMeshPro wallNumberObject;
    public int wallNumber;
    int wallNumberKilo;
    // Start is called before the first frame update
    void Start()
    {
        if (wallNumberObject.text.Contains("k"))
        {
            wallNumberKilo = int.Parse(Regex.Replace(wallNumberObject.text, @"[^0-9]", ""));
            wallNumber = (int)Mathf.Pow(2, wallNumberKilo + 9);
        }
        else
        {
            wallNumber = int.Parse(wallNumberObject.text);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
