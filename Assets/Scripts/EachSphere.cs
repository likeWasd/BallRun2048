using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EachSphere : MonoBehaviour
{
    [SerializeField] TextMeshPro sphereNumberObject;
    [SerializeField] int defaultNumberExp;
    public int sphereNumber;
    int sphereNumberExp;
    int sphereNumberKilo;
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
        sphereNumberExp = defaultNumberExp;
        numberMaterial = GameObject.Find("Player").GetComponent<PlayerMove>().numberMaterial;
        sphereNumber = (int)Mathf.Pow(2, sphereNumberExp);
        if (sphereNumberExp >= 10)
        {
            sphereNumberKilo = sphereNumberExp - 9;
            sphereNumberObject.text = sphereNumberKilo.ToString() + "k";
        }
        else
        {
            sphereNumberObject.text = sphereNumber.ToString();
        }
        gameObject.GetComponent<Renderer>().material = numberMaterial[sphereNumberExp - 1];
    }
}
