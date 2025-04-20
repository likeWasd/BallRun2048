using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameVariableManager : MonoBehaviour
{
    public static int retryTimes;
    public static float elapsedTime;
    public static int stageNum;
    public static int defaultStageNum;
    //public Material[] numMaterial;
    public MaterialDataBase MaterialDataBase;
    // Start is called before the first frame update
    void Start()
    {
        retryTimes = 0;
        defaultStageNum = 1;
        stageNum = defaultStageNum;
        if (defaultStageNum >= 2) SceneManager.LoadSceneAsync("GameScene" + stageNum, LoadSceneMode.Single);
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
    }

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
