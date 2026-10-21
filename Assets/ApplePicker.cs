using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ApplePicker : MonoBehaviour
{
    [Header("Inscribed")]
    public GameObject basketPrefab;
    public int numBaskets = 3;
    public float basketBottomY = -14f;
    public float basketSpacingY = 2f;
    public List<GameObject> basketList;

    [Header("UI Panels")]
    public GameObject startPanel;
    public GameObject gameOverPanel;
    public TextMeshProUGUI finalScoreText;
    public ScoreCounter scoreCounter;

    void Start()
    {
        // Oyunu baþlangýçta dondur ve Start ekranýný aç
        Time.timeScale = 0f;
        startPanel.SetActive(true);
        gameOverPanel.SetActive(false);

        // Sepetleri oluþtur
        basketList = new List<GameObject>();
        for (int i = 0; i < numBaskets; i++)
        {
            GameObject tBasketGO = Instantiate<GameObject>(basketPrefab);
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + (basketSpacingY * i);
            tBasketGO.transform.position = pos;
            basketList.Add(tBasketGO);
        }

        // Skor sayacýný bul
        GameObject scoreGO = GameObject.Find("ScoreCounter");
        if (scoreGO != null)
        {
            scoreCounter = scoreGO.GetComponent<ScoreCounter>();
        }
    }

    // Oyna butonuna basýlýnca çalýþacak fonksiyon
    public void StartGame()
    {
        startPanel.SetActive(false);
        Time.timeScale = 1f; // Oyunu baþlat
    }

    // Yeniden Baþla butonuna basýlýnca çalýþacak fonksiyon
    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void AppleMissed()
    {
        // Ekrandaki tüm elmalarý temizle
        GameObject[] appleArray = GameObject.FindGameObjectsWithTag("Apple");
        foreach (GameObject tempGO in appleArray)
        {
            Destroy(tempGO);
        }

        // En üstteki sepeti yok et
        int basketIndex = basketList.Count - 1;
        GameObject basketGO = basketList[basketIndex];
        basketList.RemoveAt(basketIndex);
        Destroy(basketGO);

        // Eðer sepet bittiyse GameOver panelini aç ve oyunu dondur
        if (basketList.Count == 0)
        {
            Time.timeScale = 0f;
            gameOverPanel.SetActive(true);
            if (scoreCounter != null && finalScoreText != null)
            {
                finalScoreText.text = "Toplam Skor: " + scoreCounter.score.ToString("#,0");
            }
        }
    }
}