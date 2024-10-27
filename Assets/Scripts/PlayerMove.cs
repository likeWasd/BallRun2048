using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMove : MonoBehaviour
{
    // プレイヤーが進むスピード(FはForward)
    int moveSpeedF;
    // プレイヤーが進むスピード(LRはLeftRight)
    int moveSpeedLR;
    [SerializeField] TextMeshPro sphereNumber;
    int halfSphereNumber;
    int sphereNumberExp;
    [SerializeField] Material[] numberMaterials = new Material[10];
    // Start is called before the first frame update
    void Start()
    {
        moveSpeedF = 7;
        moveSpeedLR = 10;
        sphereNumberExp = 1;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += moveSpeedF * transform.forward * Time.deltaTime;
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position -= moveSpeedLR * transform.right * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += moveSpeedLR * transform.right * Time.deltaTime;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Thorn") && int.Parse(sphereNumber.text) >= 4)
        {
            halfSphereNumber = int.Parse(sphereNumber.text) / 2;
            sphereNumberExp--;
            GetComponent<MeshRenderer>().material = numberMaterials[sphereNumberExp - 1];
            sphereNumber.text = halfSphereNumber.ToString();
        }
        if (collision.gameObject.CompareTag("Sphere_" + Mathf.Pow(2, sphereNumberExp).ToString()) && sphereNumber.text == Mathf.Pow(2, sphereNumberExp).ToString())
        {
            Destroy(collision.gameObject);
            sphereNumberExp++;
            GetComponent<MeshRenderer>().material = numberMaterials[sphereNumberExp - 1];
            sphereNumber.text = Mathf.Pow(2, sphereNumberExp).ToString();
            if (sphereNumber.text == "1024")
            {
                sphereNumber.text = "1k";
            }
        }
    }
}
