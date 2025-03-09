using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EachObject : MonoBehaviour
{
    [SerializeField] TextMeshPro objectNumberObject;
    [SerializeField] int defaultObjectNumberExp;
    public int objectNumber;
    int objectNumberExp;
    int objectNumberKilo;
    int objectNumberKiloExp;
    public Material[] numberMaterial;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Create(int defaultNumberExp)
    {
        objectNumberExp = defaultNumberExp;
        numberMaterial = GameObject.Find("Player").GetComponent<PlayerMove>().numberMaterial;
        objectNumber = (int)Mathf.Pow(2, objectNumberExp);
        if (objectNumberExp >= 10)
        {
            objectNumberKiloExp = objectNumberExp - 9;
            objectNumberKilo = (int)Mathf.Pow(2, objectNumberKiloExp - 1); ;
            objectNumberObject.text = objectNumberKilo.ToString() + "k";
        }
        else
        {
            objectNumberObject.text = objectNumber.ToString();
        }
        gameObject.GetComponent<Renderer>().material = numberMaterial[objectNumberExp - 1];
    }
}
