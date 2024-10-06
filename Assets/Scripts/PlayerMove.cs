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
        if (collision.gameObject.CompareTag("Sphere_2") && sphereNumber.text == "2")
        {
            GetComponent<Renderer>().material.color = Color.red;
            sphereNumber.text = "4";
        }
        else if (collision.gameObject.CompareTag("Sphere_4") && sphereNumber.text == "4")
        {
            GetComponent<Renderer>().material.color = Color.white;
            sphereNumber.text = "8";
        }
        else if (collision.gameObject.CompareTag("Sphere_8") && sphereNumber.text == "8")
        {
            GetComponent<Renderer>().material.color = Color.red;
            sphereNumber.text = "16";
        }
        else if (collision.gameObject.CompareTag("Sphere_16") && sphereNumber.text == "16")
        {
            GetComponent<Renderer>().material.color = Color.white;
            sphereNumber.text = "32";
        }
        else if (collision.gameObject.CompareTag("Sphere_32") && sphereNumber.text == "32")
        {
            GetComponent<Renderer>().material.color = Color.red;
            sphereNumber.text = "64";
        }
        else if (collision.gameObject.CompareTag("Sphere_64") && sphereNumber.text == "64")
        {
            GetComponent<Renderer>().material.color = Color.white;
            sphereNumber.text = "128";
        }
        else if (collision.gameObject.CompareTag("Sphere_128") && sphereNumber.text == "128")
        {
            GetComponent<Renderer>().material.color = Color.red;
            sphereNumber.text = "256";
        }
        else if (collision.gameObject.CompareTag("Sphere_256") && sphereNumber.text == "256")
        {
            GetComponent<Renderer>().material.color = Color.white;
            sphereNumber.text = "512";
        }
        else if (collision.gameObject.CompareTag("Sphere_512") && sphereNumber.text == "512")
        {
            GetComponent<Renderer>().material.color = Color.white;
            sphereNumber.text = "1024";
        }
    }
}
