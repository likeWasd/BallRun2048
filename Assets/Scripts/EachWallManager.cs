using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EachWallManager : MonoBehaviour
{
    [SerializeField] TextMeshPro wallNumberObject;
    public int wallNumber;
    // Start is called before the first frame update
    void Start()
    {
        wallNumber = int.Parse(wallNumberObject.text);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
