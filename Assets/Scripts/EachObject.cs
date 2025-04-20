using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EachObject : MonoBehaviour
{
    [SerializeField] TextMeshPro objNumObject;
    [SerializeField] int defaultObjNumExp;
    public int objNum;
    int objNumExp;
    int objNumKilo;
    public Material[] objNumMaterial;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Create(int defaultNumExp)
    {
        objNumExp = defaultNumExp;
        objNumMaterial = GameObject.Find("RAM").gameObject.GetComponent<GameVariableManager>().MaterialDataBaseII.Sphere;
        objNum = (int)Mathf.Pow(2, objNumExp);
        objNumKilo = objNum / 1024;
        if (objNumExp >= 10)
        {
            objNumObject.text = objNumKilo.ToString() + "k";
        }
        else
        {
            objNumObject.text = objNum.ToString();
        }
        gameObject.GetComponent<Renderer>().material = objNumMaterial[objNumExp - 1];
    }
}
