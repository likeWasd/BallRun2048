using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerMove : MonoBehaviour
{
    // プレイヤーが進むスピード(FはForward)
    int moveSpeedF;
    // プレイヤーが進むスピード(LRはLeftRight)
    int moveSpeedLR;
    public Material[] numberMaterial;
    [SerializeField] TextMeshPro sphereNumberObject;
    int halfSphereNumber;
    int sphereNumber;
    int sphereNumberExp;
    [SerializeField] int defaultNumberExp;
    int eachWallNumber;
    float clearElapsedTime;
    int clearRetryTimes;
    [SerializeField] TextMeshProUGUI stringTextGoal;
    [SerializeField] TextMeshProUGUI stringTextResult;
    [SerializeField] TextMeshProUGUI timeText;
    [SerializeField] TextMeshProUGUI retriedText;
    // Start is called before the first frame update
    void Start()
    {
        moveSpeedF = 2 * defaultNumberExp + 5;
        moveSpeedLR = 10;
        numberMaterial = gameObject.GetComponent<Renderer>().materials;
        sphereNumberExp = defaultNumberExp;
        sphereNumber = (int)Mathf.Pow(2, sphereNumberExp);
        if (sphereNumberExp == 10)
        {
            sphereNumberObject.text = "1k";
        }
        else
        {
            sphereNumberObject.text = sphereNumber.ToString();
        }
        stringTextGoal.enabled = false;
        stringTextResult.enabled = false;
        timeText.enabled = false;
        retriedText.enabled = false;
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
        if (collision.gameObject.CompareTag("Thorn") && int.Parse(sphereNumberObject.text) >= 4)
        {
            halfSphereNumber = sphereNumber / 2;
            sphereNumberExp--;
            gameObject.GetComponent<Renderer>().material = numberMaterial[sphereNumberExp];
            sphereNumberObject.text = halfSphereNumber.ToString();
            moveSpeedF -= 2;
        }
        if (collision.gameObject.CompareTag("Sphere") && GameObject.Find($"Sphere{sphereNumber}").GetComponent<EachSphereAndWall>().objectNumber == sphereNumber)
        {
            Destroy(collision.gameObject);
            sphereNumberExp++;
            sphereNumber *= 2;
            gameObject.GetComponent<Renderer>().material = numberMaterial[sphereNumberExp];
            if (sphereNumberExp == 10)
            {
                sphereNumberObject.text = "1k";
            }
            else
            {
                sphereNumberObject.text = sphereNumber.ToString();
            }
            moveSpeedF += 2;
        }
        if (collision.gameObject.CompareTag("Wall"))
        {
            eachWallNumber = collision.gameObject.GetComponent<EachSphereAndWall>().objectNumber;
            if (sphereNumber >= eachWallNumber)
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
}
