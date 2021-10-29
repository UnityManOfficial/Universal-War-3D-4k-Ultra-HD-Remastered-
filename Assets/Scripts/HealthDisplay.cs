using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{

    Text HealthText;
    Player player;


    void Start()
    {
        HealthText = GetComponent<Text>();
        player = FindObjectOfType<Player>();
    }


    void Update()
    {
        HealthText.text = player.GetHealth().ToString();
    }
}
