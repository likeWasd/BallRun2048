using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameVariableManager : MonoBehaviour
{
    public static int retryTimes;
    public static float elapsedTime;
    public static int restartStage;
    public static int stageNumAfter;
    public static int stageNumBefore;
    // Start is called before the first frame update
    void Start()
    {
        retryTimes = 0;
        restartStage = 1;
        stageNumAfter = 1;
        stageNumBefore = 1;
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
    }

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
