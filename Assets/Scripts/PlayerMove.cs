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
    [SerializeField] int defaultNumberExp = 1;
    int eachWallNumber;
    float clearElapsedTime;
    int clearRetryTimes;
    [SerializeField] TextMeshProUGUI stringTextGoal;
    [SerializeField] TextMeshProUGUI stringTextResult;
    [SerializeField] TextMeshProUGUI timeText;
    [SerializeField] TextMeshProUGUI retriedText;
    EachSphereManager eachSphereManager;
    // Start is called before the first frame update
    void Start()
    {
        moveSpeedF = 7;
        moveSpeedLR = 10;
        sphereNumberExp = 1;
        ChangeNumber(defaultNumberExp);
        stringTextGoal.enabled = false;
        stringTextResult.enabled = false;
        timeText.enabled = false;
        retriedText.enabled = false;
        eachSphereManager = GameObject.Find("SphereMaterialList").GetComponent<EachSphereManager>();
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
            clearElapsedTime = GameVariableManager.elapsedTime;
            clearRetryTimes = GameVariableManager.retryTimes;
            timeText.text = clearElapsedTime.ToString("f3");
            retriedText.text = clearRetryTimes.ToString();
            stringTextGoal.enabled = true;
            stringTextResult.enabled = true;
            timeText.enabled = true;
            retriedText.enabled = true;
            UnityEditor.EditorApplication.isPaused = true;
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
            GetComponent<Renderer>().material = eachSphereManager.numberMaterials[sphereNumberExp - 1];
            sphereNumber.text = halfSphereNumber.ToString();
            moveSpeedF -= 2;
        }
        if (collision.gameObject.CompareTag("Sphere") && sphereNumber.text == Mathf.Pow(2, sphereNumberExp).ToString())
        {
            Destroy(collision.gameObject);
            sphereNumberExp++;
            GetComponent<Renderer>().material = eachSphereManager.numberMaterials[sphereNumberExp - 1];
            if (sphereNumberExp >= 10)
            {
                sphereNumberKiloExp = int.Parse(sphereNumber.text) / 1000;
                sphereNumber.text = sphereNumberKiloExp + "k";
            } 
            else
            {
                sphereNumber.text = Mathf.Pow(2, sphereNumberExp).ToString();
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
        GetComponent<MeshRenderer>().material = eachSphereManager.numberMaterials[sphereNumberExp - 1];
        sphereNumber.text = Mathf.Pow(2, sphereNumberExp).ToString();
        if (sphereNumber.text == "1024")
        {
            sphereNumber.text = "1k";
        }
        moveSpeedF = numberExp * 2 + 5;
    }
}
