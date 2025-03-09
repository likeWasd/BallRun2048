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
    public Material[] numberMaterial;
    [SerializeField] TextMeshPro sphereNumberObject;
    int sphereNumber;
    int sphereNumberExp;
    Renderer playerMaterial;
    [SerializeField] int defaultNumberExp;
    int eachWallNumber;
    float clearElapsedTime;
    int clearRetryTimes;
    [SerializeField] TextMeshProUGUI stringTextGoal;
    [SerializeField] TextMeshProUGUI stringTextResult;
    [SerializeField] TextMeshProUGUI timeText;
    [SerializeField] TextMeshProUGUI retriedText;
    public int stageNum;
    // Start is called before the first frame update
    void Start()
    {
        if (GameVariableManager.restartStage == 2) transform.position = new Vector3(0, 0, 146);
        moveSpeedF = defaultNumberExp + 5;
        moveSpeedLR = 10;
        sphereNumberExp = defaultNumberExp;
        playerMaterial = gameObject.GetComponent<Renderer>();
        playerMaterial.material = numberMaterial[sphereNumberExp - 1];
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
        if (transform.position.z > -5)
        {
            transform.position += moveSpeedF * transform.forward * Time.deltaTime;
        }
        else
        {
            clearElapsedTime = GameVariableManager.elapsedTime;
            clearRetryTimes = GameVariableManager.retryTimes;
            timeText.text = clearElapsedTime.ToString("f3") + "s";
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
        if (collision.gameObject.CompareTag("Thorn") && sphereNumber >= 4)
        {
            sphereNumber /= 2;
            sphereNumberExp--;
            playerMaterial.material = numberMaterial[sphereNumberExp - 1];
            sphereNumberObject.text = sphereNumber.ToString();
            moveSpeedF -= 2;
            if (moveSpeedF < 6)
            {
                moveSpeedF = 6;
            }
        }
        if (collision.gameObject.CompareTag("Sphere"))
        {
            if (collision.gameObject.GetComponent<EachObject>().objectNumber == sphereNumber)
            {
                Destroy(collision.gameObject);
                sphereNumber *= 2;
                sphereNumberExp++;
                playerMaterial.material = numberMaterial[sphereNumberExp - 1];
                if (sphereNumberExp == 10)
                {
                    sphereNumberObject.text = "1k";
                }
                else
                {
                    sphereNumberObject.text = sphereNumber.ToString();
                }
                moveSpeedF += 2;
                if (moveSpeedF > 17)
                {
                    moveSpeedF = 17;
                }
            }
        }
        if (collision.gameObject.CompareTag("Wall"))
        {
            eachWallNumber = collision.gameObject.GetComponent<EachObject>().objectNumber;
            if (sphereNumber >= eachWallNumber)
            {
                Destroy(collision.gameObject);
                stageNum++;
                moveSpeedF = 6;
                sphereNumberExp = 1;
                playerMaterial = gameObject.GetComponent<Renderer>();
                playerMaterial.material = numberMaterial[sphereNumberExp - 1];
                sphereNumber = (int)Mathf.Pow(2, sphereNumberExp);
                sphereNumberObject.text = sphereNumber.ToString();
            }
            else
            {
                GameVariableManager.restartStage = stageNum;
                GameVariableManager.retryTimes++;
                SceneManager.LoadSceneAsync("GameScene", LoadSceneMode.Single);
            }
        }
    }
}
