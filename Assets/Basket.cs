using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour
{
    public ScoreCounter scoreCounter;
    public GameObject scorePopupPrefab;

    void Start()
    {
        GameObject scoreGO = GameObject.Find("ScoreCounter");
        if (scoreGO != null)
        {
            scoreCounter = scoreGO.GetComponent<ScoreCounter>();
        }
    }

    void Update()
    {
        Vector3 mousePos2D = Input.mousePosition;
        mousePos2D.z = -Camera.main.transform.position.z;
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;
    }

    void OnCollisionEnter(Collision coll)
    {
        GameObject collidedWith = coll.gameObject;

        if (collidedWith.CompareTag("Apple"))
        {
            if (scorePopupPrefab != null)
            {
                Instantiate(scorePopupPrefab, collidedWith.transform.position, Quaternion.identity);
            }

            Destroy(collidedWith);

            if (scoreCounter != null)
            {
                scoreCounter.score += 100;
                HighScore.TRY_SET_HIGH_SCORE(scoreCounter.score);
            }
        }
    }
}