using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
    int sphereNumberKiloExp;
    [SerializeField] Material[] numberMaterials = new Material[10];
    [SerializeField] int defaultNumberExp = 1;
    int eachWallNumber;
    // Start is called before the first frame update
    void Start()
    {
        moveSpeedF = 7;
        moveSpeedLR = 10;
        sphereNumberExp = 1;
        ChangeNumber(defaultNumberExp);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z < 180)
        {
            transform.position += moveSpeedF * transform.forward * Time.deltaTime;
        }
        else
        {

        }
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
            moveSpeedF -= 2;
        }
        if (collision.gameObject.CompareTag("Sphere_" + Mathf.Pow(2, sphereNumberExp).ToString()) && sphereNumber.text == Mathf.Pow(2, sphereNumberExp).ToString())
        {
            Destroy(collision.gameObject);
            sphereNumberExp++;
            GetComponent<MeshRenderer>().material = numberMaterials[sphereNumberExp - 1];
            sphereNumber.text = Mathf.Pow(2, sphereNumberExp).ToString();
            if (sphereNumberExp >= 10)
            {
                sphereNumberKiloExp = int.Parse(sphereNumber.text) / 1000;
                sphereNumber.text = sphereNumberKiloExp + "k";
            }
            moveSpeedF += 2;
        }
        if (collision.gameObject.CompareTag("Wall"))
        {
            eachWallNumber = collision.gameObject.GetComponent<EachWallManager>().wallNumber;

            if (Mathf.Pow(2, sphereNumberExp) >= eachWallNumber)
            {
                Destroy(collision.gameObject);
            }
            else
            {
                GameVariableManager.retryTimes++;
                // SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                SceneManager.UnloadSceneAsync("GameScene");
                SceneManager.LoadScene("GameScene", LoadSceneMode.Additive);
            }
        }
    }

    void ChangeNumber(int numberExp)
    {
        sphereNumberExp = numberExp;
        GetComponent<MeshRenderer>().material = numberMaterials[sphereNumberExp - 1];
        sphereNumber.text = Mathf.Pow(2, sphereNumberExp).ToString();
        if (sphereNumber.text == "1024")
        {
            sphereNumber.text = "1k";
        }
        moveSpeedF = numberExp * 2 + 5;
    }
}
