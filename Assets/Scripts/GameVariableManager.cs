using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameVariableManager : MonoBehaviour
{
    public static int retryTimes;
    public static float elapsedTime;
    // Start is called before the first frame update
    void Start()
    {
        retryTimes = 0;
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
    }
}
