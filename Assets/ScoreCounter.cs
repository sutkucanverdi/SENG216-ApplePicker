using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // TextMeshPro desteði

public class ScoreCounter : MonoBehaviour
{
    [Header("Dynamic")]
    public int score = 0;

    private TextMeshProUGUI uiText;

    void Start()
    {
        uiText = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        uiText.text = score.ToString("#,0");
    }
}