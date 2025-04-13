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
    int playerNumber;
    int playerNumberExp;
    int playerNumberKilo;
    [SerializeField] int defaultPlayerNumberExp;
    Renderer playerMaterial;
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
        moveSpeedF = defaultPlayerNumberExp + 5;
        moveSpeedLR = 10;
        playerNumberExp = defaultPlayerNumberExp;
        playerNumber = (int)Mathf.Pow(2, playerNumberExp);
        playerNumberKilo = playerNumber / 1024;
        playerMaterial = gameObject.GetComponent<Renderer>();
        playerMaterial.material = numberMaterial[playerNumberExp - 1];
        if (playerNumberExp == 10)
        {
            sphereNumberObject.text = "1k";
        }
        else
        {
            sphereNumberObject.text = playerNumber.ToString();
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
        if (collision.gameObject.CompareTag("Thorn") && playerNumber >= 4)
        {
            playerNumber /= 2;
            playerNumberExp--;
            playerMaterial.material = numberMaterial[playerNumberExp - 1];
            sphereNumberObject.text = playerNumber.ToString();
            moveSpeedF -= 2;
            if (moveSpeedF < 6)
            {
                moveSpeedF = 6;
            }
        }
        if (collision.gameObject.CompareTag("Sphere"))
        {
            if (collision.gameObject.GetComponent<EachObject>().objectNumber == playerNumber)
            {
                Destroy(collision.gameObject);
                playerNumber *= 2;
                playerNumberExp++;
                playerMaterial.material = numberMaterial[playerNumberExp - 1];
                if (playerNumberExp >= 10)
                {
                    playerNumberKilo = playerNumber / 1024;
                    sphereNumberObject.text = playerNumberKilo + "k";
                }
                else
                {
                    sphereNumberObject.text = playerNumber.ToString();
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
            if (playerNumber >= eachWallNumber)
            {
                Destroy(collision.gameObject);
                GameVariableManager.stageNum++;
                SceneManager.LoadSceneAsync("GameScene" + GameVariableManager.stageNum, LoadSceneMode.Single);
                /*
                moveSpeedF = 6;
                objectNumberExp = 1;
                playerMaterial = gameObject.GetComponent<Renderer>();
                playerMaterial.material = numberMaterial[objectNumberExp - 1];
                playerNumber = (int)Mathf.Pow(2, objectNumberExp);
                sphereNumberObject.text = playerNumber.ToString();
                */
            }
            else
            {
                GameVariableManager.retryTimes++;
                SceneManager.LoadSceneAsync("GameScene" + GameVariableManager.defaultStageNum, LoadSceneMode.Single);
            }
        }
    }
}
