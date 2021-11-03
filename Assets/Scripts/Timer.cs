using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] bool Takedown = false;
    Text timerText;
    Level level;

    // Start is called before the first frame update
    void Start()
    {
        timerText = GetComponent<Text>();
        level = FindObjectOfType<Level>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!Takedown)
        {
            timerText.text = level.GetTimer().ToString();
        }
        else if (Takedown)
        {
            timerText.text = level.GetEnemies().ToString();
        }
    }
}
