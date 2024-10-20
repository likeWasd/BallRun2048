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
    int number;
    [SerializeField] Material[] numberMaterials = new Material[10];
    // Start is called before the first frame update
    void Start()
    {
        moveSpeedF = 7;
        moveSpeedLR = 10;
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
        if (collision.gameObject.CompareTag("Thorn"))
        {
            number = int.Parse(sphereNumber.text) / 2;
            sphereNumber.text = number.ToString();
        }
        if (collision.gameObject.CompareTag("Sphere_2") && sphereNumber.text == "2")
        {
            Destroy(collision.gameObject);
            GetComponent<Renderer>().material = numberMaterials[2];
            sphereNumber.text = "4";
        }
        else if (collision.gameObject.CompareTag("Sphere_4") && sphereNumber.text == "4")
        {
            Destroy(collision.gameObject);
            GetComponent<Renderer>().material = numberMaterials[3];
            sphereNumber.text = "8";
        }
        else if (collision.gameObject.CompareTag("Sphere_8") && sphereNumber.text == "8")
        {
            Destroy(collision.gameObject);
            GetComponent<Renderer>().material = numberMaterials[4];
            sphereNumber.text = "16";
        }
        else if (collision.gameObject.CompareTag("Sphere_16") && sphereNumber.text == "16")
        {
            Destroy(collision.gameObject);
            GetComponent<Renderer>().material = numberMaterials[5];
            sphereNumber.text = "32";
        }
        else if (collision.gameObject.CompareTag("Sphere_32") && sphereNumber.text == "32")
        {
            Destroy(collision.gameObject);
            GetComponent<Renderer>().material = numberMaterials[6];
            sphereNumber.text = "64";
        }
        else if (collision.gameObject.CompareTag("Sphere_64") && sphereNumber.text == "64")
        {
            Destroy(collision.gameObject);
            GetComponent<Renderer>().material = numberMaterials[7];
            sphereNumber.text = "128";
        }
        else if (collision.gameObject.CompareTag("Sphere_128") && sphereNumber.text == "128")
        {
            Destroy(collision.gameObject);
            GetComponent<Renderer>().material = numberMaterials[8];
            sphereNumber.text = "256";
        }
        else if (collision.gameObject.CompareTag("Sphere_256") && sphereNumber.text == "256")
        {
            Destroy(collision.gameObject);
            GetComponent<Renderer>().material = numberMaterials[9];
            sphereNumber.text = "512";
        }
        else if (collision.gameObject.CompareTag("Sphere_512") && sphereNumber.text == "512")
        {
            Destroy(collision.gameObject);
            GetComponent<Renderer>().material = numberMaterials[10];
            sphereNumber.text = "1k";
        }
    }
}
